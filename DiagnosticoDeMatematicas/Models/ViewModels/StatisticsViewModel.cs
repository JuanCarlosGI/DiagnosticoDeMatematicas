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
    /// View model for the view Responses/Statistics
    /// </summary>
    public class StatisticsViewModel
    {
        /// <summary>
        /// Gets or sets the list of responses that will be analyzed. It is not necessary to filter them by date or 
        /// exam.
        /// </summary>
        public IEnumerable<Response> Responses { get; set; }

        /// <summary>
        /// Gets or sets the exam that will be analyzed.
        /// </summary>
        public Exam Exam { get; set; }

        /// <summary>
        /// Gets or sets the minimum for the Date value of responses in order for them to be considered. If it is null,
        /// there is no minimum.
        /// </summary>
        [Display(Name = "Desde la fecha")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or sets the maximum for the Date value of responses in order for them to be considered. If it is null,
        /// there is no maximum.
        /// </summary>
        [Display(Name = "Hasta la fecha")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Gets the list of responses filtered by date and exam.
        /// </summary>
        public IEnumerable<Response> ResponsesFiltered
        {
            get
            {
                return from r in Responses
                       where r.ExamID == Exam.ID
                       where !StartDate.HasValue || r.Date >= StartDate.Value
                       where !EndDate.HasValue || r.Date <= EndDate.Value
                       select r;
            }
        }

        /// <summary>
        /// Gets the amount of responses when they are filtered.
        /// </summary>
        [Display(Name = "Cantidad de examenes")]
        public int AmountOfResponses
        {
            get
            {
                return ResponsesFiltered.Count();
            }
        }

        /// <summary>
        /// Gets the dictionary containing the amount of times each option was chosen for a given question. The key is
        /// the ID of the question, and the value is a tuple containing the amount of times optionA, optionB, optionC,
        /// and OptionD were chosen, respectively.
        /// </summary>
        public Dictionary<int, Tuple<int, int, int, int>> QuestionResponses
        {
            get
            {
                var result = new Dictionary<int, Tuple<int, int, int, int>>();

                foreach (var question in Exam.Questions)
                {
                    var optionA = 0;
                    var optionB = 0;
                    var optionC = 0;
                    var optionD = 0;

                    foreach (var response in ResponsesFiltered)
                    {
                        foreach (var answer in response.Answers)
                        {
                            if (answer.QuestionID == question.ID)
                            {
                                if (answer.Choice == Choice.A)
                                {
                                    optionA++;
                                }
                                else if (answer.Choice == Choice.B)
                                {
                                    optionB++;
                                }
                                else if (answer.Choice == Choice.C)
                                {
                                    optionC++;
                                }
                                else if (answer.Choice == Choice.D)
                                {
                                    optionD++;
                                }
                            }
                        }
                    }

                    result.Add(question.ID, new Tuple<int, int, int, int>(optionA, optionB, optionC, optionD));
                }

                return result;
            }
        }

        /// <summary>
        /// Gets the average grade for the exam in question.
        /// </summary>
        [Display(Name = "Calificación promedio")]
        public double Average
        {
            get
            {
                var sum = 0.0;
                foreach (var response in ResponsesFiltered)
                {
                    sum += response.Grade;
                }

                return Math.Round(sum / ResponsesFiltered.Count(), 2);
            }
        }

        /// <summary>
        /// Array of doubles, containing 21 values, representing the percentage of responses that fall in that range, 
        /// stating in 0 and ending in 100, with intervals of 5.
        /// </summary>
        /// <returns>The array containing the values.</returns>
        public double[] GradeRanges()
        {
            if (ResponsesFiltered.Count() == 0)
            {
                return new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            }

            var responsesFilteredOnce = ResponsesFiltered;
            var count = (double)responsesFilteredOnce.Count();
            return new double[]
            {
                responsesFilteredOnce.Where(r => r.Grade >= 0 && r.Grade < 5).Count() / count * 100,
                responsesFilteredOnce.Where(r => r.Grade >= 5 && r.Grade < 10).Count() / count * 100,
                responsesFilteredOnce.Where(r => r.Grade >= 10 && r.Grade < 15).Count() / count * 100,
                responsesFilteredOnce.Where(r => r.Grade >= 15 && r.Grade < 20).Count() / count * 100,
                responsesFilteredOnce.Where(r => r.Grade >= 20 && r.Grade < 25).Count() / count * 100,
                responsesFilteredOnce.Where(r => r.Grade >= 25 && r.Grade < 30).Count() / count * 100,
                responsesFilteredOnce.Where(r => r.Grade >= 30 && r.Grade < 35).Count() / count * 100,
                responsesFilteredOnce.Where(r => r.Grade >= 35 && r.Grade < 40).Count() / count * 100,
                responsesFilteredOnce.Where(r => r.Grade >= 40 && r.Grade < 45).Count() / count * 100,
                responsesFilteredOnce.Where(r => r.Grade >= 45 && r.Grade < 50).Count() / count * 100,
                responsesFilteredOnce.Where(r => r.Grade >= 50 && r.Grade < 55).Count() / count * 100,
                responsesFilteredOnce.Where(r => r.Grade >= 55 && r.Grade < 60).Count() / count * 100,
                responsesFilteredOnce.Where(r => r.Grade >= 60 && r.Grade < 65).Count() / count * 100,
                responsesFilteredOnce.Where(r => r.Grade >= 65 && r.Grade < 70).Count() / count * 100,
                responsesFilteredOnce.Where(r => r.Grade >= 70 && r.Grade < 75).Count() / count * 100,
                responsesFilteredOnce.Where(r => r.Grade >= 75 && r.Grade < 80).Count() / count * 100,
                responsesFilteredOnce.Where(r => r.Grade >= 80 && r.Grade < 85).Count() / count * 100,
                responsesFilteredOnce.Where(r => r.Grade >= 85 && r.Grade < 90).Count() / count * 100,
                responsesFilteredOnce.Where(r => r.Grade >= 90 && r.Grade < 95).Count() / count * 100,
                responsesFilteredOnce.Where(r => r.Grade >= 95 && r.Grade < 100).Count() / count * 100,
                responsesFilteredOnce.Where(r => r.Grade == 100).Count() / count * 100
            };
        }

        /// <summary>
        /// Chart that displays the information on GradeRanges.
        /// </summary>
        /// <returns>String containing the image of a column chart.</returns>
        public string ColumnChart()
        {
            var chart = new Chart();
            chart.Width = 1000;
            chart.Height = 400;
            chart.ChartAreas.Add("Chart").BackColor = Color.White;
            chart.Series.Add(Exam.Name);

            var counter = 0;
            var gradeRanges = GradeRanges();
            foreach (var result in gradeRanges)
            {
                chart.Series[Exam.Name].Points.AddXY(counter.ToString(), result);
                counter++;
            }

            chart.Series[Exam.Name].IsValueShownAsLabel = true;
            chart.Series[Exam.Name].LabelForeColor = Color.Black;
            chart.Series[Exam.Name].LabelFormat = "{0:0.00}%";

            chart.ChartAreas[0].AxisX.Title = "Reactivos correctos (n de cada 20)";
            chart.ChartAreas[0].AxisX.Interval = 1;
            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chart.ChartAreas[0].AxisY.Title = "Porcentaje de alumnos";
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart.ChartAreas[0].AxisY.Interval = 10;
            chart.ChartAreas[0].AxisY.Maximum = (Math.Ceiling(gradeRanges.Max() / 10) + 1) * 10;
            chart.BackColor = Color.White;

            MemoryStream imageStream = new MemoryStream();
            chart.SaveImage(imageStream, ChartImageFormat.Png);
            byte[] arrbyte = imageStream.ToArray();
            return Convert.ToBase64String(arrbyte);
        }
    }
}