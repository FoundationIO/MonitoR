using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoR.Common.Constants
{
    public enum CheckIntervalType
    {
        Seconds,
        Minutes,
        Hours,
        Days
    }

    public static class CheckIntervalTypeHeper
    {
        public static int CheckIntervalInSeconds(this CheckIntervalType checkIntervalType, int value)
        {
            switch(checkIntervalType)
            {
                case CheckIntervalType.Minutes:
                    return value * 60;
                case CheckIntervalType.Hours:
                    return value * 60 * 60;
                case CheckIntervalType.Days:
                    return value * 60 * 60 * 24;

                case CheckIntervalType.Seconds:
                default:
                    return value;
            }
        }
    }
}
