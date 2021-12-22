using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Properties.Commands.UpdatePropertyCommand
{
    /// <summary>
    /// Clase que define las validaciones de la entidad Property
    /// </summary>
    public class UpdatePropertyCommandValidator : AbstractValidator<UpdatePropertyCommand>
    {
        public UpdatePropertyCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .MaximumLength(70).WithMessage("{PropertyName} cannot exceed the size of {MaxLength}.");

            RuleFor(p => p.Address)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .MaximumLength(70).WithMessage("{PropertyName} cannot exceed the size of {MaxLength}.");

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.");

            RuleFor(p => p.CodInternal)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.");

            RuleFor(p => p.Year)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.");

            RuleFor(p => p.IdOwner)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.");


        }
    }
}
