using Application.Features.Properties.Commands.CreatePropertyCommand;
using Application.Features.Properties.Commands.DeleteProperty.Command;
using Application.Features.Properties.Commands.UpdatePropertyCommand;
using Application.Features.Properties.Queries.GetAllProperties;
using Application.Features.Properties.Queries.GetPropertyByCodInternal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    /// <summary>
    /// Controlador que se encarga de enrutar.
    /// </summary>
    [ApiVersion("1.0")]
    public class PropertiesController : BaseApiController
    {
        //POST API/CONTROLLER
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreatePropertyCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //PUT API/CONTROLLER
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(int id, UpdatePropertyCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        //DELETE API/CONTROLLER
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeletePropertyCommand { Id = id }));
        }

        //GET API/CONTROLLER/id
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetPropertyById{ Id = id }));
        }

        //GET API/CONTROLLER/
        [HttpGet()]
        [Authorize]
        public async Task<IActionResult> Get([FromQuery] GetAllPropertiesParameters filter)
        {
            return Ok(await Mediator.Send(new GetAllPropertiesQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                Name = filter.Name,
                Addres = filter.Addres,
                Price = filter.Price,
                CodInternal = filter.CodInternal,
                Year = filter.Year
            }));
        }

    }
}
