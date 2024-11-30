using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeBookData.Application.Tools
{
    public static class CaseConverter
    {
        public static string ToLowerFirst(string @string)
        {
            return char.ToLower(@string[0]) + @string.Substring(1);
        }

        public static string ToUpperFirst(string @string)
        {
            return char.ToUpper(@string[0]) + @string.Substring(1);
        }

        public static string ToUpperFirst(string[] content)
        {
            string result = "";

            foreach (var @string in content)
                result += ToUpperFirst(@string) + " ";

            return result;
        }
    }
}
