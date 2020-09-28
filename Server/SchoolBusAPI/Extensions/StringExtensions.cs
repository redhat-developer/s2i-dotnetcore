using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SchoolBusAPI.Extensions
{
    public static class StringExtensions
    {
        private static readonly Regex numeric = new Regex(@"^\d+(\.\d+)?$");
        private static readonly Regex integer = new Regex(@"^\d+$");

        public static bool IsNotEmpty(this string str)
        {
            return !string.IsNullOrWhiteSpace(str);
        }

        public static bool IsEmpty(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        public static decimal[] ToDecimalArray(this string str)
        {
            if (str == null) return new decimal[] { };

            var result = new List<decimal>();

            try
            {
                string[] tokens = str.Split(',');

                foreach (var token in tokens)
                {
                    var decToken = decimal.Parse(token);

                    if (!result.Contains(decToken))
                        result.Add(decToken);
                }
            }
            catch
            {
                return new decimal[] { };
            }

            return result.ToArray();
        }

        public static string[] ToStringArray(this string str)
        {
            return str == null ? (new string[] { }) : str.Split(',');
        }

        public static bool IsInteger(this string str)
        {
            return integer.IsMatch(str);
        }

        public static bool IsNumeric(this string str)
        {
            return numeric.IsMatch(str);
        }

        public static string WordToWords(this string str)
        {
            str = Regex.Replace(str, "[a-z][A-Z]", x => $"{x.Value[0]} {char.ToUpper(x.Value[1])}");
            str = Regex.Replace(str, "[A-Z][A-Z][a-z]", x => $"{x.Value[0]} {x.Value[1]}{x.Value[2]}");

            return str;
        }
    }
}
