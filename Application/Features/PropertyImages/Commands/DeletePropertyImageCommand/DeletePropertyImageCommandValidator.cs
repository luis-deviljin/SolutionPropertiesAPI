using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PropertyImages.Commands.DeletePropertyImageCommand
{

    /// <summary>
    /// Clase que valida la entidad al ser borrada
    /// </summary>
    public class DeletePropertyImageCommandValidator : AbstractValidator<DeletePropertyImageCommand>
    {
        public DeletePropertyImageCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.");
        }
    }
}
