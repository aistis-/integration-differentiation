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

            int N = 10000;

            TrapezoidalRule.calculate(a, b, N);

            Console.ReadKey();
        }

        public static double calculateWithFormula(double x)
        {
            return Math.Sqrt(x) * (1 + Math.Sqrt(x));
        }
    }
}
