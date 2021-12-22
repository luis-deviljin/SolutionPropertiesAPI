using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PropertyTraces.Commands.UpdatePropertyTraceCommand
{
    /// <summary>
    /// Clase que define las validaciones de la entidad PropertyTrace
    /// </summary>
    public class CreatePropertyTraceCommandValidator : AbstractValidator<UpdatePropertyTraceCommand>
    {
        public CreatePropertyTraceCommandValidator()
        {
            RuleFor(p => p.DateSale)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .MaximumLength(70).WithMessage("{PropertyName} cannot exceed the size of {MaxLength}.");

            RuleFor(p => p.Value)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.");

            RuleFor(p => p.Tax)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.");

            RuleFor(p => p.IdProperty)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.");

        }
    }
}
