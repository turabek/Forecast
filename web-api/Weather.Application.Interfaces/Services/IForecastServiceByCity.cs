using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.Domain.DTO;

namespace Weather.Application.Interfaces.Services
{
    public interface IForecastServiceByCity
    {
        Task<ForecastReply> GetData(string City);
    }
}
