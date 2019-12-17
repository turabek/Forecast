using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Weather.Application.Helpers;
using Weather.Application.Interfaces.Helpers;
using Weather.Application.Interfaces.Services;
using Weather.Application.Services;

namespace Weather.Application.Installers
{
    //Installing Application related services
    public class ServiceInstaller 
    {
        public static void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient();
            services.AddTransient<IUnixTimeStampHelper, UnixTimeStampHelper>();
            services.AddTransient<IWeatherResponseMapper, WeatherResponseMapper>();
            services.AddSingleton<IForecastServiceByCity, ForecastServiceByCity>();
            services.AddSingleton<IForecastServiceByZipCode, ForecastServiceByZipCode>();
        }
    }
}
