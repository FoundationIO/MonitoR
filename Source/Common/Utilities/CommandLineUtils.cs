using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoR.Common.Utilities
{
    public static class CommandLineUtils
    {
        public static bool IsParamAvailable(this string[] args, string paramName)
        {
            if (args == null)
                return false;

            for (var i = 0; i < args.Length; ++i)
            {
                var argItem = args[i].ToLower().Trim();
                paramName = paramName.ToLower().Trim();

                if (argItem == paramName || argItem == "/" + paramName || argItem == "\\" + paramName
                    || argItem == "--" + paramName || argItem == "-" + paramName)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsParamValueAvailable(this string[] args, string paramName)
        {
            if (args == null)
                return false;

            for (var i = 0; i < args.Length; ++i)
            {
                var argItem = args[i].ToLower().Trim();
                paramName = paramName.ToLower().Trim();

                if ( (argItem == paramName || argItem == "/" + paramName || argItem == "\\" + paramName
                    || argItem == "--" + paramName || argItem == "-" + paramName) && (i + 1 <= args.Length) )
                {
                    return true;
                }
            }

            return false;
        }

        public static string GetParamValueAsString(this string[] args, string paramName, string defaultValue = "")
        {
            if (args == null)
                return defaultValue;

            for (var i = 0; i < args.Length; ++i)
            {
                var argItem = args[i].ToLower().Trim();
                paramName = paramName.ToLower().Trim();

                if ( (argItem == paramName || argItem == "/" + paramName || argItem == "\\" + paramName
                    || argItem == "--" + paramName || argItem == "-" + paramName) && (i + 1 < args.Length) )
                {
                    var val = args[i + 1];
                    return val;
                }
            }

            return defaultValue;
        }

        public static T GetParamValueAs<T>(this string[] args, string paramName, T defaultValue)
        {
            var paramValue = GetParamValueAsString(args, paramName);
            try
            {
                var t = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
                return (T)Convert.ChangeType(paramValue, t);
            }
            catch(Exception)
            {
                return defaultValue;
            }
        }
    }
}
