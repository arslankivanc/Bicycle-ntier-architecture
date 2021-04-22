using Bicycle.Business.Repositories.Interface;
using Bicycle.DataAccess.Contexts;
using Bicycle.DataAccess.Repositories.Concrete;
using Bicycle.DataAccess.Repositories.Interface;
using Bicycle.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bicycle.Business.Repositories.Concrete
{
    public class LocationService:BaseService<Location>,ILocationService
    {
        public LocationService(DatabaseContext context):base(context)
        {
        }
    }
}
