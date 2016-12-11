using System.Collections.Generic;

namespace TimeSeries.Trend.Core
{
    // Az idősor típusa
    public class TimeSeries
    {
        #region Mezők
        // Az idősor értékeit az y lista tartalmazza
        private List<double> y;

        // Az idősorunk hossza, azaz az y elemszáma
        private int n;

        // A stratlgia meghatározása
        private TrendStrategy strategy;

        public int GetTimeSeriesLength
        {
            get
            {
                return n;
            }
        }

        #region Idősor elemeit tartalmazó lista visszaadása
        public List<double> GetTimeSeriesList
        {
            get
            {
                return y;
            }
        }
        #endregion
        #endregion

        #region Konstruktor
        public TimeSeries()
        {
            y = new List<double>();
            n = 0;
        }
        #endregion

        #region Az idősor bekérése
        public void Sety()
        {
            //y =< 4.5, 4.2, 4.3, 3.9, 5.1, 5.7 ,6.5, 6.9 >

            //y.Add(4.5);
            //y.Add(4.2);
            //y.Add(4.3);
            //y.Add(3.9);
            //y.Add(5.1);
            //y.Add(5.7);
            //y.Add(6.5);
            //y.Add(6.9);

            //16 darab
            y.Add(100);
            y.Add(122);
            y.Add(154);
            y.Add(132);

            y.Add(111);
            y.Add(144);
            y.Add(196);
            y.Add(140);

            y.Add(133);
            y.Add(156);
            y.Add(216);
            y.Add(181);

            y.Add(160);
            y.Add(190);
            y.Add(242);
            y.Add(199);

            string a = "";

            // Az idősor hossza
            n = y.Count;
        }
        #endregion

        #region Stratégia meghatározása (milyen trend alapján számoljon)
        public void SetTrendStrategy(TrendStrategy trendStrategy)
        {
            strategy = trendStrategy;
        }
        #endregion

        #region Trend metódus, ami az általunk választott trend stratégiát valósítja meg
        public void Trend()
        {
            strategy.Trend(this);
        }
        #endregion
    }
}
