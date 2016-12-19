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
            // y = < 4.5, 4.2, 4.3, 3.9, 5.1, 5.7 ,6.5, 6.9 >

            // 2008 
            //y.Add(4.5);
            //y.Add(4.2);
            //y.Add(4.3);
            //y.Add(3.9);

            //// 2009
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

        #region Második idősor bekérése
        public void Sety2()
        {
            // y = < 4.5, 4.2, 4.3, 3.9, 5.1, 5.7 ,6.5, 6.9 >

            // 2008 
            y.Add(4.5);
            y.Add(4.2);
            y.Add(4.3);
            y.Add(3.9);

            // 2009
            y.Add(5.1);
            y.Add(5.7);
            y.Add(6.5);
            y.Add(6.9);

            string a = "";

            // Az idősor hossza
            n = y.Count;
        }
        #endregion

        #region Harmadik idősor bekérése
        public void Sety3()
        {
            // y = < 4.5, 4.2, 4.3, 3.9, 5.1, 5.7 ,6.5, 6.9 >

 
            y.Add(135.8);
            y.Add(151.5);
            y.Add(157);
            y.Add(165.8);


            y.Add(182.9);
            y.Add(188.4);
            y.Add(185.3);
            y.Add(225.4);


            y.Add(341.1);
            y.Add(440.4);
            y.Add(447.2);

            string a = "";

            // Az idősor hossza
            n = y.Count;
        }
        #endregion

        #region Negyedik idősor bekérése
        public void Sety4()
        {
            // y = < 4.5, 4.2, 4.3, 3.9, 5.1, 5.7 ,6.5, 6.9 >


            y.Add(10);
            y.Add(12);
            y.Add(14);
            y.Add(15);


            y.Add(17);
            y.Add(19);
            y.Add(20);
            y.Add(21);


            y.Add(23);
            y.Add(25);
            y.Add(28);
            y.Add(30);

            y.Add(35);
            y.Add(39);
            y.Add(43);
            y.Add(46);

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