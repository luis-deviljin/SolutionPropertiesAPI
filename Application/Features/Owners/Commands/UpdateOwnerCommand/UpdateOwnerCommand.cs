using Application.Exceptions;
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

namespace Application.Features.Owners.Commands.UpdateOwnerCommand
{
    public class UpdateOwnerCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string NumberofContact { get; set; }
        public bool Enable { get; set; }
    }
    /// <summary>
    /// Cllase que actualiza la entidad
    /// </summary>
    public class UpdateOwnerCommandHandler : IRequestHandler<UpdateOwnerCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Owner> _repositoryAsync;
        private readonly IMapper _mapper;
        public UpdateOwnerCommandHandler(IRepositoryAsync<Owner> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(UpdateOwnerCommand request, CancellationToken cancellationToken)
        {
            var owner = await _repositoryAsync.GetByIdAsync(request.Id);
            if(owner == null)
            {
                throw new KeyNotFoundException($"Record with ID {request.Id} not found");
            }
            else
            {
                owner.Name = request.Name;
                owner.Address = request.Address;
                owner.Photo = request.Photo;
                owner.Birthday = request.Birthday;
                owner.Email = request.Email;
                owner.NumberofContact = request.NumberofContact;
                await _repositoryAsync.UpdateAsync(owner);

                return new Response<int>(owner.Id);
            }
        }
    }
}
