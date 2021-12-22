using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Models
{
    /// <summary>
    /// Clase para la autenticacion
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
