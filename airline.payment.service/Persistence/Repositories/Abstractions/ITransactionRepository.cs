using airline.management.sharedkernal.Abstractions;
using airline.payment.service.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace airline.payment.service.Persistence.Repositories.Abstractions
{
    public interface ITransactionRepository : IRepository<Transactions>
    {
        Task<IEnumerable<Transactions>> FindByConditionAsync(Expression<Func<Transactions, bool>> expression);

        void Add(Transactions transactions);

        void Update(Transactions transactions);
    }
}
