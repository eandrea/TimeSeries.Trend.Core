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

            y.Add(4.5);
            y.Add(4.2);
            y.Add(4.3);
            y.Add(3.9);
            y.Add(5.1);
            y.Add(5.7);
            y.Add(6.5);
            y.Add(6.9);

            // Az idősor hossza
            n = y.Count;
        }
        #endregion
    }
}
