using AutoMapper;
using Bicycle.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bicycle.Models.AutoMapper
{
    public class AutoMapProfile:Profile
    {
        public AutoMapProfile()
        {
            CreateMap<StockOnHoldViewModel, BicycleStockOnHold>();
            CreateMap<BicycleStockOnHold, StockOnHoldViewModel>();
            CreateMap<StationViewModel, Station>();
            CreateMap<Station, StationViewModel>();
        }
    }
}
