using Microsoft.Xna.Framework;
using System;

namespace SNEngineLib.Converters
{
    public static class HexColorConverter
    {
        private const int LENGTH = 2;

        private const string START_SYMBOL_HEX = "#";

        public static Color ColorFromHex( string hex)
        {
            if (string.IsNullOrEmpty(hex))
            {
                throw new ArgumentNullException(nameof(hex));
            }

            if (hex.IndexOf(START_SYMBOL_HEX) != -1)
            {
                hex = hex.Replace(START_SYMBOL_HEX, string.Empty);
            }

            int startIndex = 0;

            byte[] argb = new byte[4];

            for (int i = 0; i < argb.Length; i++)
            {
                string subString = hex.Substring(startIndex, LENGTH);

                startIndex += LENGTH;

                argb[i] = HexaDecimalToDecimal(subString);
            }

            return new Color(argb[0], argb[1], argb[2], argb[3]);


        }

        private static byte HexaDecimalToDecimal(string hex)
        {
            hex = hex.ToUpper();

            int hexLength = hex.Length;
            double decimalValue = 0;

            for (int i = 0; i < hexLength; ++i)
            {
                byte b = (byte)hex[i];

                if (b >= 48 && b <= 57)
                    b -= 48;
                else if (b >= 65 && b <= 70)
                    b -= 55;

                decimalValue += b * Math.Pow(16, ((hexLength - i) - 1));
            }

            return (byte)decimalValue;
        }
    }
}
