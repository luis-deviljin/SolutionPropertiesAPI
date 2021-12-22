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

namespace Application.Features.PropertyTraces.Queries.GetPropertyTraceByIdProperty
{
    /// <summary>
    /// Clase que retorna la busqueda por un ID
    /// </summary>
    public class GetPropertyTracesById : IRequest<Response<PropertyTraceDto>>
    {
        public int Id { get; set; }
        public class GetOwnerByIdQueryHandler : IRequestHandler<GetPropertyTracesById, Response<PropertyTraceDto>>
        {
            private readonly IRepositoryAsync<Domain.Entities.PropertyTrace> _repositoryAsync;
            private readonly IMapper _mapper;
            public GetOwnerByIdQueryHandler(IRepositoryAsync<Domain.Entities.PropertyTrace> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<PropertyTraceDto>> Handle(GetPropertyTracesById request, CancellationToken cancellationToken)
            {
                var propertyTrace = await _repositoryAsync.GetByIdAsync(request.Id);

                if (propertyTrace == null)
                {
                    throw new KeyNotFoundException($"Record with ID {request.Id} not found");
                }
                else
                {
                    var dto = _mapper.Map<PropertyTraceDto>(propertyTrace);

                    return new Response<PropertyTraceDto>(dto);
                }
            }
        }
    }
}
