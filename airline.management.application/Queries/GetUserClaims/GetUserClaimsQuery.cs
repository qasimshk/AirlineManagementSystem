using airline.management.application.Models;
using MediatR;

namespace airline.management.application.Queries.GetUserClaims
{
    public class GetUserClaimsQuery : IRequest<UserClaimsDto>
    {
        public GetUserClaimsQuery(string token)
        {
            Token = token;
        }
        public string Token { get; init; }
    }
}
