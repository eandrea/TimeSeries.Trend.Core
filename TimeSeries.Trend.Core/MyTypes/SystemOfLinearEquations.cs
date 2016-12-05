﻿using System;
using System.Collections.Generic;

namespace Gauss.MyType
{
    // Lineáris egyenletrendszereink típusa
    public class SystemOfLinearEquations
    {
        #region Mezők

        #region Együttható mátrix 
        private List<List<double>> A;
        #endregion

        #region b vektor
        private List<double> b;
        #endregion

        #region Egyenletek száma
        private int n;
        #endregion

        #endregion

        // Konstruktor létrehozása. Feladata, hogy inicializál elemeket
        public SystemOfLinearEquations()
        {
            A = new List<List<double>>();
            b = new List<double>();
        }

        #region A mátrix feltöltése
        public void SetA(int rowSize)
        {
            n = rowSize;
            // 41,1 = 8 * x1 + 36 * x2
            // 201,8 = 36 * x1 + 204 * x2

            List<double> first = new List<double>();
            first.Add(8);
            first.Add(36);

            List<double> second = new List<double>();
            second.Add(36);
            second.Add(204);

            A.Add(first);
            A.Add(second);
        }
        #endregion

        #region b vektor feltöltése
        public void Setb()
        {
            b.Add(41.1);
            b.Add(201.8);
        }
        #endregion

        #region Gauss Elimináció megvalósítása
        public List<double> GaussMethod()
        {
            List<double> x = new List<double>();

            for (int k = 0; k < n - 1; ++k)
            {
                for (int i = k + 1; i < n; ++i)
                {
                    // Részleges főelemkiválasztást hajtunk végre, ha a k-adik pivotelem 0 vagy 0-hoz közeli.
                    if (A[k][k] == 0 || A[k][k] < Math.Pow(10, -1))
                    {
                        //Részleges főelemkiválasztás (bemenő paraméterek: A együttható mátrix, b vektor, n a sorok száma
                        // és k az aktuális lépés.
                        PartialPivoting(A, b, n, k);
                    }

                    double gammaik = A[i][k] / A[k][k];

                    for (int h = k + 1; h < n; ++h)
                    {
                        A[i][h] = A[i][h] - gammaik * A[k][h];
                    }

                    b[i] -= gammaik * b[k];
                }
            }

            //Visszahelyettesítés
            x = Replacement(A, b, n);

            //Eredményvektor
            return x;
        }
        #endregion

        #region Részleges főelemkiválasztás
        private void PartialPivoting(List<List<double>> A, List<double> b, int n, int k)
        {
            //A[k,k] a k-adik pivotelem, mely alap esetben nem megfelelő, ha 0 értékű.
            // Részleges főelemkiválasztással adjuk meg A[k,k] értékét.
            double maxAkk = Math.Abs(A[k][k]);
            int maxIndex = k;

            for (int g = k; g < n; ++g)
            {
                if (Math.Abs(A[k][g]) > maxAkk)
                {
                    maxAkk = Math.Abs(A[g][k]);
                    maxIndex = g;
                }
            }
            //Sorcsere : maxindex és a k sorok cseréje ( A mátrixban és a b vektorban )
            RowSwap(maxIndex, k, ref A, ref b);
        }
        #endregion

        #region Sorok cseréje ( A mátrix és b vektor esetén )
        private void RowSwap(int maxIndex, int k, ref List<List<double>> A, ref List<double> b)
        {
            List<double> maxIndexRow = new List<double>();
            List<double> kIndexRow = new List<double>();

            for (int j = 0; j < n; j++)
            {
                maxIndexRow.Add(A[maxIndex][j]);
            }

            for (int j = 0; j < n; j++)
            {
                kIndexRow.Add(A[k][j]);
            }

            // Sorcsere az A mátrixban
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == maxIndex)
                    {
                        A[i][j] = kIndexRow[j];
                    }
                    else if (i == k)
                    {
                        A[i][j] = maxIndexRow[j];
                    }
                }
            }

            // b vektor elemeinek cseréje
            double kIndexnItem = b[k];
            double maxIndexbItem = b[maxIndex];

            for (int i = 0; i < b.Count; i++)
            {
                if (i == k)
                {
                    b[i] = maxIndexbItem;
                }
                else if (i == maxIndex)
                {
                    b[i] = kIndexnItem;
                }
            }
        }
        #endregion

        #region Visszahelyettesítés
        private List<double> Replacement(List<List<double>> A, List<double> b, int n)
        {
            //x a megoldásvektorunk
            List<double> x = new List<double>();

            //Kezdetben feltöltjük az x vektort n db nullával. todo: tömörebben
            for (int k = 0; k < n; ++k)
                x.Add(0);

            //Az x vektorunk n hosszú, tehát az indexelése 0..(n-1) intervallum  között történik
            x[n - 1] = b[n - 1] / A[n - 1][n - 1];

            for (int i = n - 2; i >= 0; --i)
            {
                //Összegzés programozási tétel
                double S = 0;
                for (int j = i + 1; j < n; ++j)
                {
                    S += A[i][j] * x[j];
                }

                x[i] = (b[i] - S) / A[i][i];
            }

            return x;
        }
        #endregion 
    }
}
