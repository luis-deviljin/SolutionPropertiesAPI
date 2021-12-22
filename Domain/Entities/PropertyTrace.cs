using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PropertyTrace : AuditableBaseEntity
    {
        [Column(TypeName = "Date")]
        public DateTime DateSale { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public double Tax { get; set; }
        
        public int IdProperty { get; set; }
        public Property Property { get; set; }

    }
}
