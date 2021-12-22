using Application.DTOs;
using Application.Interfaces;
using Application.Specifications;
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

namespace Application.Features.Properties.Queries.GetAllProperties
{
    public class GetAllPropertiesQuery : IRequest<PagedResponse<List<PropertyDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Name { get; set; }
        public string Addres { get; set; }
        public double Price { get; set; }
        public string CodInternal { get; set; }
        public int Year { get; set; }

        public class GetAllPropertiesQueryHandler : IRequestHandler<GetAllPropertiesQuery, PagedResponse<List<PropertyDto>>>
        {
            private readonly IRepositoryAsync<Property> _repositoryAsync;
            private readonly IMapper _mapper;
            public GetAllPropertiesQueryHandler(IRepositoryAsync<Property> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }
            public async Task<PagedResponse<List<PropertyDto>>> Handle(GetAllPropertiesQuery request, CancellationToken cancellationToken)
            {
                var property = await _repositoryAsync.ListAsync(new PagedPropertiesSpecification(request.PageSize, request.PageNumber, request.Name, request.Addres, request.Price, request.CodInternal, request.Year));
                var propertiesDto = _mapper.Map<List<PropertyDto>>(property);

                return new PagedResponse<List<PropertyDto>>(propertiesDto, request.PageNumber, request.PageSize);
            }
        }
    }
}
