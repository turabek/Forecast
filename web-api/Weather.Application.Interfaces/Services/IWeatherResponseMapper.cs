using System;
using System.Collections.Generic;
using System.Text;
using Weather.Domain.DTO;

namespace Weather.Application.Interfaces.Services
{
    public interface IWeatherResponseMapper
    {
        List<WeatherResponse> Prepare<T>(T source);
    }
}
