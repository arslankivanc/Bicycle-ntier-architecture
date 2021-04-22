using Bicycle.DataAccess.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bicycle.Entities.Entities
{
    public class BicycleStockOnHold:BaseEntity
    {
        public int StationId { get; set; }
        public int Quantity { get; set; }
        public string UserId { get; set; }
        public DateTime ExpiryDate { get; set; }

        [ForeignKey("UserId")]
        public virtual AppUser AppUser { get; set; }
    }
}
