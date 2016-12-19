using System;
using System.Collections.Generic;

namespace TimeSeries.Trend.Core
{
    public class ExponentialTrend : TrendStrategy
    {
        private List<int> transFormt;
        public override void Trend(TimeSeries timeSeries)
        {
            this.timeSeries = timeSeries;
            x = new List<double>();
            transFormt = new List<int>();

            for (int i = 0; i < timeSeries.GetTimeSeriesLength; i++)
            {
                transFormt.Add(0);
            }

            TransFormTMethod();
            Setx1();
            Setx2();
        }

        private void TransFormTMethod()
        {
            if (timeSeries.GetTimeSeriesLength % 2 != 0)
            {
                int s1 = 0;

                for (int i = (timeSeries.GetTimeSeriesLength / 2); i > -1; --i)
                {
                    transFormt[i] = s1;
                    s1 = s1 - 1;
                }

                int s2 = 1;

                for (int i = (timeSeries.GetTimeSeriesLength / 2) + 1; i < timeSeries.GetTimeSeriesLength; i++)
                {
                    transFormt[i] = s2;
                    s2 = s2 + 1;
                }
            }
            else
            {
                int s1 = -1;

                for (int i = (timeSeries.GetTimeSeriesLength / 2) - 1; i > -1; --i)
                {
                    transFormt[i] = s1;
                    s1 = s1 - 2;
                }

                int s2 = 1;

                for (int i = (timeSeries.GetTimeSeriesLength / 2); i < timeSeries.GetTimeSeriesLength; i++)
                {
                    transFormt[i] = s2;
                    s2 = s2 + 2;
                }
            }
        }

        private void Setx2()
        {
            double s1 = 0;
            double s2 = 0;

            for (int t = 0; t < timeSeries.GetTimeSeriesLength; ++t)
            {
                s1 = s1 + (transFormt[t] * Math.Log(timeSeries.GetTimeSeriesList[t], Math.E));
                s2 = s2 + Math.Pow(transFormt[t], 2);
            }

            x.Add(Math.Exp( s1 / s2));
        }

        private void Setx1()
        {
            double s = 0;

            for (int t = 0;  t < timeSeries.GetTimeSeriesLength;  ++t)
            {
                double tmp = Math.Log10(timeSeries.GetTimeSeriesList[t]);
                s = s + Math.Log(timeSeries.GetTimeSeriesList[t], Math.E);
            }

            x.Add(Math.Exp( s / timeSeries.GetTimeSeriesLength));
        }
    }
}