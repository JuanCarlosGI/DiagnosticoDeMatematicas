﻿namespace DiagnosticoDeMatematicas.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Web.UI.DataVisualization.Charting;

    /// <summary>
    /// View model representing a user with all the exams he has answered.
    /// </summary>
    public class UserDetailsViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserDetailsViewModel"/> class.
        /// </summary>
        /// <param name="user">The user that is being represented.</param>
        /// <param name="exams">The list of exams that are being analyzed.</param>
        public UserDetailsViewModel(User user, IEnumerable<Exam> exams)
        {
            User = user;

            Responses = new List<Response>();
            foreach (var exam in exams)
            {
                var responses = user.Responses.Where(r => r.ExamId == exam.Id);
                Response response = null;

                var enumerable = responses as Response[] ?? responses.ToArray();
                if (enumerable.Length != 0)
                {
                    response = enumerable.OrderByDescending(r => r.Date).First();
                }

                if (response == null)
                {
                    response = new Response
                    {
                        Exam = exam
                    };
                }

                Responses.Add(response);
            }
        }

        /// <summary>
        /// Gets the user that is being represented.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Gets a string representing a radar chart of the user's latest attempts.
        /// </summary>
        public string RadarChart
        {
            get
            {
                var chart = new Chart
                {
                    Width = 600,
                    Height = 600
                };
                chart.ChartAreas.Add("Chart").BackColor = Color.White;
                chart.Series.Add("Chart");

                foreach (var response in Responses)
                {
                    chart.Series["Chart"].Points.AddXY(response.Exam.Name, response.Grade / 100.0 * 20.0);
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
        /// Gets the list of responses that are going to be displayed at the radar chart.
        /// </summary>
        private List<Response> Responses { get; }

        public List<int> ExamGrades { get; set; }
    }
}