using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    /// <summary>
    /// Interfaz para manejar las fechas de creacion y modificacion de la BD
    /// </summary>
    public interface IDateTimeServices
    {
        DateTime NowUtc { get; }
    }
}
