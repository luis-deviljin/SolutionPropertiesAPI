using Application.DTOs;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.PropertyTraces.Queries.GetAllPopertiesTrace
{
    public class GetAllPropertyTracesQuery : IRequest<PagedResponse<List<PropertyTraceDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public DateTime date { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public double Tax { get; set; }

        public class GetAllPropertyTracesQueryHandler : IRequestHandler<GetAllPropertyTracesQuery, PagedResponse<List<PropertyTraceDto>>>
        {
            private readonly IRepositoryAsync<Domain.Entities.PropertyTrace> _repositoryAsync;
            private readonly IMapper _mapper;
            public GetAllPropertyTracesQueryHandler(IRepositoryAsync<Domain.Entities.PropertyTrace> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }
            public async Task<PagedResponse<List<PropertyTraceDto>>> Handle(GetAllPropertyTracesQuery request, CancellationToken cancellationToken)
            {
                var propertyTraces = await _repositoryAsync.ListAsync(new PagedPropertyTracesSpecification(request.PageSize, request.PageNumber, request.date.ToString(), request.Name, request.Value, request.Tax));
                var propertyTracesDto = _mapper.Map<List<PropertyTraceDto>>(propertyTraces);

                return new PagedResponse<List<PropertyTraceDto>>(propertyTracesDto, request.PageNumber, request.PageSize);
            }
        }
    }
}
