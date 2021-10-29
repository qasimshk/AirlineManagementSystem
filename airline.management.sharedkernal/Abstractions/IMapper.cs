namespace airline.management.sharedkernal.Abstractions
{
    public interface IMapper<in Source, out Destination>
    {
        Destination Map(Source from);
    }
}
