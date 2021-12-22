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

namespace Application.Features.Properties.Commands.UpdatePropertyCommand
{

    public class UpdatePropertyCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Price { get; set; }
        public string CodInternal { get; set; }
        public int Year { get; set; }
        public int IdOwner { get; set; }
    }
    /// <summary>
    /// Cllase que actualiza la entidad
    /// </summary>
    public class UpdateOwnerCommandHandler : IRequestHandler<UpdatePropertyCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Property> _repositoryAsync;
        private readonly IMapper _mapper;
        public UpdateOwnerCommandHandler(IRepositoryAsync<Property> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(UpdatePropertyCommand request, CancellationToken cancellationToken)
        {
            var property = await _repositoryAsync.GetByIdAsync(request.Id);
            if (property == null)
            {
                throw new KeyNotFoundException($"Record with ID {request.Id} not found");
            }
            else
            {
                property.Name = request.Name;
                property.Address = request.Address;
                property.Price = request.Price;
                property.CodInternal = request.CodInternal;
                property.Year = request.Year;
                property.IdOwner = request.IdOwner;
                await _repositoryAsync.UpdateAsync(property);

                return new Response<int>(property.Id);
            }
        }
    }
}
