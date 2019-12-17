using System;
using System.Collections.Generic;
using System.Text;
using Weather.Application.Interfaces.Helpers;

namespace Weather.Application.Helpers
{
    public class UnixTimeStampHelper: IUnixTimeStampHelper
    {
        private readonly DateTime _BaseDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public DateTime ConverToDateTime(int UnixTimeStamp)
        {
            return _BaseDate.AddSeconds((long)UnixTimeStamp);
        }
    }
}
