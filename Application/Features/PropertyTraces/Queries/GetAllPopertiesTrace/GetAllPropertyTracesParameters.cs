using Application.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PropertyTraces.Queries.GetAllPopertiesTrace
{
    /// <summary>
    /// Clase con parametros que se pueden utilizar para el filtrado
    /// </summary>
    public class GetAllPropertyTracesParameters : RequestParameter
    {
        public DateTime date { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public double Tax { get; set; }

    }
}
