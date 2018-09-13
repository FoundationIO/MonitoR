using FluentScheduler;
using MonitoR.Common.Infrastructure;
using MonitoR.Common.Common;
using MonitoR.Common.Sensors;
using System;
using MonitoR.Common.Utilities;
using MonitoR.Common.Service;
using System.Collections.Generic;
using System.Dynamic;

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
            try
            {
                log.Debug($"Started executing sensor - {sensor.Name} with Id - {sensor.Id}");
                result = sensor.Execute(appConfig, log);

                if (result == null)
                    result = ReturnValue.False($"Unexpected error when executing sensor - {sensor.Name} with Id - {sensor.Id}");

                if (result.Result == false)
                    log.Debug($"Completed executing sensor with error - {sensor.Name} with Id - {sensor.Id} - error - {result?.ErrorAndWarningMessageForReporing()}");
                else
                    log.Debug($"Completed executing sensor - {sensor.Name} with Id - {sensor.Id}"); 
            }
            catch(Exception ex)
            {
                log.Error(ex, $"Error executing sensor - {sensor.Name} with Id - {sensor.Id}");
                result = ReturnValue.False($"Error executing sensor - {sensor.Name} with Id - {sensor.Id}, Exception - {ExceptionUtils.RecursivelyGetExceptionMessage(ex)}");
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

                if (sensor.ContinousErrorOccurenceCount >= sensor.NotifyIfHappensAfterTimes)
                {
                    log.Debug($"{sensor.Name} with Id - {sensor.Id}, Continous error occured.");
                    sensor.ContinousErrorOccurenceCount = 0;
                    if(sensor.NotifyByEmail)
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
                        
                        emailService.SendMail(ApplyAndGetTemplate(param, appConfig.EmailTemplateSettings.DefaultSubject), 
                                              ApplyAndGetTemplate(param, appConfig.EmailTemplateSettings.DefaultTextBody),
                                              ApplyAndGetTemplate(param, appConfig.EmailTemplateSettings.DefaultHtmlBody));
                    }
                }
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

        public void Stop(bool immediate)
        {
            // Method intentionally left empty.
        }

    }


}
