using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Properties.Commands.CreatePropertyCommand
{
    /// <summary>
    /// Clase para mappear la entidad Property
    /// </summary>
    public class CreatePropertyCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double Price { get; set; }
        public string CodInternal { get; set; }
        public int Year { get; set; }
        public int IdOwner { get; set; }
    }
    public class CreatePropertyCommandHandler : IRequestHandler<CreatePropertyCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Property> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreatePropertyCommandHandler(IRepositoryAsync<Property> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }


        public async Task<Response<int>> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
        {
            var newRecord = _mapper.Map<Property>(request);
            var data = await _repositoryAsync.AddAsync(newRecord);
            return new Response<int>(data.Id);
        }
    }
}
