using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authenticate.Command.RegisterCommand
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .MaximumLength(70).WithMessage("{PropertyName} cannot exceed the size of {MaxLength}.");           

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .EmailAddress().WithMessage("{PropertyValue} is not a valid email address.")
                .MaximumLength(70).WithMessage("{PropertyName} cannot exceed the size of {MaxLength}.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .MaximumLength(70).WithMessage("{PropertyName} cannot exceed the size of {MaxLength}.");

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .MaximumLength(15).WithMessage("{PropertyName} cannot exceed the size of {MaxLength}.");

            RuleFor(p => p.ConfirmPassword)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .MaximumLength(15).WithMessage("{PropertyName} cannot exceed the size of {MaxLength}.")
                .Equal(p => p.Password).WithMessage("{PropertyName} needs to be equals to Password.");

        }
    }
}
