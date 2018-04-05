using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pqcommonui
{
    public static class AsciiCharacters
    {
        public const string Epoch = "January 1, 1970";
        public const string EnDash = "\x2013";
        public const string EmDash = "\x2014";
        public const string NonBreakingSpace = "\xA0";
        public const string NoValueIndicator = EmDash + NonBreakingSpace + EmDash;
    }
}
