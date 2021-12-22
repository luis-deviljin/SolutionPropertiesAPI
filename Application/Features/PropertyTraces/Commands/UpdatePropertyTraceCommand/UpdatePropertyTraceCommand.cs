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

namespace Application.Features.PropertyTraces.Commands.UpdatePropertyTraceCommand
{

    public class UpdatePropertyTraceCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public DateTime DateSale { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public double Tax { get; set; }
        public int IdProperty { get; set; }
    }
    /// <summary>
    /// Cllase que actualiza la entidad
    /// </summary>
    public class UpdatePropertyTraceCommandHandler : IRequestHandler<UpdatePropertyTraceCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Domain.Entities.PropertyTrace> _repositoryAsync;
        private readonly IMapper _mapper;
        public UpdatePropertyTraceCommandHandler(IRepositoryAsync<Domain.Entities.PropertyTrace> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(UpdatePropertyTraceCommand request, CancellationToken cancellationToken)
        {
            var propertyTraces = await _repositoryAsync.GetByIdAsync(request.Id);
            if (propertyTraces == null)
            {
                throw new KeyNotFoundException($"Record with ID {request.Id} not found");
            }
            else
            {

                propertyTraces.DateSale = request.DateSale;
                propertyTraces.Name = request.Name;
                propertyTraces.Value = request.Value;
                propertyTraces.Tax = request.Tax;
                propertyTraces.IdProperty = request.IdProperty;
                await _repositoryAsync.UpdateAsync(propertyTraces);

                return new Response<int>(propertyTraces.Id);
            }
        }
    }
}
