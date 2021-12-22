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

namespace Application.Features.Owners.Queries.GetOwnerById
{
    /// <summary>
    /// Clase que retorna la busqueda por un ID
    /// </summary>
    public class GetOwnerByIdQuery : IRequest<Response<OwnerDto>>
    {
        public int Id { get; set; }
        public class GetOwnerByIdQueryHandler : IRequestHandler<GetOwnerByIdQuery, Response<OwnerDto>>
        {
            private readonly IRepositoryAsync<Owner> _repositoryAsync;
            private readonly IMapper _mapper;
            public GetOwnerByIdQueryHandler(IRepositoryAsync<Owner> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<OwnerDto>> Handle(GetOwnerByIdQuery request, CancellationToken cancellationToken)
            {
                var owner = await _repositoryAsync.GetByIdAsync(request.Id);

                if (owner == null)
                {
                    throw new KeyNotFoundException($"Record with ID {request.Id} not found");
                }
                else
                {
                    var dto = _mapper.Map<OwnerDto>(owner);

                    return new Response<OwnerDto>(dto);
                }
            }
        }
    }
}
