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

namespace Application.Features.PropertyImages.Queries.GetAllImageProperties
{

    public class GetAllPropertyImagesQuery : IRequest<PagedResponse<List<PropertyImageDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string File { get; set; }
        public int IdProperty { get; set; }

        public class GetAllPropertyImagesQueryHandler : IRequestHandler<GetAllPropertyImagesQuery, PagedResponse<List<PropertyImageDto>>>
        {
            private readonly IRepositoryAsync<Domain.Entities.PropertyImage> _repositoryAsync;
            private readonly IMapper _mapper;
            public GetAllPropertyImagesQueryHandler(IRepositoryAsync<Domain.Entities.PropertyImage> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }
            public async Task<PagedResponse<List<PropertyImageDto>>> Handle(GetAllPropertyImagesQuery request, CancellationToken cancellationToken)
            {
                var propertyImages = await _repositoryAsync.ListAsync(new PagedPropertyImagesSpecification(request.PageSize, request.PageNumber, request.IdProperty));
                var propertyImagesDto = _mapper.Map<List<PropertyImageDto>>(propertyImages);

                return new PagedResponse<List<PropertyImageDto>>(propertyImagesDto, request.PageNumber, request.PageSize);
            }
        }
    }
}
