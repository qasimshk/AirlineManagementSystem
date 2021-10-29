using airline.management.domain.Events;
using System.Threading.Tasks;

namespace airline.management.application.Abstractions.Services
{
    public interface IOrderService
    {
        Task<TicketDetailEvent> GetTicketDetails(string ticketNumber, string orderNumber);
    }
}
