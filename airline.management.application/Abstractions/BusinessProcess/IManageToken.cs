using airline.management.application.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace airline.management.application.Abstractions.BusinessProcess
{
    public interface IManageToken
    {
        Task<RegistrationResponseDto> GenerateJwtToken(IdentityUser user);

        Task<RegistrationResponseDto> VerifyAndGenerateToken(string token, string refreshToken);

        UserClaimsDto GetUserClaims(string token);
    }
}
