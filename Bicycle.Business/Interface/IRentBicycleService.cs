using Bicycle.Business.Repositories.Interface;
using Bicycle.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bicycle.Business.Interface
{
    public interface IRentBicycleService:IBaseService<RentBicycle>
    {
        List<RentBicycle> GetRentedBikesForUser(string userid);
        void Remove(RentBicycle rentBicycle);
    }
}
