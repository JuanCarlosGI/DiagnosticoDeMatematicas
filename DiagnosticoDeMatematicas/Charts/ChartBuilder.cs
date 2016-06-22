using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.DataVisualization.Charting;
using DiagnosticoDeMatematicas.Charts.ChartTypes;

namespace DiagnosticoDeMatematicas.Charts
{
    /// <summary>
    /// Abstract class in charge of creating different types charts in the form of HTML images.
    /// </summary>
    public static class ChartBuilder
    {
        private static readonly Tuple<string, CustomChartTypes>[] ValidTranslations = new Tuple<string, CustomChartTypes>[] {
            new Tuple<string, CustomChartTypes>("Polynomial", CustomChartTypes.Polynomial),
            new Tuple<string, CustomChartTypes>("PolynomialWithDerivate", CustomChartTypes.PolynomialWithDerivate),
            new Tuple<string, CustomChartTypes>("PolynomialWithDoubleDerivate", CustomChartTypes.PolynomialWithDoubleDerivate),
            new Tuple<string, CustomChartTypes>("MultiPolynomial", CustomChartTypes.MultiPolynomial)
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

            return CreateChart(Type.Value,MinX,MaxX,MinY,MaxY, Parameters.Skip(5).ToArray());
        }

        private static string CreateChart(CustomChartTypes type, int minX, int maxX, int minY, int maxY, string[] options)
        {
            CartesianPlane chart = null;
            switch(type)
            {
                case CustomChartTypes.Polynomial:
                    chart = new PolynomialChart(options, minX, maxX, minY, maxY);
                    break;
                case CustomChartTypes.PolynomialWithDerivate:
                    chart = new PolynomialWithDerivateChart(options, minX, maxX, minY, maxY);
                    break;
                case CustomChartTypes.PolynomialWithDoubleDerivate:
                    chart = new PolynomialWithDoubleDerivateChart(options, minX, maxX, minY, maxY);
                    break;
                case CustomChartTypes.MultiPolynomial:
                    chart = new MultiPolynomialChart(options, minX, maxX, minY, maxY);
                    break;
            }
            if (chart == null) return null;
            
            return chart.ToString();
        }

        public enum CustomChartTypes
        {
            Polynomial,
            PolynomialWithDerivate,
            PolynomialWithDoubleDerivate,
            MultiPolynomial
        }
    }
}