using System;

namespace airline.management.abstractions.Base
{
    public interface IBaseEvent
    {
        Guid CorrelationId { get; set; }
    }
}
