namespace DiagnosticoDeMatematicas.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Web.UI.DataVisualization.Charting;

    /// <summary>
    /// View Model for view Responses/GlobalStatistics
    /// </summary>
    public class GlobalStatisticsViewModel
    {
        /// <summary>
        /// Gets or sets the list of responses that will be analyzed. It is not necessary to filter them by date.
        /// </summary>
        public ICollection<Response> Responses { get; set; }

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
        /// Gets the list of distinct exams that correspond to the list of responses.
        /// </summary>
        public IEnumerable<Exam> Exams
        {
            get
            {
                return Responses.GroupBy(r => r.ExamID).Select(g => g.First().Exam).ToList();
            }
        }

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

                foreach (var exam in Exams)
                {
                    var responsesForExam = ResponsesForExam(exam.ID);

                    var sum = 0.0;
                    foreach (var response in responsesForExam)
                    {
                        sum += response.Grade;
                    }

                    var average = sum / responsesForExam.Count();

                    chart.Series["Chart"].Points.AddXY(exam.Name, average / 100.0 * 20.0);
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
                var statisticsList = new List<StatisticsViewModel>();
                foreach (var exam in Exams)
                {
                    var responsesForExam = ResponsesForExam(exam.ID);

                    statisticsList.Add(new StatisticsViewModel { Responses = responsesForExam, Exam = exam, StartDate = StartDate, EndDate = EndDate });
                }

                var chart = new Chart();
                chart.Width = 1000;
                chart.Height = 400;
                chart.ChartAreas.Add("Chart").BackColor = Color.White;

                double max = 0;
                foreach (var statistics in statisticsList)
                {
                    chart.Series.Add(statistics.Exam.Name);

                    var counter = 0;
                    var gradeRanges = statistics.GradeRanges();
                    foreach (var result in gradeRanges)
                    {
                        chart.Series[statistics.Exam.Name].Points.AddXY(counter.ToString(), result);
                        counter++;
                    }

                    chart.Series[statistics.Exam.Name].ChartType = SeriesChartType.Column;

                    if (gradeRanges.Max() > max)
                    {
                        max = gradeRanges.Max();
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

        /// <summary>
        /// The list of responses corresponding to an exam.
        /// </summary>
        /// <param name="examID">ID of the exam in question.</param>
        /// <returns>A list with the responses.</returns>
        public IEnumerable<Response> ResponsesForExam(int examID)
        {
            return from r in Responses
                   where r.ExamID == examID
                   where !StartDate.HasValue || r.Date >= StartDate.Value
                   where !EndDate.HasValue || r.Date <= EndDate.Value
                   select r;
        }

        /// <summary>
        /// The amount of responses that correspond to a certain exam.
        /// </summary>
        /// <param name="examID">ID of the exam in question.</param>
        /// <returns>The amount of responses.</returns>
        public int AmountOfResponses(int examID)
        {
            return ResponsesForExam(examID).Count();
        }
    }
}