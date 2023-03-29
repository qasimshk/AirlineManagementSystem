using airline.management.application.Commands.Login;
using airline.management.application.Commands.RefreshToken;
using airline.management.application.Commands.Registration;
using airline.management.application.Models;
using airline.management.application.Queries.GetUserClaims;
using airline.management.sharedkernal.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace airline.management.api.Controllers
{
    public class AccountController : BaseController
    {
        [HttpPost("Register")]
        [Consumes("application/json")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(RegistrationResponseDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Register([FromBody] RegistrationCommand register)
        {
            var result = await _mediator.Send(register);

            return (result.Success == true) ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(RegistrationResponseDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginCommand login)
        {
            var result = await _mediator.Send(login);

            return (result.Success == true) ? Ok(result) : BadRequest(result);
        }

        
        [HttpPost("RefreshToken")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(RegistrationResponseDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand refreshToken)
        {
            var result = await _mediator.Send(refreshToken);

            return (result.Success == true) ? Ok(result) : BadRequest(result);
        }
                
        [HttpGet("UserClaims")]
        [Authorize]
        [ProducesResponseType(typeof(UserClaimsDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UserClaims()
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            return (!string.IsNullOrEmpty(token)) ? Ok(await _mediator.Send(new GetUserClaimsQuery(token))) : NotFound("Token not found");
        }
    }
}
