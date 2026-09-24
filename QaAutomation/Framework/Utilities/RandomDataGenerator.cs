using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Utilities
{
    public static class RandomDataGenerator
    {
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        public static string GenerateText(int length = 10)
        {
            var random = new Random();
            char[] result = new char[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = chars[random.Next(chars.Length)];
            }
            return new string(result);
        }

        public static int GetInt(int min, int max)
        {
            return new Random().Next(min, max + 1);
        }
    }
}
