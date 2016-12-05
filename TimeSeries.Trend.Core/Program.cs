using Gauss.MyType;
using System;
using System.Collections.Generic;

namespace TimeSeries.Trend.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            SystemOfLinearEquations a = new SystemOfLinearEquations();
            a.SetA(2);
            a.Setb();
            List<double> x = a.GaussMethod();

            int i = 1;
            foreach (double item in x)
            {
                Console.WriteLine("x{0}= {1}", i, item);
                ++i;
            }

            Console.ReadKey();
        }
    }
}
