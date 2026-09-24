using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Utilities
{
    public static class MathUtility
    {
        public static double CalculateErrorPercent(int expected, int actual)
        {
            return Math.Abs(actual - expected) / (double)expected * 100;
        }
    }
}
