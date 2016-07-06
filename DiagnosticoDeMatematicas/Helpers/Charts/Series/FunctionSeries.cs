namespace DiagnosticoDeMatematicas.Charts
{
    using System.Web.UI.DataVisualization.Charting;
    using Helpers.Functions;

    /// <summary>
    /// Series specifically made to represent a function.
    /// </summary>
    public class FunctionSeries : Series
    {
        /// <summary>
        /// Amount of intervals, or data points, that the series will contain.
        /// </summary>
        private const int AmountOfIntervals = 200;

        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionSeries"/> class.
        /// </summary>
        /// <param name="function">Function to be represented.</param>
        /// <param name="chartArea">Chart area to which this series belongs.</param>
        public FunctionSeries(Function function, ChartArea chartArea)
        {
            Function = function;
            ChartAreaObject = chartArea;
            ChartType = SeriesChartType.Line;

            var delta = (ChartAreaObject.AxisX.Maximum - ChartAreaObject.AxisX.Minimum) / AmountOfIntervals;
            for (int point = 0; point <= AmountOfIntervals + 1; point++)
            {
                var x = ChartAreaObject.AxisX.Minimum + (point * delta);
                Points.AddXY(x, Function.Evaluate(x));
            }
        }

        /// <summary>
        /// Gets the function that is being represented.
        /// </summary>
        public Function Function { get; }

        /// <summary>
        /// Gets the chart area to which the series belongs.
        /// </summary>
        public ChartArea ChartAreaObject { get; }
    }
}