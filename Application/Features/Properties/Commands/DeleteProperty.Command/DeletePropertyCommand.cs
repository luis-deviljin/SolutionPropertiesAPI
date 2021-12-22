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

namespace Application.Features.Properties.Commands.DeleteProperty.Command
{
    public class DeletePropertyCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    /// <summary>
    /// clase para hacer el borrado
    /// </summary>
    public class DeletePropertyCommandHandler : IRequestHandler<DeletePropertyCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Property> _repositoryAsync;

        public DeletePropertyCommandHandler(IRepositoryAsync<Property> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }
        public async Task<Response<int>> Handle(DeletePropertyCommand request, CancellationToken cancellationToken)
        {
            var property = await _repositoryAsync.GetByIdAsync(request.Id);
            if (property == null)
            {
                throw new KeyNotFoundException($"Record with ID {request.Id} not found");
            }
            else
            {
                await _repositoryAsync.DeleteAsync(property);

                return new Response<int>(property.Id);
            }
        }
    }
}
