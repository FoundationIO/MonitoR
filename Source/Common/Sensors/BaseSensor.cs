using MonitoR.Common.Infrastructure;
using MonitoR.Common.Common;
using System;
using System.Collections.Generic;
using MonitoR.Common.Constants;
using MonitoR.Common.Utilities;

namespace MonitoR.Common.Sensors
{
    public class BaseSensor : ISensor
    {
        public string Name { get; set; } = "";
        public Guid Id { get; set; }
        public SensorType SensorType { get; set; }
        public bool Enabled { get; set; } = true;
        public int CheckInterval { get; set; } = 5;
        public CheckIntervalType IntervalType { get; set; } = CheckIntervalType.Seconds;
        public DateTime LastExecutedDateTime { get; set; }
        public double LastExecutionTimeInSecs { get; set; }
        public int NotifyIfHappensAfterTimes { get; set; } = 1;
        public string CustomMessage { get; set; }
        public string AllowedValue { get; set; }
        public string CurrentValue { get; set; }
        public List<bool> PastStatus { get; set; }
        public List<string> CurrentErrorList { get; set; } = new List<string>();
        public List<string> CurrentWarningList { get; set; } = new List<string>();
        public bool NotifyByEmail { get; set; } = true;
        public int ContinousErrorOccurenceCount { get; set; }

        public virtual ReturnValue Execute(IAppConfig appConfig, ILog log)
        {
            try
            {
                return ExecuteInternal();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Unexpected error when executing base sensor");
                return ReturnValue.False("Unexpected error when executing base sensor");
            }
        }

        public ReturnValue ExecuteInternal()
        {
            return null;
        }

        public virtual ReturnValue IsValid(List<ISensor> allSensors)
        {
            if (Id == Guid.Empty)
                return ReturnValue.False("Id is invalid");

            if (Name.IsTrimmedStringNullOrEmpty())
                return ReturnValue.False("Name should not be empty");

            if (CheckInterval <= 0)
                return ReturnValue.False("Check interval should be less than 1");

            if (this.IntervalType == MonitoR.Common.Constants.CheckIntervalType.Seconds)
            {
                if (CheckInterval > 59)
                    return ReturnValue.False("Check interval should be less than 59 secs");
            }
            else if (this.IntervalType == MonitoR.Common.Constants.CheckIntervalType.Minutes)
            {
                if (CheckInterval > 59)
                    return ReturnValue.False("Check interval should be less than 59 minutes");
            }
            else if (this.IntervalType == MonitoR.Common.Constants.CheckIntervalType.Hours)
            {
                if (CheckInterval > 23)
                    return ReturnValue.False("Check interval should be less than 23 hours");

                if (CheckInterval < 0)
                    return ReturnValue.False("Check interval should be greater -1 hours");
            }

            if (NotifyIfHappensAfterTimes <= 0)
                return ReturnValue.False("NotifyIfHappensAfterTimes greater than 0");

            if (allSensors != null)
            {
                foreach (var sensor in allSensors)
                {
                    if (this.Id == sensor.Id)
                        continue;

                    if (this.Name.Trim().ToUpper() == sensor.Name.Trim().ToUpper())
                        return ReturnValue.False("Another sensor with simular name already exists");
                }
            }

            return ReturnValue.True();
        }

        public virtual string GetDetails()
        {
            return "Runs every " + CheckInterval + " " + this.IntervalType.ToString() + "; " +
                " Notify after " + NotifyIfHappensAfterTimes + " "+ "failures " + "; " +
                (NotifyByEmail ? " Notify by Email " : "Nofication disable ") + "; ";
        }
    }

}
