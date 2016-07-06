namespace DiagnosticoDeMatematicas.Charts.ChartTypes
{
    using Helpers.Functions.FunctionTypes;

    /// <summary>
    /// Chart containing a polynomial and its derivate.
    /// </summary>
    public class PolynomialWithDerivateChart : PolynomialChart
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PolynomialWithDerivateChart"/> class.
        /// </summary>
        /// <param name="stringCoefficients">Coefficients for the main polynomial.</param>
        /// <param name="minX">Minimum value for the x-axis.</param>
        /// <param name="maxX">Maximum value for the x-axis.</param>
        /// <param name="minY">Minimum value for the y-axis.</param>
        /// <param name="maxY">Maximum value for the y-axis.</param>
        public PolynomialWithDerivateChart(string[] stringCoefficients, int minX, int maxX, int minY, int maxY) 
            : base(stringCoefficients, minX, maxX, minY, maxY)
        {
            if (ValidateCoefficients(stringCoefficients))
            {
                var coefficients = ParseCoefficients(stringCoefficients);

                Derivate = Polynomial.Derivate() as Polynomial;

                var derivateSeries = new FunctionSeries(new Polynomial(coefficients).Derivate(), ChartAreas["Chart"]);
                derivateSeries.BorderWidth = 2;
                derivateSeries.Color = SeriesColorHierarchy[1];

                Series.Add(derivateSeries);
            }
        }

        /// <summary>
        /// Gets the derivate of the polynomial.
        /// </summary>
        public Polynomial Derivate { get; }
    }
}