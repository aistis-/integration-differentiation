using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Globalization;

namespace App
{
    class RungeKutta
    {
        public static double Calculate(double a, double b, double h, bool print)
        {
            double u = 1;
            double x = a;

            while (x <= b)
            {
                double k1 = Program.Function2(x, u);
                double k2 = Program.Function2(x + h / 2.0, u + h * k1 / 2.0);

                if (print)
                {
                    Console.Write("(" + Math.Round(x, 4).ToString(CultureInfo.CreateSpecificCulture("en-GB"))
                        + "," + Math.Round(u, 4).ToString(CultureInfo.CreateSpecificCulture("en-GB")) + ")");
                }

                x += h;
                u += h * k2;
            }

            if (print)
            {
                Console.WriteLine();
            }
            
            return u;
        }
    }
}
