using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class TrapezoidalRule
    {
        public static double Calculate(double a, double b, int N)
        {
            double sum = 0;
            double h = (b - a) / (N - 1); // step size


            for (int i = 0; i < N; i++)
            {
                sum += h * (Program.Function(a + i * h) + Program.Function(a + (i + 1) * h)) / 2;
            }

            return sum;
        }
    }
}
