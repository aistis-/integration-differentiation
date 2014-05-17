using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class TrapezoidalRule
    {
        public static void calculate(double a, double b, int N)
        {
            double result = calculateSum(a, b, N);
            double resultForMismatch = calculateSum(a, b, 2 * N);

            Console.WriteLine("Calculated with trapezoidal rule: " + result);

            double misMatch = Math.Abs(result - resultForMismatch) / 3;

            Console.WriteLine("Mismatch by Runge's rule: " + misMatch);
        }

        private static double calculateSum(double a, double b, int N)
        {
            double sum = 0;
            double h = (b - a) / (N - 1); // step size


            for (int i = 0; i < N; i++)
            {
                sum += h * (Program.calculateWithFormula(a + i * h) + Program.calculateWithFormula(a + (i + 1) * h)) / 2;
            }

            return sum;
        }
    }
}
