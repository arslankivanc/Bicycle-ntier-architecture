using Bicycle.Business.Interface;
using Bicycle.Business.Repositories.Concrete;
using Bicycle.DataAccess.Contexts;
using Bicycle.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bicycle.Business.Concrete
{
    public class StockOnHoldService:BaseService<BicycleStockOnHold>,IStockOnHoldService
    {
        private static DatabaseContext _context;

        public StockOnHoldService(DatabaseContext context):base(context)
        {
            _context = context;
        }

        public int GetByQuantityWithStationId(int stationid)
        {
            var quantity = _context.BicycleStockOnHolds.Where(x => x.StationId == stationid).Sum(x => x.Quantity);//2
            return quantity;
        }

        public int GetByQueueWithUserId(int stationid,string userid)
        {
            var time = _context.BicycleStockOnHolds.Where(x => x.StationId == stationid).OrderBy(x => x.ExpiryDate).ToList();//2

            var queue = 0;
            for (int i = 0; i < time.Count; i++)
            {
                if (time[i].UserId != userid) queue += 1;
                else break;
            }
            return queue;
        }

        public BicycleStockOnHold GetWithUserIdForBycleStockData(string userid)
        {
            var data = _context.BicycleStockOnHolds.Where(x => x.UserId == userid).FirstOrDefault();
            return data;
        }

        public void RemoveTimeRecordsIfGratherThanNow()
        {
            var records=_context.BicycleStockOnHolds.Where(x => (x.ExpiryDate.CompareTo(DateTime.Now)<=0)).ToList();
            _context.RemoveRange(records);
            _context.SaveChanges();
        }

        public bool UserIsInRace(string userid,int stationId)
        {
            var userInRace=_context.BicycleStockOnHolds.Where(x => x.UserId == userid && x.StationId==stationId).FirstOrDefault();
            if (userInRace == null) return false;
            return true;
        }
    }
}
