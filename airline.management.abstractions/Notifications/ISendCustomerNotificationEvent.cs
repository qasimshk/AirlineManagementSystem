using airline.management.abstractions.Base;

namespace airline.management.abstractions.Notifications
{
    public interface ISendCustomerNotificationEvent : IBaseEvent
    {
        string FirstName { get; }
        string LastName { get; }
        string EmailAddress { get; }
    }
}
