using Bicycle.Business.Repositories.Interface;
using Bicycle.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bicycle.Business.Interface
{
    public interface IStockOnHoldService:IBaseService<BicycleStockOnHold>
    {
        int GetByQuantityWithStationId(int id);
        int GetByQueueWithUserId(int stationid ,string userid);
        void RemoveTimeRecordsIfGratherThanNow();
        bool UserIsInRace(string userid,int stationId);
        BicycleStockOnHold GetWithUserIdForBycleStockData(string userid);
    }
}
