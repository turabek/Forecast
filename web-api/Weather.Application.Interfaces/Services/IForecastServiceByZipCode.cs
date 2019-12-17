using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.Domain.DTO;

namespace Weather.Application.Interfaces.Services
{
    public interface IForecastServiceByZipCode
    {
        Task<ForecastReply> GetData(string ZipCode);
    }
}
