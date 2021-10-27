using airline.management.abstractions.Base;

namespace airline.management.abstractions.Failed
{
    public interface IFailedEvent : IBaseEvent
    {
        string ConsumerName { get; set; }
        string ErrorMessage { get; set; }
    }
}
