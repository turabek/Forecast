using Microsoft.Extensions.Configuration;
using OpenWeatherMap.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Weather.Application.Interfaces.Services;
using Weather.Domain.DTO;

namespace Weather.Application.Abstracts
{
    public abstract class AbstractForecastService
    {
        #region protected members
        protected readonly IConfiguration _config;

        protected readonly IHttpClientFactory _clientFactory;

        protected readonly IWeatherResponseMapper _weatherResponseMapper;

        protected readonly string _openWeatherUrl = "";

        protected readonly string _openWeatherAppId = "";

        #endregion

        public AbstractForecastService(IConfiguration config,
            IHttpClientFactory clientFactory,
            IWeatherResponseMapper weatherResponseMapper)
        {
            _config = config;
            _clientFactory = clientFactory;
            var ServiceSettings = _config.GetSection("ServiceSettings");
            _openWeatherUrl = ServiceSettings["OpenWeatherUrl"];
            _openWeatherAppId = ServiceSettings["OpenWeatherAppId"];
            _weatherResponseMapper = weatherResponseMapper;
        }

        protected virtual async Task<ForecastReply> ProcessMessage(string searchKey, HttpRequestMessage request)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            ForecastReply reply = new ForecastReply();
            reply.searchKey = searchKey;

            //checking http response
            if (response.IsSuccessStatusCode)
            {
                HandleSuccesfulCase(response, reply);
            }
            else
            {
                //assign the reason of the failure
                HandleFailedCase(response, reply);
            }
            return reply;
        }

        protected virtual async void HandleSuccesfulCase(HttpResponseMessage response, ForecastReply reply)
        {
            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                var result = await JsonSerializer.DeserializeAsync<ForecastResponse>(responseStream);
                var convertedResult = _weatherResponseMapper.Prepare<ForecastResponse>(result);
                reply.Responses = convertedResult;
                reply.isSuccesful = true;
            }
        }

        protected virtual async void HandleFailedCase(HttpResponseMessage response, ForecastReply reply)
        {
            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                var result = await JsonSerializer.DeserializeAsync<FailedResponse>(responseStream);
                reply.Description = result.message;
                reply.isSuccesful = false;
            }
        }
    }
}
