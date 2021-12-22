using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PropertyTraces.Commands.DeletePropertyTraceCommand
{

    /// <summary>
    /// Clase que valida la entidad al ser borrada
    /// </summary>
    public class DeletePropertyTraceCommandValidator : AbstractValidator<DeletePropertyTraceCommand>
    {
        public DeletePropertyTraceCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.");
        }
    }
}
