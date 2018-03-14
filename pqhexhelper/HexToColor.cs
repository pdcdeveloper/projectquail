using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace pqhexhelper
{
    // Provides methods to parse hex strings (syntax "#FFFFFFFF") into 'Windows.UI.Color' or into separate argb byte values.
    public static class HexToColor
    {
        public (byte alpha, byte red, byte green, byte blue) GetArgb(string hex)
        {
            (byte a, byte r, byte g, byte b) argb = (Byte.MaxValue, Byte.MaxValue, Byte.MaxValue, Byte.MaxValue);

            if (HasValidHexSyntax(hex))
                return argb;


            return argb;
        }

        public byte GetAlpha(string hex)
        {
            if (HasValidHexSyntax(hex))
                return Byte.MaxValue;

        }

        public static bool TryGetArgb(string hex, out (byte alpha, byte red, byte green, byte blue) argb)
        {
            argb = (Byte.MaxValue, Byte.MaxValue, Byte.MaxValue, Byte.MaxValue);

            return false;
        }

        public static bool TryGetAlpha(string hex, out byte alpha)
        {
            alpha = Byte.MaxValue;

            if (HasValidHexSyntax(hex))
                return false;
            
            

            return false;
        }

        public static bool TryGetRed(string hex, out byte red)
        {
            red = Byte.MaxValue;

            if (HasValidHexSyntax(hex))
                return false;



            return false;
        }

        public static bool TryGetGreen(string hex, out byte green)
        {
            green = Byte.MaxValue;

            if (HasValidHexSyntax(hex))
                return false;

            return false;
        }

        public static bool TryGetBlue(string hex, out byte blue)
        {
            blue = Byte.MaxValue;

            if (HasValidHexSyntax(hex))
                return false;

            return false;
        }

        // TODO: make private after unit test.
        public static bool HasValidHexSyntax(this string hex)
        {
            if (string.IsNullOrEmpty(hex) || (!hex.Contains('#') || !hex.Contains('\x23')) || hex.Length != 9)
                return false;
            return true;
        }

        public static bool HasHashAsFirstCharacter(this string hex)
        {
            if (hex[1] == '#' || hex[1] == '\x23')
                return true;
            return false;
        }

        public static bool HasValidHexCharacters(this string hex)
        {
            if (!HasValidHexSyntax(hex))
                return false;

            int i = 0;
            if (HasHashAsFirstCharacter(hex))
                i = 1;

            for (; i < hex.Length - 1; i++)
                if (!Regex.Match(hex[i].ToString(), @"\d").Success | !Regex.Match(hex[i].ToString(), @"[a-f]", RegexOptions.IgnoreCase).Success)
                    return false;
            return true;
        }

    }
}
