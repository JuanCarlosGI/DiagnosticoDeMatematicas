using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.DataVisualization.Charting;

namespace DiagnosticoDeMatematicas.Charts
{
    public class VerticalSeries : Series
    {
        public double Value { set; get; }
        public ChartArea ChartAreaObject { get; }

        public VerticalSeries(double value, ChartArea chartArea)
        {
            Value = value;
            ChartAreaObject = chartArea;
            ChartType = SeriesChartType.Line;

            Points.AddXY(value, ChartAreaObject.AxisY.Minimum);
            Points.AddXY(value, ChartAreaObject.AxisY.Maximum);
        }
    }
}