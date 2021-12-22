using Application.Features.Properties.Queries.GetPropertyByCodInternal;
using Application.Features.PropertyTrace.Commands.CreatePropertyTraceCommand;
using Application.Features.PropertyTraces.Commands.DeletePropertyTraceCommand;
using Application.Features.PropertyTraces.Commands.UpdatePropertyTraceCommand;
using Application.Features.PropertyTraces.Queries.GetAllPopertiesTrace;
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
    public class PropertyTracesController : BaseApiController
    {
        //POST API/CONTROLLER
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreatePropertyTraceCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //PUT API/CONTROLLER
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(int id, UpdatePropertyTraceCommand command)
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
            return Ok(await Mediator.Send(new DeletePropertyTraceCommand { Id = id }));
        }

        //GET API/CONTROLLER/id
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetPropertyById { Id = id }));
        }

        //GET API/CONTROLLER/
        [HttpGet()]
        [Authorize]
        public async Task<IActionResult> Get([FromQuery] GetAllPropertyTracesParameters filter)
        {
            return Ok(await Mediator.Send(new GetAllPropertyTracesQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                date = filter.date,
                Name = filter.Name,
                Value = filter.Value,
                Tax = filter.Tax
            }));
        }

    }
}
