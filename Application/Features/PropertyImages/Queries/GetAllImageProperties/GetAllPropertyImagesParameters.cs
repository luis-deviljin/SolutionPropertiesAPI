using Application.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PropertyImages.Queries.GetAllImageProperties
{

    /// <summary>
    /// Clase con parametros que se pueden utilizar para el filtrado
    /// </summary>
    public class GetAllPropertyImagesParameters : RequestParameter
    {
        public string File { get; set; }
        public int IdProperty { get; set; }

    }
}
