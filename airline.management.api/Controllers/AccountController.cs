using airline.management.application.Commands.Login;
using airline.management.application.Commands.RefreshToken;
using airline.management.application.Commands.Registration;
using airline.management.application.Models;
using airline.management.sharedkernal.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace airline.management.api.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        [HttpPost("Register")]
        [ProducesResponseType(typeof(RegistrationResponseDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Register([FromBody] RegistrationCommand register)
        {
            var result = await _mediator.Send(register);

            return (result.Success == true) ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(RegistrationResponseDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginCommand login)
        {
            var result = await _mediator.Send(login);

            return (result.Success == true) ? Ok(result) : BadRequest(result);
        }

        [HttpPost("RefreshToken")]
        [ProducesResponseType(typeof(RegistrationResponseDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand refreshToken)
        {
            var result = await _mediator.Send(refreshToken);

            return (result.Success == true) ? Ok(result) : BadRequest(result);
        }
    }
}
