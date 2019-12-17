using Microsoft.Extensions.Configuration;
using OpenWeatherMap.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Weather.Domain.DTO;
using Weather.Application.Interfaces.Services;
using Weather.Application.Abstracts;

namespace Weather.Application.Services
{
    public class ForecastServiceByZipCode : AbstractForecastService, IForecastServiceByZipCode
    {
        public ForecastServiceByZipCode(IConfiguration config, IHttpClientFactory clientFactory, IWeatherResponseMapper weatherResponseMapper) : base(config, clientFactory, weatherResponseMapper)
        {
        }

        public Task<ForecastReply> GetData(string ZipCode)
        {
            string ForecastUrl = $"{_openWeatherUrl}/forecast?zip={ZipCode}&units=metric&appid={_openWeatherAppId}";
            var request = new HttpRequestMessage(HttpMethod.Get, ForecastUrl);
            request.Headers.Add("Accept", "application/json");
            return ProcessMessage(ZipCode,request);
        }
    }
}
