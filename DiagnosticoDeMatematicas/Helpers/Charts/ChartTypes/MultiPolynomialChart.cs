namespace DiagnosticoDeMatematicas.Charts.ChartTypes
{
    using System.Collections.Generic;
    using Helpers.Functions.FunctionTypes;

    /// <summary>
    /// Type of chart containing multiple polynomials.
    /// </summary>
    public class MultiPolynomialChart : CartesianPlane
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiPolynomialChart"/> class.
        /// </summary>
        /// <param name="stringOptions">List of options. The options should have a format of "Degree CoefficientA CoefficientB..." for each polynomial.</param>
        /// <param name="minX">Minimum value for the x-axis.</param>
        /// <param name="maxX">Maximum value for the x-axis.</param>
        /// <param name="minY">Minimum value for the y-axis.</param>
        /// <param name="maxY">Maximum value for the y-axis.</param>
        public MultiPolynomialChart(string[] stringOptions, int minX, int maxX, int minY, int maxY) 
            : base(minX, maxX, minY, maxY)
        {
            if (ValidateOptions(stringOptions))
            {
                var coefficientsList = ParseOptions(stringOptions);

                var series = 0;
                foreach (var coefficients in coefficientsList)
                {
                    var polynomial = new Polynomial(coefficients);

                    var polynomialSeries = new FunctionSeries(polynomial, ChartAreas["Chart"]);
                    polynomialSeries.BorderWidth = 2;
                    if (series < SeriesColorHierarchy.Length)
                    {
                        polynomialSeries.Color = SeriesColorHierarchy[series];
                    }

                    Series.Add(polynomialSeries);
                    series++;
                }
            }
        }

        /// <summary>
        /// Gets the list of polynomials contained.
        /// </summary>
        public List<Polynomial> Polynomials { get; }

        /// <summary>
        /// Validates that the options have a correct format.
        /// </summary>
        /// <param name="options">Array containing the options.</param>
        /// <returns>Value indicating whether the options are valid.</returns>
        protected bool ValidateOptions(string[] options)
        {
            if (options.Length < 2)
            {
                return false;
            }

            bool isValid = true;

            int optionCounter = 0;
            while (optionCounter < options.Length)
            {
                var option = options[optionCounter];

                int degree = 0;
                isValid = int.TryParse(option, out degree);
                if (!isValid || degree < 0)
                {
                    return false;
                }

                if (optionCounter + degree + 1 >= options.Length)
                {
                    return false;
                }

                for (int coefficient = 0; coefficient < degree + 1; coefficient++)
                {
                    optionCounter++;
                    double aux;
                    isValid = double.TryParse(options[optionCounter], out aux);
                    if (!isValid)
                    {
                        return false;
                    }
                }

                optionCounter++;
            }

            return true;
        }

        /// <summary>
        /// Parses options into a correct format.
        /// </summary>
        /// <param name="options">Array of string options.</param>
        /// <returns>Double array of doubles.</returns>
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