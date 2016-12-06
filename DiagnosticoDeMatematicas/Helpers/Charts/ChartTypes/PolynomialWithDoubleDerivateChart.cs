namespace DiagnosticoDeMatematicas.Charts.ChartTypes
{
    using Helpers.Functions.FunctionTypes;

    /// <summary>
    /// Chart with a polynomial, its derivate, and its second derivate.
    /// </summary>
    public sealed class PolynomialWithDoubleDerivateChart : PolynomialWithDerivateChart
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PolynomialWithDoubleDerivateChart"/> class.
        /// </summary>
        /// <param name="stringCoefficients">Coefficients for the main polynomial.</param>
        /// <param name="minX">Minimum value for the x-axis.</param>
        /// <param name="maxX">Maximum value for the x-axis.</param>
        /// <param name="minY">Minimum value for the y-axis.</param>
        /// <param name="maxY">Maximum value for the y-axis.</param>
        public PolynomialWithDoubleDerivateChart(string[] stringCoefficients, int minX, int maxX, int minY, int maxY) 
            : base(stringCoefficients, minX, maxX, minY, maxY)
        {
            if (ValidateCoefficients(stringCoefficients))
            {
                ParseCoefficients(stringCoefficients);

                DoubleDerivate = Derivate.Derivate() as Polynomial;

                var doubleDerivateSeries = new FunctionSeries(DoubleDerivate, ChartAreas["Chart"])
                {
                    BorderWidth = 2,
                    Color = SeriesColorHierarchy[2]
                };

                Series.Add(doubleDerivateSeries);
            }
        }

        /// <summary>
        /// Gets the double derivate.
        /// </summary>
        public Polynomial DoubleDerivate { get; }
    }
}