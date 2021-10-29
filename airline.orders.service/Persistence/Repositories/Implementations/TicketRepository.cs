using airline.management.sharedkernal.Abstractions;
using airline.orders.service.Entities;
using airline.orders.service.Persistence.Context;
using airline.orders.service.Persistence.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace airline.orders.service.Persistence.Repositories.Implementations
{
    public class TicketRepository : ITicketRepository
    {
        private readonly OrderDbContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public TicketRepository(OrderDbContext context)
        {
            _context = context;
        }

        public void Add(Tickets ticket) => _context.Add(ticket);

        public void Update(Tickets ticket) => _context.Update(ticket);

        public async Task<IEnumerable<Tickets>> FindByConditionAsync(Expression<Func<Tickets, bool>> expression)
        {
            return await _context.Tickets.Where(expression).ToListAsync();
        }
    }
}
