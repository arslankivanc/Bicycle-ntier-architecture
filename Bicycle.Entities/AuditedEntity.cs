using System;
using System.Collections.Generic;
using System.Text;

namespace Bicycle.Entities
{
    public interface IAuditedEntity
    {
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}
