using airline.customers.service.Entities;
using airline.customers.service.Persistence.Context;
using airline.customers.service.Persistence.Repositories.Abstractions;
using airline.management.sharedkernal.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace airline.customers.service.Persistence.Repositories.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public CustomerRepository(CustomerDbContext context)
        {
            _context = context;
        }

        public void Add(Customers customer) => _context.Add(customer);

        public void Update(Customers customer) => _context.Update(customer);

        public async Task<IEnumerable<Customers>> FindByConditionAsync(Expression<Func<Customers, bool>> expression)
        {
            return await _context.Customers.Where(expression).ToListAsync();
        }
    }
}
