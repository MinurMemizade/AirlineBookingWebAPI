namespace AirlineBookingWebApi.AutoMapper.Interface
{
    public interface IMapper
    {
        TDestination Map<TDestination,TSource>(TSource source,string? ignore=null);
        IList<TDestination> Map<TDestination, TSource>(List<TSource> source, string? ignore = null);
        TDestination Map<TDestination, TSource>(object source, string? ignore = null);
        IList<TDestination> Map<TDestination, TSource>(List<object> source, string? ignore = null);

    }
}
