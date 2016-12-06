namespace DiagnosticoDeMatematicas.Models.ViewModels
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Web.UI.DataVisualization.Charting;
    using Helpers;

    /// <summary>
    /// View model for the view Responses/Statistics
    /// </summary>
    public class StatisticsViewModel
    {
        /// <summary>
        /// Gets or sets the exam analyzer from which the information will be taken.
        /// </summary>
        public ExamAnalyzer ExamAnalyzer { get; set; }

        /// <summary>
        /// Chart that displays the information on GradeRanges.
        /// </summary>
        /// <returns>String containing the image of a column chart.</returns>
        public string ColumnChart()
        {
            var chart = new Chart
            {
                Width = 1000,
                Height = 400
            };
            chart.ChartAreas.Add("Chart").BackColor = Color.White;
            chart.Series.Add(ExamAnalyzer.Exam.Name);

            var counter = 0;
            foreach (var result in ExamAnalyzer.GradeRanges)
            {
                chart.Series[ExamAnalyzer.Exam.Name].Points.AddXY(counter.ToString(), result);
                counter++;
            }

            chart.Series[ExamAnalyzer.Exam.Name].IsValueShownAsLabel = true;
            chart.Series[ExamAnalyzer.Exam.Name].LabelForeColor = Color.Black;
            chart.Series[ExamAnalyzer.Exam.Name].LabelFormat = "{0:0.00}%";

            chart.ChartAreas[0].AxisX.Title = "Reactivos correctos (n de cada 20)";
            chart.ChartAreas[0].AxisX.Interval = 1;
            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chart.ChartAreas[0].AxisY.Title = "Porcentaje de alumnos";
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart.ChartAreas[0].AxisY.Interval = 10;
            chart.ChartAreas[0].AxisY.Maximum = (Math.Ceiling(ExamAnalyzer.GradeRanges.Max() / 10) + 1) * 10;
            chart.BackColor = Color.White;

            MemoryStream imageStream = new MemoryStream();
            chart.SaveImage(imageStream, ChartImageFormat.Png);
            byte[] arrbyte = imageStream.ToArray();
            return Convert.ToBase64String(arrbyte);
        }
    }
}