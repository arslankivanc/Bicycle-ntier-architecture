using Bicycle.DataAccess.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bicycle.Entities.Entities
{
    public class RentBicycle :BaseEntity
    {
        public bool RentIsActive { get; set; }
        public int StationId { get; set; }
        public string UserId { get; set; }
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        [ForeignKey("UserId")]
        public virtual AppUser AppUser { get; set; }
        [ForeignKey("StationId")]
        public virtual Station Station { get; set; }
    }
}
