using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    /// <summary>
    /// Clase generica que maneja las excepciones en las validaciones, cuando no se cumplen las validaciones.
    /// </summary>
    public class Validationxception : Exception
    {
        public Validationxception() : base("One or more Validation errors have occurred")
        {
            Errors = new List<string>();
        }
        public List<string> Errors { get; }
        public Validationxception(IEnumerable<ValidationFailure> failures) : this()
        {
            foreach(var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }
    }
}
