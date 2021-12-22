using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Owners.Commands.DeleteOwnerCommand
{    
    /// <summary>
     /// Clase que valida la entidad al ser borrada
     /// </summary>
    public class DeleteOwnerCommandValidator : AbstractValidator<DeleteOwnerCommand>
    {   
        public DeleteOwnerCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.");
        }
    }
}
