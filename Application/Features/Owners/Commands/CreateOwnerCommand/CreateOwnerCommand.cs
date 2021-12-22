using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Owners.Commands.CreateOwnerCommand
{
    /// <summary>
    /// Clase para mappear la entidad Owner
    /// </summary>
    public class CreateOwnerCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string NumberofContact { get; set; }
    }
    public class CreateOwnerCommandHandler : IRequestHandler<CreateOwnerCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Owner> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateOwnerCommandHandler(IRepositoryAsync<Owner> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        
        public async Task<Response<int>> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
        {
            var newRecord = _mapper.Map<Owner>(request);
            var data = await _repositoryAsync.AddAsync(newRecord);
            return new Response<int>(data.Id);
        }
    }
}
