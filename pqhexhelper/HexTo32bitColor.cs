using System;
using System.Collections.Generic;
using System.Globalization;
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
            (byte a, byte r, byte g, byte b) argb = (Byte.MinValue, Byte.MinValue, Byte.MinValue, Byte.MinValue);

            return argb;
        }
        
        public static bool TryGetArgb(this string hex, out (byte alpha, byte red, byte green, byte blue) argb)
        {
            argb = (Byte.MinValue, Byte.MinValue, Byte.MinValue, Byte.MinValue);

            return false;
        }

        public static byte GetAlphaValue(this string hex)
        {
            return Byte.MinValue;
        }

        public static bool TryGetAlphaValue(this string hex, out byte alpha)
        {
            alpha = Byte.MinValue;

            if (TryGetValidateStartingIndex(hex, out int startingIndex))
                if (Byte.TryParse(hex.Substring(startingIndex + 0, 2), NumberStyles.HexNumber, null, out alpha))
                    return true;
            return false;
        }

        public static byte GetRedValue(this string hex)
        {
            return byte.MinValue;
        }

        public static bool TryGetRedValue(this string hex, out byte red)
        {
            red = Byte.MinValue;
            
            return false;
        }

        public static bool TryGetGreenValue(this string hex, out byte green)
        {
            green = Byte.MinValue;
            

            return false;
        }

        public static bool TryGetBlueValue(this string hex, out byte blue)
        {
            blue = Byte.MinValue;

            return false;
        }

        public static bool TryGetValidateStartingIndex(this string hex, out int startingIndex)
        {
            startingIndex = -1;

            if (string.IsNullOrEmpty(hex) || (hex.Length < 8 || hex.Length > 9))
                return false;

            // Validate.
            int i = 0;
            if (hex.Length == 8)
            {
                startingIndex = 0;
            }
            else
            {
                if (hex[0] != '#' | hex[0] != '\x23')
                    return false;
                i = startingIndex = 1;
            }

            for (; i < hex.Length; i++)
                if (!Regex.Match(hex[i].ToString(), @"\d").Success && !Regex.Match(hex[i].ToString().ToLower(), @"[a-f]").Success)
                {
                    startingIndex = -1;
                    return false;
                }

            return true;
        }

    }
}
