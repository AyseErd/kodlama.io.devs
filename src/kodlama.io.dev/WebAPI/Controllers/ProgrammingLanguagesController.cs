using Application.Features.Commands;
using Application.Features.Dtos;
using Application.Features.Models;
using Application.Features.Queries.GetByIdProgLanguage;
using Application.Features.Queries.GetListProgLanguage;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgLanguageCommand createProgLanguageCommand)
        {
            CreatedProgLanguageDto result = await Mediator.Send(createProgLanguageCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgLanguageQuery getListProgLanguageQuery= new() { PageRequest = pageRequest };
            ProgLanguageListModel result = await Mediator.Send(getListProgLanguageQuery);
            return Ok(result);
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgLanguageQuery getByIdProgLanguageQuery)
        {
            ProgLanguageGetByIdDto result = await Mediator.Send(getByIdProgLanguageQuery);
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProgLanguageCommand updateProgLanguageCommand)
        {
            UpdatedProgLanguageDto result = await Mediator.Send(updateProgLanguageCommand);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProgLanguageCommand deleteProgLanguageCommand)
        {
            DeletedProgLanguageDto result = await Mediator.Send(deleteProgLanguageCommand);
            return Ok(result);
        }
    }
}
