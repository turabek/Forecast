using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.API.Test.Mock.Abstract;
using Weather.Application.Interfaces.Services;
using Weather.Domain.DTO;

namespace Weather.API.Test.Mock.Services
{
    public class MockForecastServiceByZipCode : AbstractMockForecastService, IForecastServiceByZipCode
    {
        public async Task<ForecastReply> GetData(string ZipCode)
        {
            ForecastReply reply = await PrepareReply(ZipCode);
            return reply;
        }
    }
}
