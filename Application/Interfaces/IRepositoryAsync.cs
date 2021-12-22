using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    /// <summary>
    /// Interfaz para manejar la gestion de la BD a traves de un repositorio generico  //nuget ardalis
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryAsync<T> : IRepositoryBase<T> where T : class
    {
    }
    public interface IReadRepositoryAsync<T>: IRepositoryBase<T> where T : class
    {

    }
}
