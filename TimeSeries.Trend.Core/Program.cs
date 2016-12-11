using System;
using System.Collections.Generic;

namespace TimeSeries.Trend.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TimeSeries> timeSeriesList = new List<TimeSeries>();

            TimeSeries munkanelkulisegirata20082009Linear = new TimeSeries();
            munkanelkulisegirata20082009Linear.Sety();
            munkanelkulisegirata20082009Linear.SetTrendStrategy(new LinearTrend());


            TimeSeries munkanelkulisegirata20082009Exponential = new TimeSeries();
            munkanelkulisegirata20082009Exponential.Sety2();
            munkanelkulisegirata20082009Exponential.SetTrendStrategy(new ExponentialTrend());

            timeSeriesList.Add(munkanelkulisegirata20082009Linear);
            timeSeriesList.Add(munkanelkulisegirata20082009Exponential);

            foreach (TimeSeries item in timeSeriesList)
            {
                item.Trend();
                Console.WriteLine();
            }

            //double c = Math.Log(5, Math.E);

            ////Console.WriteLine("e^{0} = {1}",c, Math.Pow(Math.E,c));

            Console.ReadKey();
        }
    }
}
