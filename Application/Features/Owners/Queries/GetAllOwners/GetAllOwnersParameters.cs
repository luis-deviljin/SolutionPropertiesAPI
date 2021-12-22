using Application.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Owners.Queries.GetAllOwners
{
    /// <summary>
    /// Clase con parametros que se pueden utilizar para el filtrado
    /// </summary>
    public class GetAllOwnersParameters: RequestParameter
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
