using Domain.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PropertyImage : AuditableBaseEntity
    {
        public string File { get; set; }
        public bool? Enable { get; set; }
        public int IdProperty { get; set; }
        public Property Property { get; set; }
    }
}
