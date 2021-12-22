using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    /// <summary>
    /// Clase que manejara las Excepciones de la api
    /// </summary>
    public class ApiException: Exception
    {
        public ApiException() : base() { }
        public ApiException(string message) : base(message) { }
        public ApiException(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args)) 
        {

        }
    }
}
