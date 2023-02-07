using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NulledTOServerEmulator.ServerHelper.Emulator.AuthEmulator
{
    internal class Credentials
    {
        private const int NovaID = 1338;
        private const int Extra = 1338;
        private const bool Authenticated = true;

        public static string GetValidResponse()
        {
            string Emulated = $"{{\"status\":{Authenticated},\"data\":{{\"hash\":\"{GetRandomString(64)}\",\"mid\":\"{GetRandomString(7)}\",\"name\":\"ReverseLabs\",\"Likes\":\"{GetRandomNumber(100, 1000)}\",\"groups\":[\"{NovaID}\"],\"extra\":\"{Extra}\",\"message\":\"{GetRandomString(10)}\"}}}}";
            return Emulated;
        }
        private static Random ran = new Random();
        private static int GetRandomNumber(int Min, int Max)
        {
            if(Min >= Max)
            {
                Min = Max - 1;
            }
            return ran.Next(Min, Max);
        }

        private static string GetRandomString(int length)
        {
            const string chars = "qwertyuioplkjhgfdsazxcvbnmABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[ran.Next(s.Length)]).ToArray());
        }
    }
}
