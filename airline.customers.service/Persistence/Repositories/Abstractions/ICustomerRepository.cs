using airline.customers.service.Entities;
using airline.management.sharedkernal.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace airline.customers.service.Persistence.Repositories.Abstractions
{
    public interface ICustomerRepository : IRepository<Customers>
    {
        Task<IEnumerable<Customers>> FindByConditionAsync(Expression<Func<Customers, bool>> expression);

        void Add(Customers customer);

        void Update(Customers customer);
    }
}
