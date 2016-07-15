namespace DiagnosticoDeMatematicas.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Web.UI.DataVisualization.Charting;
    using Helpers;

    /// <summary>
    /// View Model for view Responses/GlobalStatistics
    /// </summary>
    public class GlobalStatisticsViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalStatisticsViewModel"/> class.
        /// </summary>
        /// <param name="exams">List of exams to analyze.</param>
        /// <param name="startDate">Start date of the analysis.</param>
        /// <param name="endDate">End date of the analysis.</param>
        public GlobalStatisticsViewModel(List<Exam> exams, DateTime? startDate, DateTime? endDate)
        {
            ExamAnalyzers = new List<ExamAnalyzer>();
            foreach (Exam exam in exams)
            {
                ExamAnalyzers.Add(new ExamAnalyzer(exam, startDate, endDate));
            }

            StartDate = startDate;
            EndDate = endDate;
        }

        /// <summary>
        /// Gets the list of all exam analyzers from which the information is read.
        /// </summary>
        public List<ExamAnalyzer> ExamAnalyzers { get; }

        /// <summary>
        /// Gets or sets the minimum for the Date value of responses in order for them to be considered. If it is null, there is no minimum.
        /// </summary>
        [Display(Name = "Desde la fecha")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or sets the maximum for the Date value of responses in order for them to be considered. If it is null, there is no maximum.
        /// </summary>
        [Display(Name = "Hasta la fecha")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Gets the string containing the image of a radar chart. This radar chart compares the average grade of all exams.
        /// </summary>
        public string RadarChart
        {
            get
            {
                var chart = new Chart();
                chart.Width = 600;
                chart.Height = 600;
                chart.ChartAreas.Add("Chart").BackColor = Color.White;
                chart.Series.Add("Chart");

                foreach (var examAnalyzer in ExamAnalyzers)
                {
                    chart.Series["Chart"].Points.AddXY(examAnalyzer.Exam.Name, examAnalyzer.AverageGrade / 100.0 * 20.0);
                }

                chart.Series["Chart"].ChartType = SeriesChartType.Radar;
                chart.Series["Chart"].LabelForeColor = Color.Black;
                chart.ChartAreas[0].AxisX.Interval = 1;
                chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
                chart.ChartAreas[0].AxisY.Maximum = 20;
                chart.ChartAreas[0].AxisY.Interval = 2;
                chart.BackColor = Color.White;

                MemoryStream imageStream = new MemoryStream();
                chart.SaveImage(imageStream, ChartImageFormat.Png);
                byte[] arrbyte = imageStream.ToArray();
                return Convert.ToBase64String(arrbyte);
            }
        }

        /// <summary>
        /// Gets the string containing the image of a multicolumn chart. This chart compares the amount of responses for each exam in which they have a certain grade.
        /// </summary>
        public string MulticolumnChart
        {
            get
            {
                var chart = new Chart();
                chart.Width = 1000;
                chart.Height = 400;
                chart.ChartAreas.Add("Chart").BackColor = Color.White;

                double max = 0;
                foreach (var statistics in ExamAnalyzers)
                {
                    chart.Series.Add(statistics.Exam.Name);

                    var counter = 0;
                    foreach (var percentage in statistics.GradeRanges)
                    {
                        chart.Series[statistics.Exam.Name].Points.AddXY(counter.ToString(), percentage);
                        counter++;
                    }

                    chart.Series[statistics.Exam.Name].ChartType = SeriesChartType.Column;

                    if (statistics.GradeRanges.Max() > max)
                    {
                        max = statistics.GradeRanges.Max();
                    }
                }

                chart.ChartAreas[0].AxisX.Title = "Reactivos correctos (n de cada 20)";
                chart.ChartAreas[0].AxisX.Interval = 1;
                chart.ChartAreas[0].AxisY.Title = "Porcentaje de alumnos";
                chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
                chart.ChartAreas[0].AxisY.Maximum = (Math.Ceiling(max / 10) + 1) * 10;
                chart.ChartAreas[0].AxisY.Interval = 10;
                chart.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.LightGray;
                chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
                chart.BackColor = Color.White;

                if (chart.ChartAreas[0].AxisY.Maximum > 100)
                {
                    chart.ChartAreas[0].AxisY.Maximum = 100;
                }

                chart.Legends.Add(new Legend("Default") { Docking = Docking.Bottom });

                MemoryStream imageStream2 = new MemoryStream();
                chart.SaveImage(imageStream2, ChartImageFormat.Png);
                byte[] arrbyte2 = imageStream2.ToArray();
                return Convert.ToBase64String(arrbyte2);
            }
        }
    }
}