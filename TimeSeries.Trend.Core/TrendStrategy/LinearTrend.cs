using System;
using System.Collections.Generic;
using System.Linq;

namespace TimeSeries.Trend.Core
{
    public class LinearTrend : TrendStrategy
    {
        public LinearTrend()
        {
            b = new List<double>();
            A = new List<List<double>>();
            timeSeries = new TimeSeries();
            normalEquations = new SystemOfLinearEquations();
            x = new List<double>();
        }

        public override void Trend(TimeSeries timeSeries)
        {
            this.timeSeries = timeSeries;

            Setb1InFirstNormalEquation();
            b.Add(b1);

            Setb2InSecondNormalEquation();
            b.Add(b2);

            SetA();

            normalEquations.SetA(A);
            normalEquations.Setb(b);

            x = normalEquations.GaussMethod();

            double firstPointValue = x[0] + 1 * x[1];
            double secondPointValue = x[0] + timeSeries.GetTimeSeriesLength * x[1];

            KeyValuePair<int, double> firstPoint = new KeyValuePair<int, double>(0, firstPointValue);
            KeyValuePair<int, double> secondPoint = new KeyValuePair<int, double>(timeSeries.GetTimeSeriesLength-1, secondPointValue);

            Console.WriteLine("{");
            int i = 1;
            foreach (var item in timeSeries.GetTimeSeriesList) 
            {
                if (timeSeries.GetTimeSeriesList.Count == i)
                {
                    Console.WriteLine("{0}", item.ToString().Replace(",", "."));
                }
                else
                {
                    Console.WriteLine("{0},", item.ToString().Replace(",", "."));
                }

                ++i;
            }

            Console.WriteLine("]");

            Console.WriteLine();
            Console.WriteLine("[{0},{1}],", firstPoint.Key, firstPoint.Value.ToString().Replace(",", "."));
            Console.WriteLine("[{0},{1}]", secondPoint.Key, secondPoint.Value.ToString().Replace(",", "."));
            Console.WriteLine();

            Console.WriteLine("y = {0} + ({1}*t)", x[0].ToString().Replace(",", "."), x[1].ToString().Replace(",", "."));

        }

        private void SetA()
        {
            List<double> firstRow = new List<double>();
            firstRow.Add(timeSeries.GetTimeSeriesLength);
            firstRow.Add(SettSum());

            List<double> secondRow = new List<double>();
            secondRow.Add(SettSum());
            secondRow.Add(SettPow2Sum());

            A.Add(firstRow);
            A.Add(secondRow);
        }

        private int SettSum()
        {
            int s = 0;

            for ( int t = 0; t < timeSeries.GetTimeSeriesLength; ++t)
            {
                s = s + (t + 1);
            }

            return s;
        }

        private double SettPow2Sum()
        {
            double s = 0;

            for (int t = 0; t < timeSeries.GetTimeSeriesLength; ++t)
            {
                s = s + Math.Pow((t + 1), 2);
            }

            return s;
        }

        #region Első normálegyenlet baloldalának meghatározása
        private void Setb1InFirstNormalEquation()
        {
            b1 = 0;

            //Összegzés programozási tétel
            //for (int t = 0; t < timeSeries.GetTimeSeriesLength; ++t)
            //{
            //    b1 = b1 + timeSeries.GetTimeSeriesList[t];
            //}

            // Lambda kifejezés
            // A  lista adatszerkezet tartalmaz előre definiált műveleteket.
            // Ilyen pl. a Sum, melyet úgy használunk, hogy: Sum(e => e) esetén
            // az első e jelöli azt az elemet, amely felveszi a lista összes elemét egymás után
            // A második e helyén pedig meghatározzuk, hogy az aktuális elemmel mit akarunk csinálni.

            b1 = timeSeries.GetTimeSeriesList.Sum(e => e);
        }
        #endregion

        #region Második normálegyenlet baloldalának meghatározása
        private void Setb2InSecondNormalEquation()
        {
            b2 = 0;

            for (int t = 0; t < timeSeries.GetTimeSeriesLength; ++t)
            {
                b2 = b2 + (t + 1) * timeSeries.GetTimeSeriesList[t];
            }
        }
        #endregion
    }
}