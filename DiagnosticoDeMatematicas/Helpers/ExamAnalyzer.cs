using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DiagnosticoDeMatematicas.Models;

namespace DiagnosticoDeMatematicas.Helpers
{
    /// <summary>
    /// Class in charge of analyzing an exam.
    /// </summary>
    public class ExamAnalyzer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExamAnalyzer"/> class.
        /// </summary>
        /// <param name="exam">Exam to be analyzed.</param>
        /// <param name="startDate">Start date of the analysis. If null, no lower limit is considered.</param>
        /// <param name="endDate">End date of the analysis. If null, no upper limit is considered.</param>
        public ExamAnalyzer(Exam exam, DateTime? startDate, DateTime? endDate)
        {
            Exam = exam;
            StartDate = startDate;
            EndDate = endDate;

            Responses = from r in Exam.Responses
                        where r.ExamId == Exam.Id
                        where !StartDate.HasValue || r.Date >= StartDate.Value
                        where !EndDate.HasValue || r.Date <= EndDate.Value
                        select r;

            var responses = Responses as Response[] ?? Responses.ToArray();
            AmountOfResponses = responses.Length;

            var sum = 0.0;
            foreach (var response in responses)
            {
                sum += response.Grade;
            }

            AverageGrade = Math.Round(sum / AmountOfResponses, 2);

            GradeRanges = CreateGradeRanges();

            QuestionResponses = CreateQuestionResponses();
        }

        /// <summary>
        /// Gets the exam being analyzed.
        /// </summary>
        public Exam Exam { get; }

        /// <summary>
        /// Gets the start date of the analysis.
        /// </summary>
        [Display(Name = "Desde la fecha")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; }

        /// <summary>
        /// Gets the end date of the analysis.
        /// </summary>
        [Display(Name = "Hasta la fecha")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; }

        /// <summary>
        /// Gets the responses being analyzed.
        /// </summary>
        public IEnumerable<Response> Responses { get; }

        /// <summary>
        /// Gets the amount of responses that were analyzed.
        /// </summary>
        [Display(Name = "Cantidad de examenes")]
        public int AmountOfResponses { get; }

        /// <summary>
        /// Gets the average grade for the responses being analyzed.
        /// </summary>
        [Display(Name = "Calificación promedio")]
        public double AverageGrade { get; }

        /// <summary>
        /// Gets an array containing the percentage of responses that fall within a certain grade range, starting in 0 
        /// and ending in 100, in intervals of 5.
        /// </summary>
        public double[] GradeRanges { get; }

        /// <summary>
        /// Gets the dictionary containing the amount of times each option was chosen for a given question. The key is
        /// the ID of the question, and the value is a tuple containing the amount of times optionA, optionB, optionC,
        /// and OptionD were chosen, respectively.
        /// </summary>
        public Dictionary<int, Tuple<int, int, int, int>> QuestionResponses { get; }

        /// <summary>
        /// Gets the percentage of the responses analyzed that have a grade within the limits specified.
        /// </summary>
        /// <param name="lowerLimit">Inclusive lower limit of the range of grades.</param>
        /// <param name="upperLimit">Non-inclusive upper limit of the range of grades.</param>
        /// <returns>The percentage of responses meeting the criteria.</returns>
        public double PercentageBetweenGrades(double lowerLimit, double upperLimit)
        {
            if (AmountOfResponses == 0)
            {
                return 0;
            }

            return Responses.Count(r => r.Grade >= lowerLimit && r.Grade < upperLimit) * 100.0 / AmountOfResponses;
        }

        /// <summary>
        /// Creates the QuestionResponses dictionary.
        /// </summary>
        /// <returns>The created dictionary</returns>
        private Dictionary<int, Tuple<int, int, int, int>> CreateQuestionResponses()
        {
            var result = new Dictionary<int, Tuple<int, int, int, int>>();

            foreach (var question in Exam.Questions)
            {
                var optionA = 0;
                var optionB = 0;
                var optionC = 0;
                var optionD = 0;

                foreach (var response in Responses)
                {
                    foreach (var _ in response.Answers)
                    {
                        //  Logic goes here.
                    }
                }

                result.Add(question.Id, new Tuple<int, int, int, int>(optionA, optionB, optionC, optionD));
            }

            return result;
        }

        /// <summary>
        /// Creates the GradeRanges array.
        /// </summary>
        /// <returns>The created array.</returns>
        private double[] CreateGradeRanges()
        {
            List<double> gradeRanges = new List<double>();
            for (int grade = 0; grade < 100; grade += 5)
            {
                gradeRanges.Add(PercentageBetweenGrades(grade, grade + 5));
            }

            gradeRanges.Add(PercentageBetweenGrades(100, 100));
            return gradeRanges.ToArray();
        }
    }
}