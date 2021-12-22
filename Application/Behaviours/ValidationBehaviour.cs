using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Behaviours
{

    /// <summary>
    /// Clase Mediadora del nuget MediaTR, la cual captura, todo a traves del Validator del nuget fluent valida todo el contenido que ingrese en el API, 
    /// lo canaliza antes de ingresar en el manejador principal y nos permite manejar todas las excepciones.  (se valida: request - pipeline - response)
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>// son del nuget MediaTR
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;//

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if(_validators.Any())
            {
                var context = new FluentValidation.ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if(failures.Count !=0)
                {
                    throw new Exceptions.Validationxception(failures);
                }

            }
            return await next();
        }
    }
}
