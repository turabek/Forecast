using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Weather.Application.Queries;
using Weather.Domain.DTO;
using Weather.Application.Interfaces.Services;

namespace Weather.Application.Handlers
{
    public class GetForecastByCityQueryHandler : IRequestHandler<GetForecastByCityQuery, ForecastReply>
    {
        IForecastServiceByCity _weatherServiceByCity;
        public GetForecastByCityQueryHandler(IForecastServiceByCity weatherServiceByCity)
        {
            _weatherServiceByCity = weatherServiceByCity;
        }
        
        public async Task<ForecastReply> Handle(GetForecastByCityQuery request, CancellationToken cancellationToken)
        {
            return await _weatherServiceByCity.GetData(request.CityName);
        }
    }
}
