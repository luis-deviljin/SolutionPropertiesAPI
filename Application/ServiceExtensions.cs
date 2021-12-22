using Application.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    /// <summary>
    /// Clase que permite agrupar las inyecciones de los servicios propios o de terceros
    /// </summary>
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());  //nuget de automaper para mapear la bd
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()); //nuget fluent
            services.AddMediatR(Assembly.GetExecutingAssembly()); // nuget MediaTR
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>)); //MediaTR
        }
    }
}
