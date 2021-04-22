using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bicycle.Models
{
    public class StationViewModel
    {
        public string Name { get; set; }
        public int NetworkId { get; set; }
        public int? FreeBikes { get; set; }
        public int? EmptySlots { get; set; }
    }
}
