using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika4_Bykov_Denisov
{
    public static class MathFunctions
    {
        /// <summary>
        /// Вычисление функции c
        /// </summary>
        public static double CalcC(double x, double y, double z)
        {
            double part1 = Math.Pow(2, Math.Pow(y, x));
            double part2 = Math.Pow(3, x) * y;
            double part3 = y * (Math.Atan(z) - Math.PI / 6);
            double part4 = Math.Abs(x) + 1 / (Math.Pow(y, 2) + 1);

            return part1 + part2 - part3 / part4;
        }

        /// <summary>
        /// Вычисление функции b
        /// </summary>
        public static double CalcB(double x, double y)
        {
            double fx = Math.Sin(x);

            if (y == 0)
                return 0;

            if (x == 0)
                return Math.Pow(fx * fx + y, 3);

            if (x / y > 0)
                return Math.Log(fx) + Math.Pow(fx * fx + y, 3);

            return Math.Log(Math.Abs(fx / y)) +
                   Math.Pow(fx + y, 3);
        }

        /// <summary>
        /// Вычисление функции y(x)
        /// </summary>
        public static double CalcY(double x, double b)
        {
            return 9 * (Math.Pow(x, 3) + Math.Pow(b, 3))
                   * Math.Tan(x);
        }
    }
}
