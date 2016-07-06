namespace DiagnosticoDeMatematicas.Charts
{
    using System.Web.UI.DataVisualization.Charting;

    /// <summary>
    /// A series specifically made to represent a vertical line.
    /// </summary>
    public class VerticalSeries : Series
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VerticalSeries"/> class.
        /// </summary>
        /// <param name="value">Value for 'x' for the vertical line.</param>
        /// <param name="chartArea">Chart area to which the series belongs.</param>
        public VerticalSeries(double value, ChartArea chartArea)
        {
            Value = value;
            ChartAreaObject = chartArea;
            ChartType = SeriesChartType.Line;

            Points.AddXY(value, ChartAreaObject.AxisY.Minimum);
            Points.AddXY(value, ChartAreaObject.AxisY.Maximum);
        }

        /// <summary>
        /// Gets the value for 'x' in which the vertical line is displayed.
        /// </summary>
        public double Value { get; }

        /// <summary>
        /// Gets the chart area to which the series belongs.
        /// </summary>
        public ChartArea ChartAreaObject { get; }
    }
}