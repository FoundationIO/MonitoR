using System;

namespace MonitoR.Common.Infrastructure
{
    public interface ILog
    {
        void Debug(string str);
        void Error(Exception ex, string str = "");
        void Error(string str);
        void Fatal(string str);
        void Info(string str);
        void Warn(string str);
    }
}