using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PropertyImage.Commands.CreatePropertyImageCommand
{
    /// <summary>
    /// Clase que define las validaciones de la entidad PropertyImage
    /// </summary>
    public class CreatePropertyImageCommandValidator : AbstractValidator<CreatePropertyImageCommand>
    {
        public CreatePropertyImageCommandValidator()
        {
            RuleFor(p => p.File)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.");

            RuleFor(p => p.Enable)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.");

            RuleFor(p => p.IdProperty)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.");

        }
    }
}
