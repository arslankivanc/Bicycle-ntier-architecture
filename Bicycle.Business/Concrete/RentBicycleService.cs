using Bicycle.Business.Interface;
using Bicycle.Business.Repositories.Concrete;
using Bicycle.DataAccess.Contexts;
using Bicycle.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bicycle.Business.Concrete
{
    public class RentBicycleService:BaseService<RentBicycle>, IRentBicycleService
    {
        private static DatabaseContext _context;

        public RentBicycleService(DatabaseContext context):base(context)
        {
            _context = context;
        }
        public List<RentBicycle> GetRentedBikesForUser(string userid)
        {
            return _context.RentBicycles.Include(x=>x.AppUser).Where(x => x.UserId == userid).OrderByDescending(x=>x.RentIsActive).ToList();
        }

        public void Remove(RentBicycle rentBicycle)
        {
            _context.Remove(rentBicycle);
            _context.SaveChanges();
        }
    }
}
