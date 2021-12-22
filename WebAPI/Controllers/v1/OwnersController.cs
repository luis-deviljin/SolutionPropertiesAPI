using Application.Features.Owners.Commands.CreateOwnerCommand;
using Application.Features.Owners.Commands.DeleteOwnerCommand;
using Application.Features.Owners.Commands.UpdateOwnerCommand;
using Application.Features.Owners.Queries.GetAllOwners;
using Application.Features.Owners.Queries.GetOwnerById;
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
    public class OwnersController : BaseApiController
    {
        //POST API/CONTROLLER
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateOwnerCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //PUT API/CONTROLLER
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(int id, UpdateOwnerCommand command)
        {
            if(id != command.Id)
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
            return Ok(await Mediator.Send(new DeleteOwnerCommand { Id= id}));
        }

        //GET API/CONTROLLER/id
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetOwnerByIdQuery { Id = id}));
        }

        //GET API/CONTROLLER/
        [HttpGet()]
        [Authorize]
        public async Task<IActionResult> Get([FromQuery] GetAllOwnersParameters filter)
        {
            return Ok(await Mediator.Send(new GetAllOwnersQuery 
            { 
                PageNumber = filter.PageNumber, 
                PageSize = filter.PageSize, 
                Email = filter.Email, 
                Name= filter.Name 
            }));
        }

    }
}
