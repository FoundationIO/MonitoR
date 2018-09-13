using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoR.Common.Utilities
{
    public static class StringUtils
    {
        public static string UTF8ByteArrayToString(Byte[] characters)
        {
            var encoding = new UTF8Encoding();
            var constructedString = encoding.GetString(characters);
            return (constructedString);
        }

        public static Byte[] StringToUTF8ByteArray(String pXmlString)
        {
            var encoding = new UTF8Encoding();
            var byteArray = encoding.GetBytes(pXmlString);
            return byteArray;
        }

        public static string ToString(this List<string> obj, string sep = " ", bool useNewLine = true)
        {
            if (obj == null)
                return "";
            return ToString((IList<string>)obj.ToArray(), sep, useNewLine);
        }

        public static string ToString(this string[] obj, string sep = " ", bool useNewLine = true)
        {
            if (obj == null)
                return "";
            var sb = new StringBuilder();
            var pos = 0;
            foreach (var item in obj)
            {
                if (useNewLine)
                    sb.AppendLine(item + ((pos != obj.Length - 1) ? sep : ""));
                else
                    sb.Append(item + ((pos != obj.Length - 1) ? sep : ""));
                pos++;
            }
            return sb.ToString();
        }

        public static string ToString(this IList<string> obj, string sep = " ", bool useNewLine = true)
        {
            if (obj == null)
                return "";
            return ToString(obj.ToArray(), sep, useNewLine);
        }

        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static string FirstChar(this string str)
        {
            if (str != null && str.Length > 0)
                return str[0].ToString();
            return string.Empty;
        }

        public static string AddFirstChar(this string str, char citem)
        {
            if (str.IsNullOrEmpty())
                return str;
            if (str.FirstChar() != citem.ToString())
                str = citem.ToString() + str;
            return str;
        }

        public static string RemoveLastChar(this string str, char citem)
        {
            if (str.IsNullOrEmpty())
                return str;
            if (str.LastChar() == citem.ToString())
                str = str.Substring(0, str.Length - 1);
            return str;
        }
        public static string LastChar(this string str)
        {
            if (str != null && str.Length > 0)
                return str[str.Length - 1].ToString();
            return string.Empty;
        }

        public static string RemoveFirstChar(this string str, char citem)
        {
            if (str.IsNullOrEmpty())
                return str;
            if (str.FirstChar() == citem.ToString())
                str = str.Substring(1);
            return str;
        }

        public static string RemoveLastCharAndAddFirstChar(this string str, char citem)
        {
            if (str.IsNullOrEmpty())
                return str;
            str = AddFirstChar(str, citem);
            str = RemoveLastChar(str, citem);
            return str;
        }

        public static bool IsTrimmedStringNullOrEmpty(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return true;
            return string.IsNullOrEmpty(str.Trim());
        }
    }
}
