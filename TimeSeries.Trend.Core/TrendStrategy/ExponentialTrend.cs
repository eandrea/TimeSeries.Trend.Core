using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSeries.Trend.Core
{
    public class ExponentialTrend : TrendStrategy
    {
        public override void Trend(TimeSeries timeSeries)
        {
            Console.WriteLine("Megvalósítás alatt.");
        }
    }
}
