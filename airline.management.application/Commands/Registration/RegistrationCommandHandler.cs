using airline.management.application.Abstractions.BusinessProcess;
using airline.management.application.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace airline.management.application.Commands.Registration
{
    public class RegistrationCommandHandler : IRequestHandler<RegistrationCommand, RegistrationResponseDto>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IManageToken _manageToken;

        public RegistrationCommandHandler(UserManager<IdentityUser> userManager, IManageToken manageToken)
        {
            _userManager = userManager;
            _manageToken = manageToken;
        }

        public async Task<RegistrationResponseDto> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            // We can utilise the model
            var existingUser = await _userManager.FindByEmailAsync(request.Email);

            if (existingUser != null)
            {
                new RegistrationResponseDto()
                {
                    Errors = new List<string>() {
                                "Email already in use"
                            },
                    Success = false
                };
            }

            var newUser = new IdentityUser() { Email = request.Email, UserName = request.Email };
            var isCreated = await _userManager.CreateAsync(newUser, request.Password);
            if (isCreated.Succeeded)
            {
                var jwtToken = await _manageToken.GenerateJwtToken(newUser);

                return jwtToken;
            }
            else
            {
                return new RegistrationResponseDto()
                {
                    Errors = isCreated.Errors.Select(x => x.Description).ToList(),
                    Success = false
                };
            }
        }
    }
}
