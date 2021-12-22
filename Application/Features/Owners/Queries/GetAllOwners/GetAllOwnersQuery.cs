using Application.DTOs;
using MediatR;
using Application.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Application.Specifications;

namespace Application.Features.Owners.Queries.GetAllOwners
{
    public class GetAllOwnersQuery : IRequest<PagedResponse<List<OwnerDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public class GetAllOwnersQueryHandler : IRequestHandler<GetAllOwnersQuery, PagedResponse<List<OwnerDto>>>
        {
            private readonly IRepositoryAsync<Owner> _repositoryAsync;
            private readonly IMapper _mapper;
            public GetAllOwnersQueryHandler(IRepositoryAsync<Owner> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }
            public async Task<PagedResponse<List<OwnerDto>>> Handle(GetAllOwnersQuery request, CancellationToken cancellationToken)
            {
                var owners = await _repositoryAsync.ListAsync(new PagedOwnersSpecification(request.PageSize, request.PageNumber, request.Name, request.Email));
                var ownersDto = _mapper.Map<List<OwnerDto>>(owners);

                return new PagedResponse<List<OwnerDto>>(ownersDto, request.PageNumber, request.PageSize);
            }
        }
    }
}
