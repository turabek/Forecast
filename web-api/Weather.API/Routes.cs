using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather.API
{
    public static class Routes
    {
        public const string Root = "api/v1/Forecast5";
        public const string ByCity = "ByCity/{CityName}";
        public const string ByZipZode = "ByZipCode/{ZipCode}";
    }
}
