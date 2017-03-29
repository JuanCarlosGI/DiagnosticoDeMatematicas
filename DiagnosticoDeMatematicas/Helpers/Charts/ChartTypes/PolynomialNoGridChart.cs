using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using DiagnosticoDeMatematicas.Charts.ChartTypes;

namespace DiagnosticoDeMatematicas.Charts.ChartTypes
{
    public class PolynomialNoGridChart : PolynomialChart
    {
        public PolynomialNoGridChart(string[] stringCoefficients, int minX, int maxX, int minY, int maxY)
            : base(stringCoefficients, minX, maxX, minY, maxY)
        {
            ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

            ChartAreas[0].AxisX.MajorTickMark.LineWidth = 0;
            ChartAreas[0].AxisY.MajorTickMark.LineWidth = 0;

            /*
            ChartAreas[0].AxisX.Title = "x";
            var font = ChartAreas[0].AxisX.TitleFont;
            ChartAreas[0].AxisX.TitleFont = new Font(font.Name, 16);
            ChartAreas[0].AxisY.Title = "y";
            ChartAreas[0].AxisY.TitleFont = new Font(font.Name, 16);
            */

            ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            ChartAreas[0].AxisY.LabelStyle.Enabled = false;
        }
    }
}