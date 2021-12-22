using Application.Features.PropertyImage.Commands.CreatePropertyImageCommand;
using Application.Features.PropertyImages.Commands.DeletePropertyImageCommand;
using Application.Features.PropertyImages.Commands.UpdatePropertyImageCommand;
using Application.Features.PropertyImages.Queries.GetAllImageProperties;
using Application.Features.PropertyImages.Queries.GetPropertyImageByIdProperty;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    /// <summary>
    /// Controlador que se encarga de enrutar.
    /// </summary>
    [ApiVersion("1.0")]
    public class PropertyImagesController : BaseApiController
    {
        public static IWebHostEnvironment _environment;
        public PropertyImagesController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public class FileUpload
        {
            public IFormFile file
            {
                get; set;
            }
        }
        [HttpPost("{idproperty}")]
        public async Task<IActionResult> Post(int idproperty, [FromForm] FileUpload objfile)
        {
            if (!Directory.Exists(_environment.ContentRootPath + "\\images\\"))
            {
                Directory.CreateDirectory(_environment.ContentRootPath + "\\images\\");
            }
            using (FileStream fileStream = System.IO.File.Create(_environment.ContentRootPath + "\\images\\" + objfile.file.FileName))
            {
                objfile.file.CopyTo(fileStream);
                fileStream.Flush();
            }
            CreatePropertyImageCommand command = new CreatePropertyImageCommand();
            command.IdProperty = idproperty;
            command.File = _environment.ContentRootPath + "\\images\\" + objfile.file.FileName;
            command.Enable = true;         
            return Ok(await Mediator.Send(command));
        }




        /*
        //POST API/CONTROLLER
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreatePropertyImageCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        */


        //PUT API/CONTROLLER
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(int id, UpdatePropertyImageCommand command)
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
            return Ok(await Mediator.Send(new DeletePropertyImageCommand { Id = id }));
        }

        //GET API/CONTROLLER/id
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetPropertyImagesById { Id = id }));
        }

        //GET API/CONTROLLER/
        [HttpGet()]
        [Authorize]
        public async Task<IActionResult> Get([FromQuery] GetAllPropertyImagesParameters filter)
        {
            return Ok(await Mediator.Send(new GetAllPropertyImagesQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                File = filter.File,
                IdProperty = filter.IdProperty
            }));
        }

    }
}
