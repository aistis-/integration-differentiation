using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class GaussianQuadrature3rd
    {
        public static double Calculate(double a, double b, int N)
        {
            double sum = 0;

            double h = (b - a) / N;
            double x;
            double xs;
            double dx;

            for (int i = 1; i <= N; i++)
            {
                x = (a + h * i + a + h * (i - 1)) / 2;
                xs = (a + h * i - a - h * (i - 1)) / 2;

                dx = xs;
                sum += dx * (
                    (5f / 9f) * Program.Function(xs * -Math.Sqrt(0.6) + x) +
                    (8f / 9f) * Program.Function(x) +
                    (5f / 9f) * Program.Function(xs * Math.Sqrt(0.6) + x)
                );
            }

            return sum;
        }

        private static double variablesTransformation(double a, double b, double s)
        {
            return (b + a - 2 * s) / (b - a);
            //return (a + b) / 2 + ((b - a) / 2) * s;
        }
    }
}
