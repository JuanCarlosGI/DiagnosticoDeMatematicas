using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web.UI.DataVisualization.Charting;

namespace DiagnosticoDeMatematicas.Models.ViewModels
{
    /// <summary>
    /// View Model for view Responses/GlobalStatistics
    /// </summary>
    public class GlobalStatisticsViewModel
    {
        /// <summary>
        /// List of responses that will be analyzed. It is not necessary to filter them by date.
        /// </summary>
        public ICollection<Response> Responses { set; get; }
        /// <summary>
        /// Minimum for the Date value of responses in order for them to be considered. If it is null, there is no minumum.
        /// </summary>
        [Display(Name = "Desde la fecha")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { set; get; }
        /// <summary>
        /// Maximum for the Date value of responses in order for them to be considered. If it is null, there is no maximum.
        /// </summary>
        [Display(Name = "Hasta la fecha")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { set; get; }

        /// <summary>
        /// List of distinct exams that correspond to the list of responses.
        /// </summary>
        public IEnumerable<Exam> Exams
        {
            get
            {
                return Responses.GroupBy(r => r.ExamID).Select(g => g.First().Exam).ToList();
            }
        }

        /// <summary>
        /// The list of responses corresponding to an exam.
        /// </summary>
        /// <param name="ExamID">ID of the exam in question.</param>
        /// <returns>A list with the responses.</returns>
        public IEnumerable<Response> ResponsesForExam(int ExamID)
        {
            return from r in Responses
                   where r.ExamID == ExamID
                   where !StartDate.HasValue || r.Date >= StartDate.Value
                   where !EndDate.HasValue || r.Date <= EndDate.Value
                   select r;
        }

        /// <summary>
        /// The amount of responses that correspond to a certain exam.
        /// </summary>
        /// <param name="ExamID">ID of the exam in question.</param>
        /// <returns>The amount of responses.</returns>
        public int AmountOfResponses(int ExamID)
        {
            return ResponsesForExam(ExamID).Count();
        }

        /// <summary>
        /// String containing the image of a radar chart. This radar chart compares the average grade of all exams.
        /// </summary>
        public string RadarChart
        {
            get
            {
                var Chart = new Chart();
                Chart.Width = 600;
                Chart.Height = 600;
                Chart.ChartAreas.Add("Chart").BackColor = Color.White;
                Chart.Series.Add("Chart");

                foreach (var exam in Exams)
                {
                    var responsesForExam = ResponsesForExam(exam.ID);

                    var sum = 0.0;
                    foreach (var response in responsesForExam)
                    {
                        sum += response.Grade;
                    }
                    var average = sum / responsesForExam.Count();

                    Chart.Series["Chart"].Points.AddXY(exam.Name, average / 100.0 * 20.0);
                }

                Chart.Series["Chart"].ChartType = SeriesChartType.Radar;
                Chart.Series["Chart"].LabelForeColor = Color.Black;
                Chart.ChartAreas[0].AxisX.Interval = 1;
                Chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
                Chart.ChartAreas[0].AxisY.Maximum = 20;
                Chart.ChartAreas[0].AxisY.Interval = 2;
                Chart.BackColor = Color.White;

                MemoryStream imageStream = new MemoryStream();
                Chart.SaveImage(imageStream, ChartImageFormat.Png);
                byte[] arrbyte = imageStream.ToArray();
                return Convert.ToBase64String(arrbyte);
            }
        }

        /// <summary>
        /// String containing the image of a multicolumn chart. This chart compares the amount of responses for each exam in which they have a certain grade.
        /// </summary>
        public string MulticolumnChart
        {
            get
            {
                var statisticsList = new List<StatisticsViewModel>();
                foreach (var exam in Exams)
                {
                    var responsesForExam = ResponsesForExam(exam.ID);

                    statisticsList.Add(new StatisticsViewModel { Responses = responsesForExam, Exam = exam, StartDate = StartDate, EndDate = EndDate });
                }

                var Chart = new Chart();
                Chart.Width = 1000;
                Chart.Height = 400;
                Chart.ChartAreas.Add("Chart").BackColor = Color.White;

                double max = 0;
                foreach (var statistics in statisticsList)
                {
                    Chart.Series.Add(statistics.Exam.Name);

                    var counter = 0;
                    foreach (var result in statistics.GradeRanges)
                    {
                        Chart.Series[statistics.Exam.Name].Points.AddXY(counter.ToString(), result);
                        counter++;
                    }

                    Chart.Series[statistics.Exam.Name].ChartType = SeriesChartType.Column;

                    if (statistics.GradeRanges.Max() > max) max = statistics.GradeRanges.Max();
                }

                Chart.ChartAreas[0].AxisX.Title = "Reactivos correctos (n de cada 20)";
                Chart.ChartAreas[0].AxisX.Interval = 1;
                Chart.ChartAreas[0].AxisY.Title = "Porcentaje de alumnos";
                Chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
                Chart.ChartAreas[0].AxisY.Maximum = (Math.Ceiling(max / 10) + 1) * 10;
                if (Chart.ChartAreas[0].AxisY.Maximum > 100) Chart.ChartAreas[0].AxisY.Maximum = 100;
                Chart.ChartAreas[0].AxisY.Interval = 10;
                Chart.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.LightGray;
                Chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
                Chart.BackColor = Color.White;

                Chart.Legends.Add(new Legend("Default") { Docking = Docking.Bottom });

                MemoryStream imageStream2 = new MemoryStream();
                Chart.SaveImage(imageStream2, ChartImageFormat.Png);
                byte[] arrbyte2 = imageStream2.ToArray();
                return Convert.ToBase64String(arrbyte2);
            }
        }
    }
}