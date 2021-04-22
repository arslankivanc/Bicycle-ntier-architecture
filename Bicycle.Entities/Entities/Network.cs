using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bicycle.Entities.Entities
{
    public class Network:BaseEntity
    {
        public Network()
        {
            Stations = new HashSet<Station>();
        }
        public string NId { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }

        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }
        public virtual ICollection<Station> Stations { get; set; }
    }
}
