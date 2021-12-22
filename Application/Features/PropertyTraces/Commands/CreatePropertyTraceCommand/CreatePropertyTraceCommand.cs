using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.PropertyTrace.Commands.CreatePropertyTraceCommand
{
    /// <summary>
    /// Clase para mappear la entidad PropertyTrace
    /// </summary>
    public class CreatePropertyTraceCommand : IRequest<Response<int>>
    {
        public DateTime DateSale { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public double Tax { get; set; }

        public int IdProperty { get; set; }
    }
    public class CreatePropertyTraceCommandHandler : IRequestHandler<CreatePropertyTraceCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Domain.Entities.PropertyTrace> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreatePropertyTraceCommandHandler(IRepositoryAsync<Domain.Entities.PropertyTrace> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreatePropertyTraceCommand request, CancellationToken cancellationToken)
        {
            var newRecord = _mapper.Map<Domain.Entities.PropertyTrace>(request);
            var data = await _repositoryAsync.AddAsync(newRecord);
            return new Response<int>(data.Id);
        }
    }
}
