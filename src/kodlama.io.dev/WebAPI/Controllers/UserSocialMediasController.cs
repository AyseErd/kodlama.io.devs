using Application.Features.LanguageFrameworks.Commands.DeleteLanguageFramework;
using Application.Features.LanguageFrameworks.Dtos;
using Application.Features.ProgrammingLanguages.Commands;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.UserSocialMediaAddresses.Commands.CreateSocialMediaAddress;
using Application.Features.UserSocialMediaAddresses.Commands.DeleteSocialMediaAddress;
using Application.Features.UserSocialMediaAddresses.Commands.UpdateSocialMediaAddress;
using Application.Features.UserSocialMediaAddresses.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSocialMediasController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSocialMediaAddressCommand createSocialMediaAddressCommand)
        {
            CreatedSocialMediaAddressDto result = await Mediator.Send(createSocialMediaAddressCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Add([FromBody] UpdateUserMediaAddressCommand updateUserMediaAddressCommand)
        {
            UpdatedUserSocialMediaAddressDto result = await Mediator.Send(updateUserMediaAddressCommand);
            return Created("", result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserSocialMediaAddressCommand deleteUserSocialMediaAddressCommand)
        {
            DeletedUserSocialMediaAddressDto result = await Mediator.Send(deleteUserSocialMediaAddressCommand);
            return Ok(result);
        }
    }
}
