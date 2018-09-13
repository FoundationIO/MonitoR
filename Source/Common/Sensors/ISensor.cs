using MonitoR.Common.Infrastructure;
using MonitoR.Common.Common;
using System;
using System.Collections.Generic;
using MonitoR.Common.Constants;

namespace MonitoR.Common.Sensors
{
    public interface ISensor
    {
        string Name { get; set; }
        Guid Id { get; set; }
        SensorType SensorType { get; set; }
        bool Enabled { get; set; }
        int CheckInterval { get; set; }
        CheckIntervalType IntervalType { get; set; }
        DateTime LastExecutedDateTime { get; set; }
        double LastExecutionTimeInSecs { get; set; }
        int NotifyIfHappensAfterTimes { get; set; }
        string CustomMessage { get; set; }
        string AllowedValue { get; set; }
        string CurrentValue { get; set; }
        List<bool> PastStatus { get; set; }
        List<string> CurrentErrorList { get; set; }
        List<string> CurrentWarningList { get; set; }
        bool NotifyByEmail { get; set; }
        int ContinousErrorOccurenceCount { get; set; }
        ReturnValue Execute(IAppConfig appConfig, ILog log);
    }


}
