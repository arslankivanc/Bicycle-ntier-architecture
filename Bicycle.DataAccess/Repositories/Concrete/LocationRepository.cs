using Bicycle.DataAccess.Contexts;
using Bicycle.DataAccess.Repositories.Interface;
using Bicycle.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bicycle.DataAccess.Repositories.Concrete
{
    public class LocationRepository:BaseRepository<Location>,ILocationRepository
    {
        public LocationRepository(DatabaseContext context):base(context)
        {
        }
    }
}
