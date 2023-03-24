namespace airline.management.sharedkernal.Common
{
    // https://www.youtube.com/watch?v=weGLBPky43U

    public abstract class AggregateRoot<TId> : Entity<TId> where TId : notnull
    {
        protected AggregateRoot(TId id) : base(id) { }
    }
}
