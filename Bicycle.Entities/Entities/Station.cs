using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bicycle.Entities.Entities
{
    public class Station:BaseEntity
    {
        public string SId { get; set; }
        public string Name { get; set; }
        public int NetworkId { get; set; }
        public int? FreeBikes { get; set; }
        public int? EmptySlots { get; set; }

        [ForeignKey("NetworkId")]
        public virtual Network Network { get; set; }
    }
}
