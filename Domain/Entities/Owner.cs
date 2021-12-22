using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Owner : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string  NumberofContact{ get; set; }

        public ICollection<Property> Property { get; set; }

    }
}
