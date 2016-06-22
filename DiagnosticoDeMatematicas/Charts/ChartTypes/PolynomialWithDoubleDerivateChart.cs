using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticoDeMatematicas.Charts.ChartTypes
{
    public class PolynomialWithDoubleDerivateChart : PolynomialWithDerivateChart
    {
        public Polynomial DoubleDerivate { get; }

        public PolynomialWithDoubleDerivateChart(string[] stringCoefficients, int minX, int maxX, int minY, int maxY) 
            : base (stringCoefficients, minX, maxX, minY, maxY)
        {
            if (ValidateCoefficients(stringCoefficients))
            {
                var coefficients = ParseCoefficients(stringCoefficients);

                DoubleDerivate = Derivate.Derivate() as Polynomial;

                var doubleDerivateSeries = new FunctionSeries(new Polynomial(coefficients).Derivate(), ChartAreas["Chart"]);
                doubleDerivateSeries.BorderWidth = 2;
                doubleDerivateSeries.Color = SERIES_COLOR_HIERARCHY[2];

                Series.Add(doubleDerivateSeries);
            }
        }

        protected override bool ValidateCoefficients(string[] coefficients)
        {
            if (coefficients.Length < 3) return false;

            bool IsValid = true;
            foreach (var coefficient in coefficients)
            {
                double aux;
                IsValid = double.TryParse(coefficient, out aux);

                if (!IsValid) break;
            }

            return IsValid;
        }
    }
}