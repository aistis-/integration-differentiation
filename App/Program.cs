using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class Program
    {
        public static void Main(string[] args)
        {
            double a = 0;
            double b = 4;
            double result;
            double misMatch;

            int[] N = {5, 10, 20, 40, 100, 500, 1000, 10000};

            Console.WriteLine("Calculations with trapezoidal rule");

            for (int i = 0; i < N.Length; i++)
            {
                result = TrapezoidalRule.Calculate(a, b, N[i]);
                misMatch = Math.Abs(result - TrapezoidalRule.Calculate(a, b, 2 * N[i])) / (Math.Pow(2, 2) - 1);
                Console.WriteLine("N = {0} result: {1} Runge's rule: {2}", N[i], result, misMatch);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Calculations with Gaussian rule (3rd)");

            for (int i = 0; i < N.Length; i++)
            {
                result = GaussianQuadrature3rd.Calculate(a, b, N[i]);
                misMatch = Math.Abs(result - GaussianQuadrature3rd.Calculate(a, b, 2 * N[i])) / (Math.Pow(2, 2) - 1);
                Console.WriteLine("N = {0} result: {1} Runge's rule: {2}", N[i], result, misMatch);
            }

            Console.ReadKey();
        }

        public static double Function(double x)
        {
            return x * Math.Pow(Math.E, 2 * x);
            //return Math.Sqrt(x) * (1 + Math.Sqrt(x));
        }
    }
}
