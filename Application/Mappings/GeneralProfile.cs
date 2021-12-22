using Application.DTOs;
using Application.Features.Owners.Commands.CreateOwnerCommand;
using Application.Features.Properties.Commands.CreatePropertyCommand;
using Application.Features.PropertyImage.Commands.CreatePropertyImageCommand;
using Application.Features.PropertyTrace.Commands.CreatePropertyTraceCommand;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    /// <summary>
    /// Clase que se utiliza para mapear todas las entidades
    /// </summary>
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region DTOs
            CreateMap<Owner, OwnerDto>();
            CreateMap<Property, PropertyDto>();
            CreateMap<PropertyImage, PropertyImage>();
            CreateMap<PropertyTrace, PropertyTrace>();
            #endregion

            #region Commands
            CreateMap<CreateOwnerCommand, Owner>();
            CreateMap<CreatePropertyCommand, Property>();
            CreateMap<CreatePropertyImageCommand, PropertyImage>();
            CreateMap<CreatePropertyTraceCommand, PropertyTrace>();
            #endregion
        }
    }
}
