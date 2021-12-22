using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.PropertyImages.Queries.GetPropertyImageByIdProperty
{

     /// <summary>
    /// Clase que retorna la busqueda por un ID
    /// </summary>
    public class GetPropertyImagesById : IRequest<Response<PropertyImageDto>>
    {
        public int Id { get; set; }
        public class GetOwnerByIdQueryHandler : IRequestHandler<GetPropertyImagesById, Response<PropertyImageDto>>
        {
            private readonly IRepositoryAsync<Domain.Entities.PropertyImage> _repositoryAsync;
            private readonly IMapper _mapper;
            public GetOwnerByIdQueryHandler(IRepositoryAsync<Domain.Entities.PropertyImage> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<PropertyImageDto>> Handle(GetPropertyImagesById request, CancellationToken cancellationToken)
            {
                var propertyImage = await _repositoryAsync.GetByIdAsync(request.Id);

                if (propertyImage == null)
                {
                    throw new KeyNotFoundException($"Record with ID {request.Id} not found");
                }
                else
                {
                    var dto = _mapper.Map<PropertyImageDto>(propertyImage);

                    return new Response<PropertyImageDto>(dto);
                }
            }
        }
    }
}
