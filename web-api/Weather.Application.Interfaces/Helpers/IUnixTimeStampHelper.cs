using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Application.Interfaces.Helpers
{
    public interface IUnixTimeStampHelper
    {
        DateTime ConverToDateTime(int UnixTimeStamp);
    }
}
