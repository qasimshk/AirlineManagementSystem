using airline.management.sharedkernal.Abstractions;
using airline.payment.service.Entities;
using airline.payment.service.Persistence.Context;
using airline.payment.service.Persistence.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace airline.payment.service.Persistence.Repositories.Implementations
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly PaymentDbContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public TransactionRepository(PaymentDbContext context)
        {
            _context = context;
        }

        public void Add(Transactions transactions) => _context.Add(transactions);

        public void Update(Transactions transactions) => _context.Update(transactions);

        public async Task<IEnumerable<Transactions>> FindByConditionAsync(Expression<Func<Transactions, bool>> expression)
        {
            return await _context.Transactions.Where(expression).ToListAsync();
        }
    }
}
