namespace DiagnosticoDeMatematicas.Charts
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Web.UI.DataVisualization.Charting;

    /// <summary>
    /// Custom chart representing a blank cartesian plane
    /// </summary>
    public class CartesianPlane : Chart
    {
        /// <summary>
        /// Array of colors used to put hierarchy to different lines that will be put onto the cartesian plane.
        /// Blue is the primary color, red the secondary, and green the tertiary.
        /// </summary>
        protected static readonly Color[] SeriesColorHierarchy =
            {
                Color.Blue,
                Color.Red,
                Color.Green
            };

        /// <summary>
        /// Default chart height
        /// </summary>
        private const int ChartHeight = 400;

        /// <summary>
        /// Default chart width.
        /// </summary>
        private const int ChartWidth = 400;

        /// <summary>
        /// Default interval for grid.
        /// </summary>
        private const int GridInterval = 1;

        /// <summary>
        /// Default interval between axis labels.
        /// </summary>
        private const int AxisInterval = 2;

        /// <summary>
        /// Default location for x-axis and y-axis.
        /// </summary>
        private const int AxisCenter = 0;

        /// <summary>
        /// Back color of the chart.
        /// </summary>
        private static readonly Color DefaultBackColor = Color.Transparent;

        /// <summary>
        /// Color for the x-axis and y-axis.
        /// </summary>
        private static readonly Color AxisColor = Color.Black;

        /// <summary>
        /// Color for the grid
        /// </summary>
        private static readonly Color GridColor = Color.LightGray;

        /// <summary>
        /// Initializes a new instance of the <see cref="CartesianPlane"/> class.
        /// </summary>
        /// <param name="minX">Minimum value for the x-axis.</param>
        /// <param name="maxX">Maximum value for the x-axis</param>
        /// <param name="minY">Minimum value for the y-axis.</param>
        /// <param name="maxY">Maximum value for the y-axis</param>
        public CartesianPlane(int minX, int maxX, int minY, int maxY)
        {
            Width = ChartWidth;
            Height = ChartHeight;
            ChartAreas.Add("Chart").BackColor = DefaultBackColor;

            ChartAreas[0].AxisX.LineColor = AxisColor;
            ChartAreas[0].AxisX.Interval = AxisInterval;
            ChartAreas[0].AxisX.Crossing = AxisCenter;
            ChartAreas[0].AxisX.MajorGrid.LineColor = GridColor;
            ChartAreas[0].AxisX.MajorGrid.Interval = GridInterval;
            ChartAreas[0].AxisX.Minimum = minX;
            ChartAreas[0].AxisX.Maximum = maxX;

            ChartAreas[0].AxisY.LineColor = AxisColor;
            ChartAreas[0].AxisY.Interval = AxisInterval;
            ChartAreas[0].AxisY.Crossing = AxisCenter;
            ChartAreas[0].AxisY.MajorGrid.LineColor = GridColor;
            ChartAreas[0].AxisY.MajorGrid.Interval = GridInterval;
            ChartAreas[0].AxisY.Minimum = minY;
            ChartAreas[0].AxisY.Maximum = maxY;
        }

        /// <summary>
        /// Creates a string representing the image of the chart.
        /// </summary>
        /// <returns>The string representing the chart.</returns>
        public override string ToString()
        {
            MemoryStream imageStream = new MemoryStream();
            SaveImage(imageStream, ChartImageFormat.Png);
            byte[] arrbyte2 = imageStream.ToArray();
            return Convert.ToBase64String(arrbyte2);
        }
    }
}