using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using System.Globalization;

namespace SNEngineLib
{
    public static class ColorExtensions
    {

        public static string ConvertToHex(this Color color)
        {
            string hex = "#";

            byte[] bytes = new byte[]
            {
                color.R,
                color.G,
                color.B,
                color.A,
            };

            string[] strings = new string[4];

            for (int i = 0; i < bytes.Length; i++)
            {
                strings[i] = ConvertByte(bytes[i]);
            }

            for (int i = 0; i < strings.Length; i++)
            {
                hex += strings[i];
            }


         
            return hex;
        }

        private static string ConvertByte (byte data)
        {
            return data.ToString("x2");
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
