using MonitoR.Common.Utilities;
using System.Collections.Generic;

namespace MonitoR.Common.Common
{
    public class ReturnValue
    {
        public bool Result { get; set; }
        public List<string> ErrorMessages { get; set; } = new List<string>();
        public List<string> WarningMessages { get; set; } = new List<string>();

        public string ErrorMessageForReporing()
        {
            return StringUtils.ToString(ErrorMessages.ToArray());
        }

        public string WarningMessageForReporing()
        {
            return StringUtils.ToString(WarningMessages.ToArray());
        }

        public string ErrorAndWarningMessageForReporing()
        {
            return "Error : \n" + StringUtils.ToString(ErrorMessages.ToArray()) + "\n\nWarning :\n" + StringUtils.ToString(WarningMessages.ToArray());
        }

        public static ReturnValue True()
        {
            return new ReturnValue { Result = true};
        }

        public static ReturnValue True(string warningMessage)
        {
            if (string.IsNullOrEmpty(warningMessage))
                return new ReturnValue { Result = true};
            else
                return new ReturnValue { Result = true , WarningMessages = new List<string> { warningMessage } };
        }

        public static ReturnValue True(List<string> warningMessages)
        {
            if (warningMessages == null || warningMessages.Count == 0)
                return new ReturnValue { Result = true };
            else
                return new ReturnValue { Result = true, WarningMessages = warningMessages };
        }

        public static ReturnValue False(string errorMessage)
        {
            return new ReturnValue { Result = false, ErrorMessages = new List<string> { errorMessage }  };
        }

        public static ReturnValue False(List<string> errorList, List<string> warningList)
        {
            return new ReturnValue { Result = false, ErrorMessages = errorList, WarningMessages = warningList };
        }


    }


}
