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
            double a = 1;
            double b = 9;
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
                misMatch = Math.Abs(result - GaussianQuadrature3rd.Calculate(a, b, 2 * N[i])) / (Math.Pow(2, 4) - 1);
                Console.WriteLine("N = {0} result: {1} Runge's rule: {2}", N[i], result, misMatch);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Calculations with Runge and Kutta method");

            double[] h = {0.1, 0.05, 0.025, 0.0125};
            a = 0;
            b = 1;

            for (int i = 0; i < h.Length; i++)
            {
                Console.WriteLine();
                result = RungeKutta.Calculate(a, b, h[i], true);
                misMatch = Math.Abs(RungeKutta.Calculate(a, b, h[i] / 2.0, false) - result) / (Math.Pow(2, 2) - 1);
                Console.WriteLine("h = {0} result: {1} Runge's rule: {2}", h[i], result, misMatch);
            }

            Console.ReadKey();
        }

        public static double Function(double x)
        {
            return Math.Sqrt(x) * (1 + Math.Sqrt(x));
        }

        public static double Function2(double x, double u)
        {
            return -u + Math.Sin(x);
            //return (0.7 - Math.Pow(u, 2)) * Math.Cos(x) + 0.3 * u;
        }
    }
}
