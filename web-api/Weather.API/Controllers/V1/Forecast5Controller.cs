using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Weather.Application.Queries;
using Weather.Domain.DTO;

namespace Weather.API.Controllers
{
    [ApiController]
    [Route(Routes.Root)]
    public class Forecast5Controller : ControllerBase
    {
        private readonly ILogger<Forecast5Controller> _logger;
        private readonly IMediator _mediator;

        public Forecast5Controller(IMediator mediator
            , ILogger<Forecast5Controller> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        [Route(Routes.ByCity)]
        public Task<ForecastReply> ByCity(string CityName)
        {
            var query = new GetForecastByCityQuery()
            {
                CityName = CityName
            };
            var reply = _mediator.Send(query);
            return reply;
        }

        [HttpGet]
        [Route(Routes.ByZipZode)]
        public Task<ForecastReply> ByZipCode(string ZipCode)
        {
            var query = new GetForecastByZipCodeQuery()
            {
                ZipCode = ZipCode
            };
            var reply = _mediator.Send(query);
            return reply;
        }


    }
}
