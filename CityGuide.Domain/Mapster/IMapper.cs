namespace CityGuide.Domain.Mapster
{
    public interface IMapper
    {
        TDestination Map<TSource, TDestination>(TSource source);
    }
}
