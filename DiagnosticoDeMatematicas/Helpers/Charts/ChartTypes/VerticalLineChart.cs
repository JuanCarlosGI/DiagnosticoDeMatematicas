namespace DiagnosticoDeMatematicas.Charts.ChartTypes
{
    /// <summary>
    /// Chart displaying a vertical line.
    /// </summary>
    public class VerticalLineChart : CartesianPlane
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VerticalLineChart"/> class.
        /// </summary>
        /// <param name="stringValue">The value for x in which the vertical line will be shown.</param>
        /// <param name="minX">Minimum value for the x-axis.</param>
        /// <param name="maxX">Maximum value for the x-axis.</param>
        /// <param name="minY">Minimum value for the y-axis.</param>
        /// <param name="maxY">Maximum value for the y-axis.</param>
        public VerticalLineChart(string[] stringValue, int minX, int maxX, int minY, int maxY) : base(minX, maxX, minY, maxY)
        {
            if (ValidateOptions(stringValue))
            {
                var value = ParseOptions(stringValue);

                var series = new VerticalSeries(value, ChartAreas["Chart"]);
                series.Color = SeriesColorHierarchy[0];
                series.BorderWidth = 3;

                Series.Add(series);
            }
        }

        /// <summary>
        /// Validates that the options contain a single string representing a double.
        /// </summary>
        /// <param name="options">Array of options.</param>
        /// <returns>Value indicating whether the format if correct.</returns>
        protected bool ValidateOptions(string[] options)
        {
            if (options.Length != 1)
            {
                return false;
            }

            double aux;
            return double.TryParse(options[0], out aux);
        }

        /// <summary>
        /// Parses the options into a single double.
        /// </summary>
        /// <param name="options">Array of strings containing the options.</param>
        /// <returns>The double value represented by that options.</returns>
        protected double ParseOptions(string[] options)
        {
            return double.Parse(options[0]);
        }
    }
}