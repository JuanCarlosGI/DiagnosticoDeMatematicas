using Microsoft.Ajax.Utilities;

namespace DiagnosticoDeMatematicas.Charts
{
    using System;
    using System.Linq;
    using ChartTypes;

    /// <summary>
    /// Abstract class in charge of creating different types charts in the form of HTML images.
    /// </summary>
    public static class ChartBuilder
    {
        /// <summary>
        /// Pairs of valid translations from strings to CustomChartTypes
        /// </summary>
        private static readonly Tuple<string, CustomChartTypes>[] ValidTranslations = 
        {
            new Tuple<string, CustomChartTypes>("Polynomial", CustomChartTypes.Polynomial),
            new Tuple<string, CustomChartTypes>("PolynomialWithDerivate", CustomChartTypes.PolynomialWithDerivate),
            new Tuple<string, CustomChartTypes>("PolynomialWithDoubleDerivate", CustomChartTypes.PolynomialWithDoubleDerivate),
            new Tuple<string, CustomChartTypes>("MultiPolynomial", CustomChartTypes.MultiPolynomial),
            new Tuple<string, CustomChartTypes>("VerticalLine", CustomChartTypes.VerticalLine),
            new Tuple<string, CustomChartTypes>("PolynomialNoGrid", CustomChartTypes.PolynomialNoGrid)
        };

        /// <summary>
        /// All possible custom chart types.
        /// </summary>
        public enum CustomChartTypes
        {
            /// <summary>
            /// Graph with a single polynomial.
            /// </summary>
            Polynomial,

            /// <summary>
            /// Graph with a single polynomial and its derivate.
            /// </summary>
            PolynomialWithDerivate,

            /// <summary>
            /// Graph with a single polynomial, its derivate, and its double derivate.
            /// </summary>
            PolynomialWithDoubleDerivate,

            /// <summary>
            /// Graph with a multiple polynomials.
            /// </summary>
            MultiPolynomial,

            /// <summary>
            /// Graph with a single vertical line.
            /// </summary>
            VerticalLine,

            /// <summary>
            /// Same as Polynomial, except with no grid lines or numbers.
            /// </summary>
            PolynomialNoGrid
        }

        /// <summary>
        /// Makes a new copy of a string, but changing all the strings that could be translated to a chart.
        /// </summary>
        /// <param name="question">String to be converted.</param>
        /// <returns>String with all instances matching a possible chart modified.</returns>
        public static string QuestionWithChart(string question)
        {
            var chartTexts = question.Split(new[] { "&&" }, StringSplitOptions.None);
            for (int segment = 1; segment < chartTexts.Length; segment += 2)
            {
                chartTexts[segment] = HtmlImageChart(chartTexts[segment]);
            }

            return string.Join(string.Empty, chartTexts);
        }

        /// <summary>
        /// Takes a string containing the definition of a chart and returns an HTML image tag with the image of the chart.
        /// </summary>
        /// <param name="chartData">The string containing the definition of a chart.</param>
        /// <returns>string with the HTML image tag and the image.</returns>
        public static string HtmlImageChart(string chartData)
        {
            return "<img class=\"chart-img\" src=\"data:image/png;base64," + CreateChart(chartData) + "\" />";
        }

        /// <summary>
        /// Creates a chart and transforms it to a string.
        /// </summary>
        /// <param name="chartData">String containing the definition of a chart.</param>
        /// <returns>The string representation of the image of a chart.</returns>
        public static string CreateChart(string chartData)
        {
            string[] parameters = chartData.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            if (parameters.Length < 6)
            {
                return null;
            }

            CustomChartTypes? type = null;
            foreach (var translation in ValidTranslations)
            {
                if (translation.Item1 == parameters[0])
                {
                    type = translation.Item2;
                    break;
                }
            }

            if (!type.HasValue)
            {
                return null;
            }

            int minX, maxX, minY, maxY;
            try
            {
                minX = int.Parse(parameters[1]);
                maxX = int.Parse(parameters[2]);
                minY = int.Parse(parameters[3]);
                maxY = int.Parse(parameters[4]);
            }
            catch (Exception)
            {
                return null;
            }

            return CreateChart(type.Value, minX, maxX, minY, maxY, parameters.Skip(5).ToArray());
        }

        /// <summary>
        /// Creates a chart and transforms it to a string.
        /// </summary>
        /// <param name="type">The type of chart that will be created.</param>
        /// <param name="minX">The minimum value of the x-axis.</param>
        /// <param name="maxX">The maximum value of the x-axis.</param>
        /// <param name="minY">The minimum value of the y-axis.</param>
        /// <param name="maxY">The maximum value of the y-axis.</param>
        /// <param name="options">An array containing all the necessary options for the chart to be created successfully.</param>
        /// <returns>The string representation of the image of a chart.</returns>
        public static string CreateChart(CustomChartTypes type, int minX, int maxX, int minY, int maxY, string[] options)
        {
            CartesianPlane chart = null;
            switch (type)
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
                case CustomChartTypes.VerticalLine:
                    chart = new VerticalLineChart(options, minX, maxX, minY, maxY);
                    break;
                case CustomChartTypes.PolynomialNoGrid:
                    chart = new PolynomialNoGridChart(options, minX, maxX, minY, maxY);
                    break;
            }

            return chart?.ToString();
        }
    }
}