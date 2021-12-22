using Application.Interfaces;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.PropertyTraces.Commands.DeletePropertyTraceCommand
{

    public class DeletePropertyTraceCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    /// <summary>
    /// clase para hacer el borrado
    /// </summary>
    public class DeletePropertyTraceCommandHandler : IRequestHandler<DeletePropertyTraceCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Domain.Entities.PropertyTrace> _repositoryAsync;

        public DeletePropertyTraceCommandHandler(IRepositoryAsync<Domain.Entities.PropertyTrace> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }
        public async Task<Response<int>> Handle(DeletePropertyTraceCommand request, CancellationToken cancellationToken)
        {
            var propertyTrace = await _repositoryAsync.GetByIdAsync(request.Id);
            if (propertyTrace == null)
            {
                throw new KeyNotFoundException($"Record with ID {request.Id} not found");
            }
            else
            {
                await _repositoryAsync.DeleteAsync(propertyTrace);

                return new Response<int>(propertyTrace.Id);
            }
        }
    }
}
