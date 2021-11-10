using airline.management.application.Abstractions.BusinessProcess;
using airline.management.application.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace airline.management.application.Commands.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, RegistrationResponseDto>
    {
        private readonly IManageToken _manageToken;

        public RefreshTokenCommandHandler(IManageToken manageToken)
        {
            _manageToken = manageToken;
        }

        public async Task<RegistrationResponseDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {            
            var result = await _manageToken.VerifyAndGenerateToken(request.Token, request.RefreshToken);

            if (result == null)
            {
                return new RegistrationResponseDto()
                {
                    Errors = new List<string>() {
                            
                        },
                    Success = false
                };
            }

            return result;
        }
    }
}
