using Microsoft.Extensions.Configuration;
using OpenWeatherMap.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Weather.Application.Abstracts;
using Weather.Application.Interfaces.Services;
using Weather.Domain.DTO;


namespace Weather.Application.Services
{
    public class ForecastServiceByCity : AbstractForecastService, IForecastServiceByCity
    {
        public ForecastServiceByCity(IConfiguration config, IHttpClientFactory clientFactory, IWeatherResponseMapper weatherResponseMapper) : base(config, clientFactory, weatherResponseMapper)
        {
            
        }

        public Task<ForecastReply> GetData(string City)
        {
            string ForecastUrl = $"{_openWeatherUrl}/forecast?q={City}&units=metric&appid={_openWeatherAppId}";
            var request = new HttpRequestMessage(HttpMethod.Get, ForecastUrl);
            request.Headers.Add("Accept", "application/json");
            return ProcessMessage(City, request);
        }

    }
}
