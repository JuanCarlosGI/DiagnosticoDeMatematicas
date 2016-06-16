using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiagnosticoDeMatematicas.Models.ViewModels
{
    public class StatisticsGenerator
    {
        public IEnumerable<Response> responses { get; set; }
        public Exam Exam { set; get; }
        public DateTime? StartDate { set; get; }
        public DateTime? EndDate { set; get; }

        public Dictionary<int,Tuple<int,int,int,int>> QuestionResponses
        {
            get
            {
                var result = new Dictionary<int, Tuple<int, int, int, int>>();

                foreach(var question in Exam.Questions)
                {
                    var optionA = 0;
                    var optionB = 0;
                    var optionC = 0;
                    var optionD = 0;

                    foreach (var response in responses)
                    {
                        foreach (var answer in response.Answers)
                        {
                            if (answer.QuestionID == question.ID)
                            {
                                if (answer.Choice == Choice.A) optionA++;
                                else if (answer.Choice == Choice.B) optionB++;
                                else if (answer.Choice == Choice.C) optionC++;
                                else if (answer.Choice == Choice.D) optionD++;
                            }
                        }
                    }

                    result.Add(question.ID, new Tuple<int, int, int, int>(optionA, optionB, optionC, optionD));
                }

                return result;
            }
        }

        [Display(Name = "Calificación promedio")]
        public double Average
        {
            get
            {
                var sum = 0.0;
                foreach (var response in responses)
                {
                    sum += response.Grade;
                }
                return Math.Round(sum / responses.Count(), 2);
            }
        }

        public double[] GradeRanges
        {
            get
            {
                if (responses.Count() == 0) return new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                var count = (double)responses.Count();
                return new double[]
                {
                    responses.Where(r => r.Grade >= 0 && r.Grade < 5).Count() / count * 100,
                    responses.Where(r => r.Grade >= 5 && r.Grade < 10).Count() / count * 100,
                    responses.Where(r => r.Grade >= 10 && r.Grade < 15).Count() / count * 100,
                    responses.Where(r => r.Grade >= 15 && r.Grade < 20).Count() / count * 100,
                    responses.Where(r => r.Grade >= 20 && r.Grade < 25).Count() / count * 100,
                    responses.Where(r => r.Grade >= 25 && r.Grade < 30).Count() / count * 100,
                    responses.Where(r => r.Grade >= 30 && r.Grade < 35).Count() / count * 100,
                    responses.Where(r => r.Grade >= 35 && r.Grade < 40).Count() / count * 100,
                    responses.Where(r => r.Grade >= 40 && r.Grade < 45).Count() / count * 100,
                    responses.Where(r => r.Grade >= 45 && r.Grade < 50).Count() / count * 100,
                    responses.Where(r => r.Grade >= 50 && r.Grade < 55).Count() / count * 100,
                    responses.Where(r => r.Grade >= 55 && r.Grade < 60).Count() / count * 100,
                    responses.Where(r => r.Grade >= 60 && r.Grade < 65).Count() / count * 100,
                    responses.Where(r => r.Grade >= 65 && r.Grade < 70).Count() / count * 100,
                    responses.Where(r => r.Grade >= 70 && r.Grade < 75).Count() / count * 100,
                    responses.Where(r => r.Grade >= 75 && r.Grade < 80).Count() / count * 100,
                    responses.Where(r => r.Grade >= 80 && r.Grade < 85).Count() / count * 100,
                    responses.Where(r => r.Grade >= 85 && r.Grade < 90).Count() / count * 100,
                    responses.Where(r => r.Grade >= 90 && r.Grade < 95).Count() / count * 100,
                    responses.Where(r => r.Grade >= 95 && r.Grade < 100).Count() / count * 100,
                    responses.Where(r => r.Grade == 100).Count() / count * 100
                };
            }
        }
    }
}