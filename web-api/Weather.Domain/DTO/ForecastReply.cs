using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Domain.DTO
{
    public class ForecastReply
    {
        public string searchKey { get; set; }
        public bool isSuccesful { get; set; }
        public List<WeatherResponse> Responses { get; set; }
        public string Description { get; set; }
    }
}
