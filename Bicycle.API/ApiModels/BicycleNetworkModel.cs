using Bicycle.API.ApiModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bicycle.API
{
    public class BicycleNetworkModel:BaseClass
    {
        public class Rootobject
        {
            public AllNetwork[] networks { get; set; }
        }

        public class AllNetwork
        {
            public AllNetwork()
            {
                location = new Location();
                license = new License();
            }
            public object company { get; set; }
            public string href { get; set; }
            public string id { get; set; }
            public Location location { get; set; }
            public string name { get; set; }
            public string source { get; set; }
            public string gbfs_href { get; set; }
            public License license { get; set; }
        }

        public class License
        {
            public string name { get; set; }
            public string url { get; set; }
        }
    }
}
