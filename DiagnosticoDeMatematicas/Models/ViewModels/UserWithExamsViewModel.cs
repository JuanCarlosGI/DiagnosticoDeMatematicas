using DiagnosticoDeMatematicas.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web.UI.DataVisualization.Charting;

namespace DiagnosticoDeMatematicas.Models.ViewModels
{
    public class UserWithExamsViewModel
    {
        public UserWithExamsViewModel(User user, IEnumerable<Exam> exams)
        {
            User = user;

            Responses = new List<Response>();
            foreach( var exam in exams)
            {
                var responses = user.Responses.Where(r => r.ExamId == exam.ID);
                Response response = null;

                if (responses.Count() != 0)
                {
                    response = responses.OrderByDescending(r => r.Date).First();
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

        public User User { get; }

        private List<Response> Responses { set; get; }

        public string RadarChart
        {
            get
            {
                var chart = new Chart();
                chart.Width = 600;
                chart.Height = 600;
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
    }
}