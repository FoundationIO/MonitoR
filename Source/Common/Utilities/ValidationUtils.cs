using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoR.Common.Utilities
{
    public static class ValidationUtils
    {
        public static bool IsEmailValid(string email)
        {
            return new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(email);
        }

        public static bool IsUrlValid(string url)
        {
            return Uri.IsWellFormedUriString(url, UriKind.Absolute);
        }
    }
}
