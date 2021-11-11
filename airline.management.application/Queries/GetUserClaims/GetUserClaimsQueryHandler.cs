using airline.management.application.Abstractions.BusinessProcess;
using airline.management.application.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace airline.management.application.Queries.GetUserClaims
{
    public class GetUserClaimsQueryHandler : IRequestHandler<GetUserClaimsQuery, UserClaimsDto>
    {
        private readonly IManageToken _manageToken;

        public GetUserClaimsQueryHandler(IManageToken manageToken)
        {
            _manageToken = manageToken;
        }

        public Task<UserClaimsDto> Handle(GetUserClaimsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_manageToken.GetUserClaims(request.Token));
        }
    }
}
