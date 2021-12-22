using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Owners.Commands.DeleteOwnerCommand
{
    public class DeleteOwnerCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    /// <summary>
    /// clase para hacer el borrado
    /// </summary>
    public class DeleteOwnerCommandHandler : IRequestHandler<DeleteOwnerCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Owner> _repositoryAsync;

        public DeleteOwnerCommandHandler(IRepositoryAsync<Owner> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }
        public async Task<Response<int>> Handle(DeleteOwnerCommand request, CancellationToken cancellationToken)
        {
            var owner = await _repositoryAsync.GetByIdAsync(request.Id);
            if (owner == null)
            {
                throw new KeyNotFoundException($"Record with ID {request.Id} not found");
            }
            else
            {
               await _repositoryAsync.DeleteAsync(owner);

                return new Response<int>(owner.Id);
            }
        }
    }
}
