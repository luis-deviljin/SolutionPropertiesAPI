using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.PropertyImage.Commands.CreatePropertyImageCommand
{
    /// <summary>
    /// Clase para mappear la entidad PropertyImage
    /// </summary>
    public class CreatePropertyImageCommand : IRequest<Response<int>>
    {
        public string File { get; set; }
        public bool? Enable { get; set; }
        public int IdProperty { get; set; }
    }
    public class CreatePropertyImageCommandHandler : IRequestHandler<CreatePropertyImageCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Domain.Entities.PropertyImage> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreatePropertyImageCommandHandler(IRepositoryAsync<Domain.Entities.PropertyImage> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }


        public async Task<Response<int>> Handle(CreatePropertyImageCommand request, CancellationToken cancellationToken)
        {
            var newRecord = _mapper.Map<Domain.Entities.PropertyImage>(request);
            var data = await _repositoryAsync.AddAsync(newRecord);
            return new Response<int>(data.Id);
        }
    }
}