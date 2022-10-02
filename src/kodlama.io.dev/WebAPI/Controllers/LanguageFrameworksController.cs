using Application.Features.LanguageFrameworks.Commands.CreateLanguageFramework;
using Application.Features.LanguageFrameworks.Commands.DeleteLanguageFramework;
using Application.Features.LanguageFrameworks.Commands.UpdateLanguageFramework;
using Application.Features.LanguageFrameworks.Dtos;
using Application.Features.LanguageFrameworks.Models;
using Application.Features.LanguageFrameworks.Queries.GetListLanguageFramework;
using Application.Features.ProgrammingLanguages.Commands;
using Application.Features.ProgrammingLanguages.Dtos;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.Migrations;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageFrameworksController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListLanguageFrameworkQuery getListModelQuery = new GetListLanguageFrameworkQuery { PageRequest = pageRequest };
            ListLanguageFrameworkModel result = await Mediator.Send(getListModelQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateLanguageFrameworkCommand createLanguageFrameworkCommand)
        {
            CreatedLanguageFrameworkDto result = await Mediator.Send(createLanguageFrameworkCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateLanguageFrameworkCommand updateLanguageFramework)
        {
            UpdatedLanguageFrameworkDto result = await Mediator.Send(updateLanguageFramework);
            return Created("", result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteLanguageFrameworkCommand deleteLanguageFrameworkCommand)
        {
            DeletedLanguageFrameworkDto result = await Mediator.Send(deleteLanguageFrameworkCommand);
            return Ok(result);
        }
    }
}
