using Bicycle.API.ApiModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bicycle.API
{
    public class BicycleStationModel:BaseClass
    {
        public class Rootobjectstation
        {
            public Rootobjectstation()
            {
                network = new NetworkStation();
            }
            public NetworkStation network { get; set; }
        }

        public class NetworkStation
        {
            public NetworkStation()
            {
                location = new Location();
                stations = new List<StationModel>();
            }
            public string[] company { get; set; }
            public string href { get; set; }
            public string id { get; set; }
            public Location location { get; set; }
            public string name { get; set; }
            public List<StationModel> stations { get; set; }
        }

        public class StationModel
        {
            public StationModel()
            {
                extra = new ExtraModel();
            }
            public int? empty_slots { get; set; }
            public ExtraModel extra { get; set; }
            public int? free_bikes { get; set; }
            public string id { get; set; }
            public float latitude { get; set; }
            public float longitude { get; set; }
            public string name { get; set; }
            public DateTime timestamp { get; set; }
        }

        public class ExtraModel
        {
            public string address { get; set; }
            public int ebikes { get; set; }
            public int electric_free { get; set; }
            public int electric_slots { get; set; }
            public int normal_bikes { get; set; }
            public int normal_free { get; set; }
            public int normal_slots { get; set; }
            public int slots { get; set; }
            public string uid { get; set; }
        }

    }
}
