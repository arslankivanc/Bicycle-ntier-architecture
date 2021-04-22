using Bicycle.DataAccess.Contexts;
using Bicycle.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using static Bicycle.API.BicycleNetworkModel;
using static Bicycle.API.BicycleStationModel;

namespace Bicycle.Business
{
    public static class ExternalData
    {
        public static async void GetExternalData(IServiceProvider serviceProvider)
        {
            using (var context = new DatabaseContext(serviceProvider.GetRequiredService<DbContextOptions<DatabaseContext>>()))
            {
                using (var clientNetwork = new HttpClient())
                {
                    string url = string.Format("http://api.citybik.es/v2/networks");
                    var response = clientNetwork.GetAsync(url).Result;
                    string responseAsString = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Rootobject>(responseAsString);
                    
                    List<AllNetwork> networks = result.networks.Take(10).ToList();
                    foreach (var network in networks)
                    {
                        using (var clientStation = new HttpClient())
                        {
                            string getUrl = string.Format("http://api.citybik.es/v2/networks/" + network.id);
                            var responseStations = clientStation.GetAsync(getUrl).Result.Content.ReadAsStringAsync().Result;
                            var result2 = JsonConvert.DeserializeObject<Rootobjectstation>(responseStations);

                            Network addNetwork = new Network();
                            addNetwork.NId = network.id;
                            addNetwork.Name = network.name;
                            addNetwork.Location = new Location()
                            {
                                Country = network.location.country,
                                City = network.location.city
                            };

                            var stations = result2.network.stations.Where(x => x.empty_slots >= 0 && x.free_bikes >= 0).Take(5).ToList();
                            foreach (var station in stations)
                            {
                                Station addStation = new Station();
                                addStation.SId = station.id;
                                addStation.Name = station.name;
                                addStation.FreeBikes = station.free_bikes;
                                addStation.EmptySlots = station.empty_slots;
                                addNetwork.Stations.Add(addStation);
                            }
                            context.Add(addNetwork);
                            context.SaveChanges();
                        }
                    }
                }
            }
        }
    }

}