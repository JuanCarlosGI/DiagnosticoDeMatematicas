using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.DataVisualization.Charting;

namespace DiagnosticoDeMatematicas.Charts
{
    /// <summary>
    /// Abstract class in charge of creating different types charts in the form of HTML images.
    /// </summary>
    public static class ChartCreator
    {
        private static Tuple<string, CustomChartTypes>[] ValidTranslations = new Tuple<string, CustomChartTypes>[] {
            new Tuple<string, CustomChartTypes>("Polynomial", CustomChartTypes.Polynomial),
            new Tuple<string, CustomChartTypes>("PolynomialWithDerivate", CustomChartTypes.PolynomialWithDerivate),
            new Tuple<string, CustomChartTypes>("PolynomialWithDoubleDerivate", CustomChartTypes.PolynomialWithDoubleDerivate),
            };

        public static string QuestionWithChart(string Question)
        {
            var chartTexts = Question.Split(new string[] { "&&" }, StringSplitOptions.None);
            for (int segment = 1; segment < chartTexts.Count(); segment += 2)
            {
                chartTexts[segment] = HtmlImageChart(chartTexts[segment]);
            }
            return string.Join("",chartTexts);
        }

        public static string HtmlImageChart(String chartData)
        {
            return "<img src=\"data:image/png;base64," + CreateChart(chartData) + "\" />";
        }

        private static string CreateChart(String chartData)
        {
            string[] Parameters = chartData.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            if (Parameters.Count() < 6) return null;

            CustomChartTypes? Type = null;
            foreach(var translation in ValidTranslations)
            {
                if (translation.Item1 == Parameters[0])
                {
                    Type = translation.Item2;
                    break;
                }
            }
            if (!Type.HasValue)
            {
                return null;
            }

            int MinX, MaxX, MinY, MaxY;
            try
            {
                MinX = int.Parse(Parameters[1]);
                MaxX = int.Parse(Parameters[2]);
                MinY = int.Parse(Parameters[3]);
                MaxY = int.Parse(Parameters[4]);
            }
            catch (Exception e)
            {
                return null;
            }

            var Coefficients = new List<double>();
            foreach( var coefficient in Parameters.Skip(5))
            {
                try
                {
                    Coefficients.Add(double.Parse(coefficient));
                }
                catch (Exception e)
                {
                    return null;
                }
            }

            return CreateChart(Type.Value,MinX,MaxX,MinY,MaxY,Coefficients.ToArray());
        }

        private static string CreateChart(CustomChartTypes type, int minX, int maxX, int minY, int maxY, double[] coefficients)
        {
            var Chart = new Chart();
            Chart.Width = 400;
            Chart.Height = 400;
            Chart.ChartAreas.Add("Chart").BackColor = Color.White;
            Chart.ChartAreas[0].AxisX.LineColor = Color.Black;
            Chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            Chart.ChartAreas[0].AxisX.MajorGrid.Interval = 1;
            Chart.ChartAreas[0].AxisX.Minimum = minX;
            Chart.ChartAreas[0].AxisX.Maximum = maxX;
            Chart.ChartAreas[0].AxisX.Interval = 2;
            Chart.ChartAreas[0].AxisX.Crossing = 0;
            Chart.ChartAreas[0].AxisY.LineColor = Color.Black;
            Chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            Chart.ChartAreas[0].AxisY.MajorGrid.Interval = 1;
            Chart.ChartAreas[0].AxisY.Minimum = minY;
            Chart.ChartAreas[0].AxisY.Maximum = maxY;
            Chart.ChartAreas[0].AxisY.Interval = 2;
            Chart.ChartAreas[0].AxisY.Crossing = 0;

            if (type == CustomChartTypes.Polynomial)
            {
                var series = new FunctionSeries(new Polynomial(coefficients), Chart.ChartAreas["Chart"]);
                series.BorderWidth = 3;
                series.Color = Color.Blue;

                Chart.Series.Add(series);
            }

            if (type == CustomChartTypes.PolynomialWithDerivate)
            {
                var series = new FunctionSeries(new Polynomial(coefficients), Chart.ChartAreas["Chart"]);
                series.BorderWidth = 3;
                series.Color = Color.Blue;

                var derivate = series.Derivate();
                derivate.BorderWidth = 2;
                derivate.Color = Color.Red;

                Chart.Series.Add(series);
                Chart.Series.Add(derivate);
            }

            if (type == CustomChartTypes.PolynomialWithDoubleDerivate)
            {
                var series = new FunctionSeries(new Polynomial(coefficients), Chart.ChartAreas["Chart"]);
                series.BorderWidth = 3;
                series.Color = Color.Blue;

                var derivate = series.Derivate();
                derivate.BorderWidth = 2;
                derivate.Color = Color.Red;

                var doubleDerivate = derivate.Derivate();
                doubleDerivate.BorderWidth = 2;
                doubleDerivate.Color = Color.Green;

                Chart.Series.Add(series);
                Chart.Series.Add(derivate);
                Chart.Series.Add(doubleDerivate);
            }
            
            return ConvertChartToString(Chart);
        }

        private static string ConvertChartToString(Chart Chart)
        {
            MemoryStream imageStream = new MemoryStream();
            Chart.SaveImage(imageStream, ChartImageFormat.Png);
            byte[] arrbyte2 = imageStream.ToArray();
            return Convert.ToBase64String(arrbyte2);
        }
    }

    public enum CustomChartTypes
    {
        Polynomial,
        PolynomialWithDerivate,
        PolynomialWithDoubleDerivate
    }
}