using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bicycle.Entities.Entities
{
    public class Location:BaseEntity
    {
        public string Country { get; set; }
        public string City { get; set; }
        public virtual Network Network { get; set; }
    }
}
