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
            double nextResult;
            double misMatch = -1;
            double e = 0.001;
            double ratio;
            double previousMismatch = -1; ;

            int N = 1;

            Console.WriteLine("Calculations with trapezoidal rule");

            result = TrapezoidalRule.Calculate(a, b, N);

            Console.WriteLine("N = {0} result: {1}", N, result);

            while (misMatch > e || misMatch == -1)
            {
                N *= 2;

                nextResult = TrapezoidalRule.Calculate(a, b, N);
                misMatch = Math.Abs(result - nextResult) / (Math.Pow(2, 2) - 1);

                if (-1 == previousMismatch)
                {
                    ratio = 0;
                }
                else
                {
                    ratio = previousMismatch / misMatch;
                }

                previousMismatch = misMatch;

                Console.WriteLine("N = {0} result: {1} Runge's rule: {2}\nRatio: {3}\n", N, nextResult, misMatch, ratio);

                result = nextResult;
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Calculations with Gaussian rule (3rd)");

            N = 1;
            misMatch = -1;
            previousMismatch = -1;

            result = GaussianQuadrature3rd.Calculate(a, b, N);

            Console.WriteLine("N = {0} result: {1}", N, result);

            while (misMatch > e || misMatch == -1)
            {
                N *= 2;

                nextResult = GaussianQuadrature3rd.Calculate(a, b, N);
                misMatch = Math.Abs(result - nextResult) / (Math.Pow(2, 4) - 1);

                if (-1 == previousMismatch)
                {
                    ratio = 0;
                }
                else
                {
                    ratio = previousMismatch / misMatch;
                }

                previousMismatch = misMatch;

                Console.WriteLine("N = {0} result: {1} Runge's rule: {2}\nRatio: {3}\n", N, nextResult, misMatch, ratio);

                result = nextResult;
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Calculations with Runge and Kutta method\n");

            previousMismatch = -1;
            misMatch = -1;
            double h = 0.1;
            a = 0;
            b = 1;
            e = 0.00001;

            result = RungeKutta.Calculate(a, b, h, true);

            Console.WriteLine("h = {0} result: {1}", h, result);

            while (misMatch > e || misMatch == -1)
            {
                Console.WriteLine();

                h /= 2.0;

                nextResult = RungeKutta.Calculate(a, b, h, true);

                misMatch = Math.Abs(result - nextResult) / (Math.Pow(2, 4) - 1);

                if (-1 == previousMismatch)
                {
                    ratio = 0;
                }
                else
                {
                    ratio = previousMismatch / misMatch;
                }

                previousMismatch = misMatch;

                Console.WriteLine("h = {0} result: {1} Runge's rule: {2}\nRatio: {3}\n", h, nextResult, misMatch, ratio);

                result = nextResult;
            }

            Console.ReadKey();
        }

        public static double Function(double x)
        {
            return Math.Sqrt(x) * (1 + Math.Sqrt(x));
        }
        
        public static double Function2(double x, double u)
        {
            return (0.7 - Math.Pow(u, 2)) * x + 0.3 * u;
        }
    }
}
