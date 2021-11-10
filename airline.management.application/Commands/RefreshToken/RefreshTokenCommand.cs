using airline.management.application.Models;
using MediatR;

namespace airline.management.application.Commands.RefreshToken
{
    public class RefreshTokenCommand : IRequest<RegistrationResponseDto>
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
