using airline.management.abstractions.Base;
using System;

namespace airline.management.abstractions.Customers
{
    public interface ICustomerDetailRequest 
    {
        public Guid CustomerReferrence { get; set; }
    }
}
