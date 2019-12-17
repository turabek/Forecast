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
    public class GetForecastByZipCodeQueryHandler : IRequestHandler<GetForecastByZipCodeQuery, ForecastReply>
    {
        IForecastServiceByZipCode _forecastServiceByZipCode;
        public GetForecastByZipCodeQueryHandler(IForecastServiceByZipCode forecastServiceByZipCode)
        {
            _forecastServiceByZipCode = forecastServiceByZipCode;
        }
        
        public async Task<ForecastReply> Handle(GetForecastByZipCodeQuery request, CancellationToken cancellationToken)
        {
            return await _forecastServiceByZipCode.GetData(request.ZipCode);
        }
    }
}
