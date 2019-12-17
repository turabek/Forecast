using OpenWeatherMap.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Weather.Domain.DTO;
using Weather.Application.Interfaces.Services;
using System.Linq;
using Weather.Application.Helpers;
using Weather.Application.Interfaces.Helpers;

namespace Weather.Application.Services
{
    public class WeatherResponseMapper : IWeatherResponseMapper
    {
        private IUnixTimeStampHelper _unixTimeStampHelper;
        public WeatherResponseMapper(IUnixTimeStampHelper unixTimeStampHelper)
        {
            _unixTimeStampHelper = unixTimeStampHelper;
        }
        public List<WeatherResponse> Prepare<T>(T source)
        {
            if (source is ForecastResponse)
            {
                ForecastResponse forecastResponse = source as ForecastResponse;
                var grouped =
                from forecast in forecastResponse.list
                group forecast by _unixTimeStampHelper.ConverToDateTime(forecast.dt).Date into forecastDaily
                select new WeatherResponse()
                {
                    Date = forecastDaily.Key,
                    Humidity = Math.Round(forecastDaily.Average(x => x.main.humidity), 2),
                    Temperature = Math.Round(forecastDaily.Average(x => x.main.temp), 2),
                    WindSpeed = Math.Round(forecastDaily.Average(x => x.wind.speed), 2)
                };
                var result = grouped.ToList();
                return result;

            }
            else
            {
                throw new NotSupportedException(source.GetType().ToString());
            }
        }
        
    }
}
