using System;

namespace Weather.Domain.DTO
{
    public class WeatherResponse
    {
        public DateTime Date { get; set; }
        public Double Temperature { get; set; }

        public Double Humidity { get; set; }

        public Double WindSpeed { get; set; }
    }
}
