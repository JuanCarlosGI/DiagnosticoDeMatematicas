using System;
using System.Drawing;
using System.IO;
using System.Web.UI.DataVisualization.Charting;

namespace DiagnosticoDeMatematicas.Charts
{
    public class CartesianPlane : Chart
    {
        private static readonly Color BACK_COLOR = Color.Transparent;
        private static readonly Color AXIS_COLOR = Color.Black;
        private static readonly Color GRID_COLOR = Color.LightGray;

        protected static readonly Color[] SERIES_COLOR_HIERARCHY =
            new Color[]
            {
                Color.Blue,
                Color.Red,
                Color.Green
            };

        private const int CHART_HEIGHT = 400;
        private const int CHART_WIDTH = 400;
        private const int GRID_INTERVAL = 1;
        private const int AXIS_INTERVAL = 2;
        private const int AXIS_CENTER = 0;

        public CartesianPlane(int minX, int maxX, int minY, int maxY) : base()
        {
            Width = CHART_WIDTH;
            Height = CHART_HEIGHT;
            ChartAreas.Add("Chart").BackColor = BACK_COLOR;

            ChartAreas[0].AxisX.LineColor = AXIS_COLOR;
            ChartAreas[0].AxisX.Interval = AXIS_INTERVAL;
            ChartAreas[0].AxisX.Crossing = AXIS_CENTER;
            ChartAreas[0].AxisX.MajorGrid.LineColor = GRID_COLOR;
            ChartAreas[0].AxisX.MajorGrid.Interval = GRID_INTERVAL;
            ChartAreas[0].AxisX.Minimum = minX;
            ChartAreas[0].AxisX.Maximum = maxX;

            ChartAreas[0].AxisY.LineColor = AXIS_COLOR;
            ChartAreas[0].AxisY.Interval = AXIS_INTERVAL;
            ChartAreas[0].AxisY.Crossing = AXIS_CENTER;
            ChartAreas[0].AxisY.MajorGrid.LineColor = GRID_COLOR;
            ChartAreas[0].AxisY.MajorGrid.Interval = GRID_INTERVAL;
            ChartAreas[0].AxisY.Minimum = minY;
            ChartAreas[0].AxisY.Maximum = maxY;
        }

        public override string ToString()
        {
            MemoryStream imageStream = new MemoryStream();
            SaveImage(imageStream, ChartImageFormat.Png);
            byte[] arrbyte2 = imageStream.ToArray();
            return Convert.ToBase64String(arrbyte2);
        }
    }
}