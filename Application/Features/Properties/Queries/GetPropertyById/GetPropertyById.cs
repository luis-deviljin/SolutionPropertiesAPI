using Application.DTOs;
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

namespace Application.Features.Properties.Queries.GetPropertyByCodInternal
{
    /// <summary>
    /// Clase que retorna la busqueda por un ID
    /// </summary>
    public class GetPropertyById : IRequest<Response<PropertyDto>>
    {
        public int Id { get; set; }
        public class GetPropertyByCodInternalHandler : IRequestHandler<GetPropertyById, Response<PropertyDto>>
        {
            private readonly IRepositoryAsync<Property> _repositoryAsync;
            private readonly IMapper _mapper;
            public GetPropertyByCodInternalHandler(IRepositoryAsync<Property> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<PropertyDto>> Handle(GetPropertyById request, CancellationToken cancellationToken)
            {
                var property = await _repositoryAsync.GetByIdAsync(request.Id);

                if (property == null)
                {
                    throw new KeyNotFoundException($"Record with ID {request.Id} not found");
                }
                else
                {
                    var dto = _mapper.Map<PropertyDto>(property);

                    return new Response<PropertyDto>(dto);
                }
            }
        }
    }
}
