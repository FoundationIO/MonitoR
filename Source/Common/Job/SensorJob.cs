using FluentScheduler;
using MonitoR.Common.Infrastructure;
using MonitoR.Common.Common;
using MonitoR.Common.Sensors;
using System;
using MonitoR.Common.Utilities;
using MonitoR.Common.Service;
using System.Collections.Generic;
using System.Dynamic;
using LiteDB;

namespace MonitoR.Common.Job
{
    public class SensorJob : IJob
    {
        private readonly ISensor sensor;
        private readonly IAppConfig appConfig;
        private readonly ILog log;
        private readonly IEmailService emailService;

        public SensorJob(ISensor sensor,IAppConfig appConfig, ILog log, IEmailService emailService)
        {
            this.sensor = sensor;
            this.appConfig = appConfig;
            this.log = log;
            this.emailService = emailService;
        }

        public void Execute()
        {
            var startTime = DateTime.Now;
            ReturnValue result;
            var jobHistory = new JobHistory
            {
                StartTime = startTime,
                SensorId = sensor.Id,
                SensorName = sensor.Name
            };

            try
            {
                log.Debug($"Started executing sensor - {sensor.Name} with Id - {sensor.Id}");
                result = sensor.Execute(appConfig, log);

                jobHistory.EndTime = DateTime.Now;

                if (result == null)
                    result = ReturnValue.False($"Unexpected error when executing sensor - {sensor.Name} with Id - {sensor.Id}");

                var str = "";
                if (result.Result)
                {
                    str = $"Completed executing sensor - {sensor.Name} with Id - {sensor.Id}";
                    log.Debug(str);
                }
                else
                {
                    str = $"Completed executing sensor with error - {sensor.Name} with Id - {sensor.Id} - error - {result?.ErrorAndWarningMessageForReporing()}";
                    log.Error(str);
                }

                jobHistory.IsSuccess = result.Result;
                jobHistory.Message = str;
            }
            catch (Exception ex)
            {
                var str = $"Error executing sensor - {sensor.Name} with Id - {sensor.Id}, Exception - {ex.RecursivelyGetExceptionMessage()}";
                log.Error(ex, $"Error executing sensor - {sensor.Name} with Id - {sensor.Id}");
                result = ReturnValue.False(str);
                jobHistory.Message = str;
            }
            finally
            {
                sensor.LastExecutedDateTime = startTime;
                sensor.LastExecutionTimeInSecs = (DateTime.Now - startTime).TotalSeconds;
            }

            if (result.Result)
            {
                sensor.ContinousErrorOccurenceCount = 0;
            }
            else
            {
                sensor.ContinousErrorOccurenceCount++;
                jobHistory.Notified = false;

                if (sensor.ContinousErrorOccurenceCount >= sensor.NotifyIfHappensAfterTimes)
                {
                    log.Debug($"{sensor.Name} with Id - {sensor.Id}, Continous error occured.");
                    sensor.ContinousErrorOccurenceCount = 0;
                    if (sensor.NotifyByEmail)
                    {
                        log.Debug($"Sending mail for failed sensor - {sensor.Name} (Id - {sensor.Id}) .");
                        var param = new TemplateParameters
                        {
                            MachineName = Environment.MachineName,
                            SensorName = sensor.Name,
                            SensorId = sensor.Id.ToString(),
                            SensorType = sensor.SensorType.ToString(),
                            ErrorMessageList = result.ErrorMessages,
                            MessagePrefix = appConfig.EmailTemplateSettings.MessagePrefix,
                            MessageSuffix = appConfig.EmailTemplateSettings.MessageSuffix,
                            SensorAllErrorMessage = result.ErrorMessages.ToString(""),
                        };

                        var emailResult = emailService.SendMail(ApplyAndGetTemplate(param, appConfig.EmailTemplateSettings.DefaultSubject),
                                              ApplyAndGetTemplate(param, appConfig.EmailTemplateSettings.DefaultTextBody),
                                              ApplyAndGetTemplate(param, appConfig.EmailTemplateSettings.DefaultHtmlBody));

                        jobHistory.Notified = !ReturnValue.IsNullOrFalse(emailResult);
                    }
                }
                else
                {
                    log.Debug($"Ignoring the Notification as the Thresold ({sensor.ContinousErrorOccurenceCount} / {sensor.NotifyIfHappensAfterTimes}) did not reach for Sensor - {sensor.Name} - {sensor.SensorType} - {sensor.Id}");
                }
            }

            try
            {
                using (var db = new LiteDatabase(appConfig.GetOrCreateHistoryDbPath()))
                {
                    var history = db.GetCollection<JobHistory>("jobhistory");
                    history.Insert(jobHistory);
                }
            }
            catch(Exception ex)
            {
                log.Error(ex,"Error writing to the history table");
            }
        }

        private static string ApplyAndGetTemplate(TemplateParameters param, string templateText)
        {
            var template = Mustachio.Parser.Parse(templateText);
            var expando = new ExpandoObject();
            var dictionary = (IDictionary<string, object>)expando;

            foreach (var property in param.GetType().GetProperties())
                dictionary.Add(property.Name, property.GetValue(param));

            var result = template(expando);
            return result;
        }

        public void Stop()
        {
            // Method intentionally left empty.
        }
    }
}
