using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bicycle.Models
{
    public class StockOnHoldViewModel
    {
        public int StationId { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
