using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeatherMap.Models
{
    public class ForecastResponse
    {
        public string cod { get; set; }
        public int message { get; set; }
        public int cnt { get; set; }
        public List<list> list { get; set; }
        public City city { get; set; }
    }
}
