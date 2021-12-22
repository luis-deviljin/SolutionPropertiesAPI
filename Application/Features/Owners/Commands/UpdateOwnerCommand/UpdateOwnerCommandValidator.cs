using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Owners.Commands.UpdateOwnerCommand
{
    /// <summary>
    /// Clase que valida la entidad OWNER al ser actualizada
    /// </summary>
    public class UpdateOwnerCommandValidator : AbstractValidator<UpdateOwnerCommand>
    {
        public UpdateOwnerCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .MaximumLength(70).WithMessage("{PropertyName} cannot exceed the size of {MaxLength}.");

            RuleFor(p => p.Address)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .MaximumLength(70).WithMessage("{PropertyName} cannot exceed the size of {MaxLength}.");

            RuleFor(p => p.Photo)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .MaximumLength(70).WithMessage("{PropertyName} cannot exceed the size of {MaxLength}.");

            RuleFor(p => p.Birthday)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .EmailAddress().WithMessage("{PropertyValue} is not a valid email address.")
                .MaximumLength(70).WithMessage("{PropertyName} cannot exceed the size of {MaxLength}.");

            RuleFor(p => p.NumberofContact)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .MaximumLength(70).WithMessage("{PropertyName} cannot exceed the size of {MaxLength}.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .MaximumLength(70).WithMessage("{PropertyName} cannot exceed the size of {MaxLength}.");

            RuleFor(p => p.Enable)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.");

        }
    }
}
