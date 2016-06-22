using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticoDeMatematicas.Charts.ChartTypes
{
    public class PolynomialChart : CartesianPlane
    {
        public Polynomial Polynomial { get; }

        public PolynomialChart(string[] stringCoefficients, int minX, int maxX, int minY, int maxY) 
            : base (minX, maxX, minY, maxY)
        {
            if (ValidateCoefficients(stringCoefficients))
            {
                var coefficients = ParseCoefficients(stringCoefficients);

                Polynomial = new Polynomial(coefficients);

                var polynomialSeries = new FunctionSeries(Polynomial, ChartAreas["Chart"]);
                polynomialSeries.BorderWidth = 3;
                polynomialSeries.Color = SERIES_COLOR_HIERARCHY[0];

                Series.Add(polynomialSeries);
            }
        }

        protected virtual bool ValidateCoefficients(string[] coefficients)
        {
            if (coefficients.Length < 1) return false;

            bool IsValid = true;
            foreach(var coefficient in coefficients)
            {
                double aux;
                IsValid = double.TryParse(coefficient, out aux);

                if (!IsValid) break;
            }

            return IsValid;
        }

        protected double[] ParseCoefficients(string[] coefficients)
        {
            var Coefficients = new List<double>();
            foreach (var coefficient in coefficients)
            {
                Coefficients.Add(double.Parse(coefficient));
            }

            return Coefficients.ToArray();
        }
    }
}