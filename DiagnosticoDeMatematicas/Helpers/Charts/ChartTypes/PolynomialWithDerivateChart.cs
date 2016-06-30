using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticoDeMatematicas.Charts.ChartTypes
{
    public class PolynomialWithDerivateChart : PolynomialChart
    {
        public Polynomial Derivate { get; }

        public PolynomialWithDerivateChart(string[] stringCoefficients, int minX, int maxX, int minY, int maxY) 
            : base (stringCoefficients, minX, maxX, minY, maxY)
        {
            if (ValidateCoefficients(stringCoefficients))
            {
                var coefficients = ParseCoefficients(stringCoefficients);

                Derivate = Polynomial.Derivate() as Polynomial;

                var derivateSeries = new FunctionSeries(new Polynomial(coefficients).Derivate(), ChartAreas["Chart"]);
                derivateSeries.BorderWidth = 2;
                derivateSeries.Color = SERIES_COLOR_HIERARCHY[1];

                Series.Add(derivateSeries);
            }
        }

        protected override bool ValidateCoefficients(string[] coefficients)
        {
            if (coefficients.Length < 2) return false;

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