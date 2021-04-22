using AutoMapper;
using Bicycle.Business.Interface;
using Bicycle.Business.Repositories.Interface;
using Bicycle.DataAccess.Contexts;
using Bicycle.DataAccess.Identity;
using Bicycle.Entities.Entities;
using Bicycle.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading.Tasks;
using X.PagedList;
using static Bicycle.API.BicycleNetworkModel;
using static Bicycle.API.BicycleStationModel;

namespace Bicycle.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _context;
        private readonly IStationService _stationService;
        private readonly IStockOnHoldService _stockOnHoldService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IRentBicycleService _rentBicycleService;
        private readonly DatabaseContext _databaseContext;

        public HomeController(ILogger<HomeController> logger,DatabaseContext context,IStationService stationService,IStockOnHoldService stockOnHoldService,
            IMapper mapper, UserManager<AppUser> userManager,IRentBicycleService rentBicycleService,DatabaseContext databaseContext)
        {
            _logger = logger;
            _context = context;
            _stationService = stationService;
            _stockOnHoldService = stockOnHoldService;
            _mapper = mapper;
            _userManager = userManager;
            _rentBicycleService = rentBicycleService;
            _databaseContext = databaseContext;
        }
        [HttpGet]
        public IActionResult Index(int? SayfaNo)
        {
            int _sayfaNo = SayfaNo ?? 1;
            var allstations = _context.Stations.Include(x => x.Network).ToPagedList<Station>(_sayfaNo, 5);
            return View(allstations);
        }
        [HttpGet]
        public IActionResult Search(string search)
        {
            _logger.LogInformation(string.Format("{0} için arama yapılıyor... ",search));
            var stations = _context.Stations
                .Include(s => s.Network)
                    .ThenInclude(n => n.Location).Where(y => y.Network.Location.Country.Contains(search) || y.Network.Location.City.Contains(search)).ToList();
            return View(stations);
        }
        [HttpGet]
        public IActionResult Station(int id)
        {
            _logger.LogInformation("istasyon sayfası için istekte bulunuldu.");
            _stockOnHoldService.RemoveTimeRecordsIfGratherThanNow();
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");

            var station = _stationService.Find(id);

            /*Kullanıcı Race Condition da mı?*/
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            ViewBag.userPoint = user.Point;

            var userIsInRace = _stockOnHoldService.UserIsInRace(user.Id,station.Id);
            if (userIsInRace)
                return View(station);

            /*Kullanıcıyı Race Condition'a ekle*/
            var stockModel = new StockOnHoldViewModel
            {
                StationId = station.Id,
                Quantity = 1,
                ExpiryDate = DateTime.Now.AddMinutes(10)
            };
            BicycleStockOnHold bicycleStockOnHold = _mapper.Map<BicycleStockOnHold>(stockModel);
            bicycleStockOnHold.UserId = user.Id;
            _stockOnHoldService.Add(bicycleStockOnHold);
            _logger.LogInformation(string.Format("istasyon sayfası sorunsuz bir şekilde açıldı"));
            return View(station);
        }
        public string[] PaymentMethodCard(int id, string username)
        {
            _logger.LogInformation(string.Format("{0} kullanıcısı kredi kartı ile ödemi işlemi gerçekleştiriyor...", username));
            _stockOnHoldService.RemoveTimeRecordsIfGratherThanNow();

            var messaje  = new string[2];
            if (username == null)
            {
                messaje[0] = "Geçerli kullanıcı bulunamadı.Oturum açınız.";
                messaje[1] = "false";
                return messaje;
            }

            var user = _userManager.FindByNameAsync(username).Result;
            var station = _stationService.Find(id);
            var userIsInRace = _stockOnHoldService.UserIsInRace(user.Id,station.Id);
            if (station.FreeBikes == 0 || station.FreeBikes == null) {
                messaje[0] = "Geçerli işleminiz bitti ya da stokta bisiklet kalmadı.";
                messaje[1] = "false";
                return messaje;
            }

            /*Kullanıcıya mevcut bisikletler için işlemlerin devam ettiğini bildir*/
            var totalQuantity = _stockOnHoldService.GetByQuantityWithStationId(station.Id);

            var queue = _stockOnHoldService.GetByQueueWithUserId(station.Id, user.Id);
            if (totalQuantity - station.FreeBikes > 0 && userIsInRace)
            {
                var x = totalQuantity - station.FreeBikes - 1;
                if (x>=0 && (x-queue)<0)
                {
                    messaje[0] = "Seçili bisiklet başka bir kullanıcı tarafından işlem görmektedir.Biraz sonra tekrar deneyin.";
                    messaje[1] = "false";
                    _logger.LogInformation(string.Format("{0} kullanıcısı sırada bekliyor.Ödeme işlemi tamamlanmadı. ",username));
                    return messaje;
                }
            }
            if (station.FreeBikes>0)
            {
                RentBicycle rentBicycle = new RentBicycle
                {
                    CreatedBy = username,
                    CreatedOn = DateTime.Now,
                    RentIsActive = true,
                    UserId = Convert.ToString(user.Id),
                    StationId = id
                };
                var removeData = _stockOnHoldService.GetWithUserIdForBycleStockData(user.Id);
                if (removeData != null)
                    _stockOnHoldService.Delete(removeData);

                /*Kiralama başarılıysa ilgili istasyonda freebicycle azaltılır empty slot arttırılır */
                station.FreeBikes -= 1;
                station.EmptySlots += 1;
                _stationService.Update(station);
                _rentBicycleService.Add(rentBicycle);
                messaje[0] = "Bisiklet başarıyla kiralandı.";
                messaje[1] = "true";
                _logger.LogInformation(string.Format("{0} kullanıcısı kiralama işlemini başarıyla gerçekleştirdi.", username));
                return messaje;
            }
            else
            {
                messaje[0] = "Bir hata oluştu.";
                messaje[1] = "false";
                _logger.LogInformation(string.Format("{0} kullanıcısı ödeme işlemi yaparken bir hatayla karşılaşıldı.", username));
                return messaje;
            }
        }
        public string[] PaymentMethodPoint(int id, string username)
        {
            _logger.LogInformation(string.Format("{0} kullanıcısı kredi kartı ile ödemi işlemi gerçekleştiriyor...", username));
            _stockOnHoldService.RemoveTimeRecordsIfGratherThanNow();

            var messaje = new string[2];
            if (username == null)
            {
                messaje[0] = "Geçerli kullanıcı bulunamadı.Oturum açınız.";
                messaje[1] = "false";
                return messaje;
            }
            var user = _userManager.FindByNameAsync(username).Result;
            if (user.Point<50)
            {
                messaje[0] = "Bu ödeme için yeterli puanınız yoktur.Gereken puan 50'dir";
                messaje[1] = "false";
                return messaje;
            }
            var station = _stationService.Find(id);
            var userIsInRace = _stockOnHoldService.UserIsInRace(user.Id,station.Id);
            if (station.FreeBikes == 0 || station.FreeBikes == null)
            {
                messaje[0] = "Geçerli işleminiz bitti ya da stokta bisiklet kalmadı.";
                messaje[1] = "false";
                return messaje;
            }

            /*Kullanıcıya mevcut bisikletler için işlemlerin devam ettiğini bildir*/
            var totalQuantity = _stockOnHoldService.GetByQuantityWithStationId(station.Id);
            var queue = _stockOnHoldService.GetByQueueWithUserId(station.Id, user.Id);

            if (totalQuantity - station.FreeBikes > 0 && userIsInRace)
            {
                var x = totalQuantity - station.FreeBikes - 1;
                if (x >= 0 && (x - queue) < 0)
                {
                    messaje[0] = "Seçili bisiklet başka bir kullanıcı tarafından işlem görmektedir.Biraz sonra tekrar deneyin.";
                    messaje[1] = "false";
                    _logger.LogInformation(string.Format("{0} kullanıcısı sırada bekliyor.Ödeme işlemi tamamlanmadı. ", username));
                    return messaje;
                }
            }
            if (station.FreeBikes>0)
            {
                RentBicycle rentBicycle = new RentBicycle
                {
                    CreatedBy = username,
                    CreatedOn = DateTime.Now,
                    RentIsActive = true,
                    UserId = Convert.ToString(user.Id),
                    StationId = id
                };
                var removeData = _stockOnHoldService.GetWithUserIdForBycleStockData(user.Id);
                if (removeData != null)
                    _stockOnHoldService.Delete(removeData);

                /*Kiralama başarılıysa ilgili istasyonda freebicycle azaltılır empty slot arttırılır */
                station.FreeBikes -= 1;
                station.EmptySlots += 1;
                _stationService.Update(station);
                _rentBicycleService.Add(rentBicycle);

                var userUpdated = _userManager.FindByIdAsync(user.Id).Result;
                userUpdated.Point -= 50;
                _context.Entry(userUpdated).State = EntityState.Modified;
                _context.SaveChanges();
                messaje[0] = "Bisiklet başarıyla kiralandı.";
                messaje[1] = "true";

                _logger.LogInformation(string.Format("{0} kullanıcısı kiralama işlemini başarıyla gerçekleştirdi.", username));
                return messaje;
            }
            else
            {
                messaje[0] = "Bir hata oluştu.";
                messaje[1] = "false";
                _logger.LogInformation(string.Format("{0} kullanıcısı ödeme işlemi yaparken bir hatayla karşılaşıldı.", username));
                return messaje;
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delivery(int id)
        {
            _logger.LogInformation(string.Format("Bisiklet teslim sayfası açılıyor..."));
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login","Account");
            var station = _stationService.Find(id);
            if (station == null)
                return NotFound();
            ViewBag.Station = station;
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var data = _rentBicycleService.GetRentedBikesForUser(user.Id).Where(x=>x.RentIsActive==true).ToList();
            _logger.LogInformation(string.Format("Bisiklet teslim sayfası başarıyla açıldı."));
            return View(data);
        }
        [HttpGet]
        public bool DeliveryConfirm(int sid,int rentid)
        {
            _logger.LogInformation(string.Format("{0} kullanıcısı bisiklet teslim ediyor...",User.Identity.Name));
            var station = _stationService.Find(sid);
            var rentBicycle = _rentBicycleService.Find(rentid);
            if (station == null || rentBicycle == null || station.EmptySlots ==0)
                return false;
            rentBicycle.RentIsActive = false;
            rentBicycle.UpdatedOn = DateTime.Now;
            _context.Entry(rentBicycle).State = EntityState.Modified;
            _context.SaveChanges();

            var user =_userManager.FindByNameAsync(User.Identity.Name).Result;
            user.Point += 5;
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();

            station.FreeBikes += 1;
            station.EmptySlots -= 1;
            _context.Entry(station).State = EntityState.Modified;
            _context.SaveChanges();
            _logger.LogInformation(string.Format("{0} kullanıcısı bisikleti başarıyla teslim etti.", User.Identity.Name));
            return true;
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Rentbicycle()
        {
            _logger.LogInformation(string.Format("{0} kullanıcısı bisikletlerim sayfasına erişiyor...", User.Identity.Name));
            var user =await _userManager.FindByNameAsync(User.Identity.Name);
            var data = _rentBicycleService.GetRentedBikesForUser(user.Id);
            return View(data);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
