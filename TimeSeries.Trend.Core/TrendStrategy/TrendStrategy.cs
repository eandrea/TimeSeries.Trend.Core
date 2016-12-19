using System.Collections.Generic;

namespace TimeSeries.Trend.Core
{
    //  Az idősor trendjét meghatározó absztrakt osztály
    // A strategy tervezési mintát valósítja meg
    // Ez lesz a szülőosztály és a leszrátmazottaknak
    // (stratégiáknak) meg kell valósítaniuk a Trend metódust,
    // amely egy TimeSeries-t vár paraméterként.
    public abstract class TrendStrategy
    {
        // A normálegyenletekben szereplő b vektor elemei
        protected double b1, b2;

        // A b vektor
        // protected: Csak ez az osztály és az öröklött osztályok láthatják
        protected List<double> b;

        // A együttható mátrix
        protected List<List<double>> A;

        // A normálegyenleteink gyökeihez
        protected List<double> x;

        // Egy idősor
        protected TimeSeries timeSeries;

        // A lineráris egyenletrendszerünk tárolásához és megoldásához
        protected SystemOfLinearEquations normalEquations;

        public abstract void Trend(TimeSeries timeSeries);
    }
}