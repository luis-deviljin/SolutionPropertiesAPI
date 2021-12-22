using Application.Interfaces;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.PropertyImages.Commands.DeletePropertyImageCommand
{

    public class DeletePropertyImageCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    /// <summary>
    /// clase para hacer el borrado
    /// </summary>
    public class DeletePropertyImageCommandHandler : IRequestHandler<DeletePropertyImageCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Domain.Entities.PropertyImage> _repositoryAsync;

        public DeletePropertyImageCommandHandler(IRepositoryAsync<Domain.Entities.PropertyImage> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }
        public async Task<Response<int>> Handle(DeletePropertyImageCommand request, CancellationToken cancellationToken)
        {
            var propertyImage = await _repositoryAsync.GetByIdAsync(request.Id);
            if (propertyImage == null)
            {
                throw new KeyNotFoundException($"Record with ID {request.Id} not found");
            }
            else
            {
                await _repositoryAsync.DeleteAsync(propertyImage);

                return new Response<int>(propertyImage.Id);
            }
        }
    }
}
