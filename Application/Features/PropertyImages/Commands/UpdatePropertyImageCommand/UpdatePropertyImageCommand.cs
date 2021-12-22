using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.PropertyImages.Commands.UpdatePropertyImageCommand
{

    public class UpdatePropertyImageCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string File { get; set; }
        public bool? Enable { get; set; }
        public int IdProperty { get; set; }
    }
    /// <summary>
    /// Cllase que actualiza la entidad
    /// </summary>
    public class UpdatePropertyImageCommandHandler : IRequestHandler<UpdatePropertyImageCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Domain.Entities.PropertyImage> _repositoryAsync;
        private readonly IMapper _mapper;
        public UpdatePropertyImageCommandHandler(IRepositoryAsync<Domain.Entities.PropertyImage> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(UpdatePropertyImageCommand request, CancellationToken cancellationToken)
        {
            var propertyImage = await _repositoryAsync.GetByIdAsync(request.Id);
            if (propertyImage == null)
            {
                throw new KeyNotFoundException($"Record with ID {request.Id} not found");
            }
            else
            {
                propertyImage.File = request.File;
                propertyImage.Enable = request.Enable;
                propertyImage.IdProperty = request.IdProperty;
                await _repositoryAsync.UpdateAsync(propertyImage);

                return new Response<int>(propertyImage.Id);
            }
        }
    }
}
