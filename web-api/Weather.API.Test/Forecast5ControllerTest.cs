using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Weather.API.Test.Mock.Services;
using Weather.Application.Interfaces.Services;
using Weather.Domain.DTO;
using Xunit;

namespace Weather.API.Test
{
    public class Forecast5ControllerTest
    {
        private readonly HttpClient _httpClient;

        public Forecast5ControllerTest()
        {
            var myFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder=>
                {
                    builder.ConfigureServices(services =>
                    {
                        //mock some services...
                        services.RemoveAll(typeof(IForecastServiceByCity));
                        services.AddSingleton<IForecastServiceByCity, MockForecastServiceByCity>();
                    });
                }
                );
            _httpClient = myFactory.CreateClient();
        }
        
        [Fact]
        public  async Task PositiveTestByCity()
        {
            //Arrange
            string CityName = "Leipzig";
            string url = $"{Routes.Root}/{Routes.ByCity.Replace("{CityName}", CityName)}";

            //Act
            var reply = await _httpClient.GetAsync(url);

            //Assert
            reply.StatusCode.Should().Be(HttpStatusCode.OK);
            var forecastReply = await reply.Content.ReadAsAsync<ForecastReply>();
            forecastReply.isSuccesful.Should().Be(true);
            forecastReply.searchKey.Should().Be(CityName);
        }



        [Fact]
        public async Task PositiveTestByZipCode()
        {
            //Arrange
            string ZipCode = "53300,MY";
            string url = $"{Routes.Root}/{Routes.ByZipZode.Replace("{ZipCode}", ZipCode)}";

            //Act
            var reply = await _httpClient.GetAsync(url);

            //Assert
            reply.StatusCode.Should().Be(HttpStatusCode.OK);
            var forecastReply = await reply.Content.ReadAsAsync<ForecastReply>();
            forecastReply.isSuccesful.Should().Be(true);
            forecastReply.searchKey.Should().Be(ZipCode);
        }


        [Fact]
        public async Task NegativeTestNotFoundUrl()
        {
            //Arrange
            string url = Guid.NewGuid().ToString();

            //Act
            var reply = await _httpClient.GetAsync(url);

            //Assert
            reply.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
