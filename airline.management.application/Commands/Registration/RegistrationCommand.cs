using airline.management.application.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace airline.management.application.Commands.Registration
{
    public class RegistrationCommand : IRequest<RegistrationResponseDto>
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
