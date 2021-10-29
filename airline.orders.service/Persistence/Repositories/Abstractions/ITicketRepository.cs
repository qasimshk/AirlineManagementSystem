using airline.management.sharedkernal.Abstractions;
using airline.orders.service.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace airline.orders.service.Persistence.Repositories.Abstractions
{
    public interface ITicketRepository : IRepository<Tickets>
    {
        Task<IEnumerable<Tickets>> FindByConditionAsync(Expression<Func<Tickets, bool>> expression);

        void Add(Tickets tickets);

        void Update(Tickets tickets);
    }
}
