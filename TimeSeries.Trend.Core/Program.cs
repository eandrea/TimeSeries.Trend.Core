using System;
using System.Collections.Generic;

namespace TimeSeries.Trend.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeSeries munkanelkulisegirata20082009 = new TimeSeries();
            munkanelkulisegirata20082009.Sety();
            munkanelkulisegirata20082009.SetTrendStrategy(new LinearTrend());
            munkanelkulisegirata20082009.Trend();
            
            Console.ReadKey();
        }
    }
}
