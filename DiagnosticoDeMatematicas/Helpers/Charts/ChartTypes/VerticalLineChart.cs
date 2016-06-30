using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticoDeMatematicas.Charts.ChartTypes
{
    public class VerticalLineChart : CartesianPlane
    {
        public VerticalLineChart(string[] stringValue, int minX, int maxX, int minY, int maxY) : base(minX, maxX, minY, maxY)
        {
            if (ValidateOptions(stringValue))
            {
                var value = ParseOptions(stringValue);

                var Series = new VerticalSeries(value, ChartAreas["Chart"]);
                Series.Color = SERIES_COLOR_HIERARCHY[0];
                Series.BorderWidth = 3;


                base.Series.Add(Series);
            }
        }

        protected bool ValidateOptions(string[] options)
        {
            if (options.Length != 1) return false;

            double aux;
            return double.TryParse(options[0], out aux);
        }

        protected double ParseOptions(string[] options)
        {
            return double.Parse(options[0]);
        }
    }
}