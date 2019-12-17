using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Weather.Domain;
using Weather.Domain.DTO;

namespace Weather.Application.Queries
{
    public class GetForecastByZipCodeQuery:IRequest<ForecastReply>
    {
        public string ZipCode { get; set; }
    }
}
