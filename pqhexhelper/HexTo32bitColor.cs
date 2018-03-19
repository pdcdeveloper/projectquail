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
        public static bool TryGetArgb(this string hex, out (byte alpha, byte red, byte green, byte blue) argb)
        {
            argb = (Byte.MinValue, Byte.MinValue, Byte.MinValue, Byte.MinValue);

            if (!TryGetValidateStartingIndex(hex, out int startingIndex))
                return false;

            argb.alpha = Byte.Parse(hex.Substring(startingIndex + 0, 2), NumberStyles.HexNumber);
            argb.red = Byte.Parse(hex.Substring(startingIndex + 2, 2), NumberStyles.HexNumber);
            argb.green = Byte.Parse(hex.Substring(startingIndex + 4, 2), NumberStyles.HexNumber);
            argb.blue = Byte.Parse(hex.Substring(startingIndex + 6, 2), NumberStyles.HexNumber);

            return true;
        }

        public static bool TryGetAlpha(this string hex, out byte alpha)
        {
            alpha = Byte.MinValue;
            if (TryGetValidateStartingIndex(hex, out int startingIndex))
                if (Byte.TryParse(hex.Substring(startingIndex + 0, 2), NumberStyles.HexNumber, null, out alpha))
                    return true;
            return false;
        }

        public static bool TryGetRed(this string hex, out byte red)
        {
            red = Byte.MinValue;
            if (TryGetValidateStartingIndex(hex, out int startingIndex))
                if (Byte.TryParse(hex.Substring(startingIndex + 2, 2), NumberStyles.HexNumber, null, out red))
                    return true;
            return false;
        }
        
        public static bool TryGetGreen(this string hex, out byte green)
        {
            green = Byte.MinValue;
            if (TryGetValidateStartingIndex(hex, out int startingIndex))
                if (Byte.TryParse(hex.Substring(startingIndex + 4, 2), NumberStyles.HexNumber, null, out green))
                    return true;
            return false;
        }

        public static bool TryGetBlue(this string hex, out byte blue)
        {
            blue = Byte.MinValue;
            if (TryGetValidateStartingIndex(hex, out int startingIndex))
                if (Byte.TryParse(hex.Substring(startingIndex + 6, 2), NumberStyles.HexNumber, null, out blue))
                    return true;
            return false;
        }

        public static (byte Alpha, byte Red, byte Green, byte Blue) GetArgb(this string hex)
        {
            if (TryGetArgb(hex, out (byte, byte, byte, byte) argb))
                return argb;
            return (Byte.MinValue, Byte.MinValue, Byte.MinValue, Byte.MinValue);
        }

        public static byte GetAlpha(this string hex)
        {
            if (TryGetAlpha(hex, out byte alpha))
                return alpha;
            return Byte.MinValue;
        }

        public static byte GetRed(this string hex)
        {
            if (TryGetRed(hex, out byte red))
                return red;
            return byte.MinValue;
        }
        public static byte GetGreen(this string hex)
        {
            if (TryGetGreen(hex, out byte green))
                return green;
            return Byte.MinValue;
        }

        public static byte GetBlue(this string hex)
        {
            if (TryGetBlue(hex, out byte blue))
                return blue;
            return Byte.MinValue;
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
