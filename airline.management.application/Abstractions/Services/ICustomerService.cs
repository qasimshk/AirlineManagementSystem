using airline.management.domain.Events;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace airline.management.application.Abstractions.Services
{
    public interface ICustomerService
    {
        Task<CustomerDetailsEvent> GetCustomerDetails(Guid customerReference, CancellationToken cancellationToken);
    }
}
