namespace DiagnosticoDeMatematicas.Charts.ChartTypes
{
    using System.Collections.Generic;
    using Helpers.Functions.FunctionTypes;

    /// <summary>
    /// Chart containing a single polynomial.
    /// </summary>
    public class PolynomialChart : CartesianPlane
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PolynomialChart"/> class.
        /// </summary>
        /// <param name="stringCoefficients">Array containing the coefficients for the polynomial.</param>
        /// <param name="minX">Minimum value for the x-axis.</param>
        /// <param name="maxX">Maximum value for the x-axis.</param>
        /// <param name="minY">Minimum value for the y-axis.</param>
        /// <param name="maxY">Maximum value for the y-axis.</param>
        public PolynomialChart(string[] stringCoefficients, int minX, int maxX, int minY, int maxY) 
            : base(minX, maxX, minY, maxY)
        {
            if (ValidateCoefficients(stringCoefficients))
            {
                var coefficients = ParseCoefficients(stringCoefficients);

                Polynomial = new Polynomial(coefficients);

                var polynomialSeries = new FunctionSeries(Polynomial, ChartAreas["Chart"]);
                polynomialSeries.BorderWidth = 3;
                polynomialSeries.Color = SeriesColorHierarchy[0];

                Series.Add(polynomialSeries);
            }
        }

        /// <summary>
        /// Gets the polynomial being displayed.
        /// </summary>
        public Polynomial Polynomial { get; }

        /// <summary>
        /// Validates that the coefficients have a correct format.
        /// </summary>
        /// <param name="coefficients">Array of strings.</param>
        /// <returns>A value indicating whether the coefficients are correctly formatted.</returns>
        protected virtual bool ValidateCoefficients(string[] coefficients)
        {
            if (coefficients.Length < 1)
            {
                return false;
            }

            bool isValid = true;
            foreach (var coefficient in coefficients)
            {
                double aux;
                isValid = double.TryParse(coefficient, out aux);

                if (!isValid)
                {
                    break;
                }
            }

            return isValid;
        }

        /// <summary>
        /// Parses the coefficients into doubles.
        /// </summary>
        /// <param name="stringCoefficients">Array of strings.</param>
        /// <returns>Array of doubles.</returns>
        protected double[] ParseCoefficients(string[] stringCoefficients)
        {
            var coefficients = new List<double>();
            foreach (var coefficient in stringCoefficients)
            {
                coefficients.Add(double.Parse(coefficient));
            }

            return coefficients.ToArray();
        }
    }
}