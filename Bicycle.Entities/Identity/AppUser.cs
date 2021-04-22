using Bicycle.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bicycle.DataAccess.Identity
{
    public class AppUser:IdentityUser
    {
        public AppUser()
        {
            Point = 0;
        }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int? Point { get; set; }
    }
}
