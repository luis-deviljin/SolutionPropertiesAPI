using Application.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Properties.Queries.GetAllProperties
{
    /// <summary>
    /// Clase con parametros que se pueden utilizar para el filtrado
    /// </summary>
    public class GetAllPropertiesParameters : RequestParameter
    {
        public string Name { get; set; }
        public string Addres { get; set; }
        public double Price { get; set; }
        public string CodInternal { get; set; }
        public int Year { get; set; }

    }
}
