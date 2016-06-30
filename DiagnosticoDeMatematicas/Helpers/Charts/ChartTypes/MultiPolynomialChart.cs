using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticoDeMatematicas.Charts.ChartTypes
{
    public class MultiPolynomialChart : CartesianPlane
    {
        public List<Polynomial> Polynomials { get; }

        public MultiPolynomialChart(string[] stringOptions, int minX, int maxX, int minY, int maxY) 
            : base (minX, maxX, minY, maxY)
        {
            if (ValidateOptions(stringOptions))
            {
                var coefficientsList = ParseOptions(stringOptions);

                var series = 0;
                foreach (var coefficients in coefficientsList)
                {
                    var Polynomial = new Polynomial(coefficients);

                    var polynomialSeries = new FunctionSeries(Polynomial, ChartAreas["Chart"]);
                    polynomialSeries.BorderWidth = 2;
                    if (series < SERIES_COLOR_HIERARCHY.Length)
                    {
                        polynomialSeries.Color = SERIES_COLOR_HIERARCHY[series];
                    }

                    Series.Add(polynomialSeries);
                    series++;
                }
            }
        }

        protected bool ValidateOptions(string[] options)
        {
            if (options.Length < 2) return false;

            bool IsValid = true;

            int optionCounter = 0;
            while (optionCounter < options.Length)
            {
                var option = options[optionCounter];

                int degree = 0;
                IsValid = int.TryParse(option, out degree);
                if (!IsValid || degree < 0) return false;
                if (optionCounter + degree + 1 >= options.Length) return false;

                for (int coefficient = 0; coefficient < degree + 1; coefficient++)
                {
                    optionCounter++;
                    double aux;
                    IsValid = double.TryParse(options[optionCounter], out aux);
                    if (!IsValid) return false;
                }
                optionCounter++;
            }

            return true;
        }

        protected double[][] ParseOptions(string[] options)
        {
            int optionCounter = 0;
            List<double[]> coefficientsList = new List<double[]>();
            while (optionCounter < options.Length)
            {
                int degree = int.Parse(options[optionCounter]);

                List<double> coefficients = new List<double>();
                for (int coefficientCounter = 0; coefficientCounter < degree + 1; coefficientCounter++)
                {
                    optionCounter++;
                    coefficients.Add(double.Parse(options[optionCounter]));
                }

                coefficientsList.Add(coefficients.ToArray());
                optionCounter++;
            }

            return coefficientsList.ToArray();
        }
    }
}