using airline.management.application.Abstractions.BusinessProcess;
using airline.management.application.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace airline.management.application.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, RegistrationResponseDto>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IManageToken _manageToken;

        public LoginCommandHandler(UserManager<IdentityUser> userManager, IManageToken manageToken)
        {
            _userManager = userManager;
            _manageToken = manageToken;
        }

        public async Task<RegistrationResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.Email);

            if (existingUser == null)
            {
                return new RegistrationResponseDto()
                {
                    Errors = new List<string>() {
                                "Invalid login request"
                            },
                    Success = false
                };
            }

            var isCorrect = await _userManager.CheckPasswordAsync(existingUser, request.Password);

            if (!isCorrect)
            {
                return new RegistrationResponseDto()
                {
                    Errors = new List<string>() {
                                "Invalid login request"
                            },
                    Success = false
                };
            }

            var jwtToken = await _manageToken.GenerateJwtToken(existingUser);

            return jwtToken;
        }
    }
}
