using System;
using System.Collections.Generic;
using System.Windows;

namespace CurveFitting.Clases
{
    internal class Generador
    {
        public List<(float, float)>? ListDataSet { get; set; }
        public float Beta0 { get; set; }
        public float Beta1 { get; set; }
        public string Ecuacion { get; set; }
        public Generador(List<(float, float)> dataSet)
        {
            if (dataSet.Count > 0)
            {
                ListDataSet = dataSet;
                CalcularBetas();
            }
            else
            {
                MessageBox.Show("El dataset esta vacio.");
            }
        }

        private void CalcularBetas()
        {
            float count = ((float)ListDataSet.Count);
            float sumX = 0f;
            float sumY = 0f;
            float sumXY = 0f;
            float sumXX = 0f;
            foreach ((float advertising, float sales) in ListDataSet)
            {
                sumX += advertising;
                sumY += sales;
                sumXY += advertising * sales;
                sumXX += ((float)Math.Pow(advertising, 2));
            }
            Beta1 = (count * sumXY - sumX * sumY) / (count * sumXX - ((float)Math.Pow(sumX, 2)));
            Beta0 = (sumY - Beta1 * sumX) / count;
            Ecuacion = $"y = {Beta0} + {Beta1}x";
        }

        public float PredictSales(float advertising)
        {
            if (advertising > 0)
            {
                return Beta0 + Beta1 * advertising;
            }
            else
            {
                return -1f;
            }
        }
    }
}
