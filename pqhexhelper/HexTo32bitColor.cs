using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace pqhexhelper
{
    // Provides methods to parse hex strings (syntax "#FFFFFFFF" or "FFFFFFFF") into 'Windows.UI.Color' or into separate argb byte values.
    public static class HexTo32bitColor
    {
        public static (byte alpha, byte red, byte green, byte blue) GetArgb(this string hex)
        {
            (byte a, byte r, byte g, byte b) argb = (Byte.MaxValue, Byte.MaxValue, Byte.MaxValue, Byte.MaxValue);

            

            return argb;
        }

        public static byte GetAlphaValue(this string hex)
        {
            return Byte.MaxValue;
        }

        public static bool TryGetArgb(this string hex, out (byte alpha, byte red, byte green, byte blue) argb)
        {
            argb = (Byte.MaxValue, Byte.MaxValue, Byte.MaxValue, Byte.MaxValue);

            return false;
        }

        public static bool TryGetAlphaValue(this string hex, out byte alpha)
        {
            alpha = Byte.MaxValue;
            
            return false;
        }

        public static bool TryGetRedValue(this string hex, out byte red)
        {
            red = Byte.MaxValue;
            
            return false;
        }

        public static bool TryGetGreenValue(this string hex, out byte green)
        {
            green = Byte.MaxValue;
            

            return false;
        }

        public static bool TryGetBlueValue(this string hex, out byte blue)
        {
            blue = Byte.MaxValue;

            return false;
        }

        // TODO: make private after unit test.
        public static bool TryGetIndexByValidatingHexSyntax(this string hex, out int index)
        {
            index = -1;

            if (string.IsNullOrEmpty(hex) || (hex.Length < 8 || hex.Length > 9))
                return false;

            // Validate.
            int i = 0;
            if (hex.Length == 8)
            {
                index = 0;
            }
            else
            {
                if (hex[0] != '#' | hex[0] != '\x23')
                    return false;
                i = index = 1;
            }

            for (; i < hex.Length; i++)
                if (!Regex.Match(hex[i].ToString(), @"\d").Success && !Regex.Match(hex[i].ToString().ToLower(), @"[a-f]").Success)
                {
                    index = -1;
                    return false;
                }

            return true;
        }

    }
}
