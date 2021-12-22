using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Property : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double Price { get; set; }
        public string CodInternal { get; set; }
        public int Year { get; set; }

        public int IdOwner { get; set; }
        public Owner Owner { get; set; }

        public ICollection<PropertyImage> PropertyImage { get; set; }
        public ICollection<PropertyTrace> PropertyTrace { get; set; }
    }
}
