using System;
using System.Collections.Generic;
using System.Text;

namespace Bicycle.API.ApiModels
{
    public class BaseClass
    {
        public class Location
        {
            public string city { get; set; }
            public string country { get; set; }
            public float latitude { get; set; }
            public float longitude { get; set; }
        }
    }
}
