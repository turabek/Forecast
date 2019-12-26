using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.Domain.DTO;

namespace Weather.API.Test.Mock.Abstract
{
    public abstract class AbstractMockForecastService
    {
        protected Task<ForecastReply> PrepareReply(string searchKey)
        {
            var forecastReply = new ForecastReply()
            {
                Description = "success",
                isSuccesful = true,
                searchKey = searchKey,
                Responses = new List<WeatherResponse>()
            };
            for (int i = 0; i < 6; i++)
            {
                forecastReply.Responses.Add(new WeatherResponse()
                {
                    Date = DateTime.Today.AddDays(i),
                    Humidity = 80,
                    Temperature = 15,
                    WindSpeed = 10
                });
            }
            return Task.FromResult(forecastReply);

        }
        public AbstractMockForecastService()
        {
            
        }
    }
}
