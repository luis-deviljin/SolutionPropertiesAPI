using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class PropertyImageDto
    {
        public string File { get; set; }
        public bool? Enable { get; set; }
        public int IdProperty { get; set; }
    }
}
