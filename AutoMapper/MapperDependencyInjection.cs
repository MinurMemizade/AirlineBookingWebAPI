using AirlineBookingWebApi.AutoMapper.Implementations;
using AirlineBookingWebApi.AutoMapper.Interface;
using System.Runtime.CompilerServices;

namespace AirlineBookingWebApi.AutoMapper
{
    public static class MapperDependencyInjection
    {
        public static void AddCustomMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, Mapper>();
        }
    }
}
