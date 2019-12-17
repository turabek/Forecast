using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Weather.Domain;
using Weather.Domain.DTO;

namespace Weather.Application.Queries
{
    public class GetForecastByCityQuery:IRequest<ForecastReply>
    {
        public string CityName { get; set; }
    }
}
