using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiagnosticoDeMatematicas.Models
{
    /// <summary>
    /// Model representing a question.
    /// </summary>
    public class Question
    {
        [Display(Name = "Pregunta")]
        public int ID { get; set; }
        /// <summary>
        /// Exam to which this question belongs.
        /// </summary>
        [Required]
        [Display(Name = "Examen")]
        public int ExamID { get; set; }
        /// <summary>
        /// Description of the question. This field can be interpreted as a LaTeX mathematical formula, and can contain
        /// both variables (Identified by a '%', e.g. "%x") and expressions that should be evaluated (Identified by
        /// surrounding '|', e.g. "|2+3|"). 
        /// </summary>
        [Required]
        [Display(Name = "Pregunta")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        /// <summary>
        /// Description of Option A. This field can be interpreted as a LaTeX mathematical formula, and can contain
        /// both variables (Identified by a '%', e.g. "%x") and expressions that should be evaluated (Identified by
        /// surrounding '|', e.g. "|2+3|"). 
        /// </summary>
        [Required]
        [Display(Name = "Inciso A")]
        [DataType(DataType.MultilineText)]
        public string OptionA { get; set; }
        /// <summary>
        /// Desribes if Option A is a correct option in the question.
        /// </summary>
        [Required]
        [Display(Name = "A es correcta")]
        public bool OptionACorrect { get; set; }
        /// <summary>
        /// Feedback for choosing Option A.
        /// </summary>
        [Required]
        [Display(Name = "Retroalimentacion A")]
        [DataType(DataType.MultilineText)]
        public string OptionAFeedback { get; set; }
        /// <summary>
        /// Description of Option B. This field can be interpreted as a LaTeX mathematical formula, and can contain
        /// both variables (Identified by a '%', e.g. "%x") and expressions that should be evaluated (Identified by
        /// surrounding '|', e.g. "|2+3|"). 
        /// </summary>
        [Required]
        [Display(Name = "Inciso B")]
        [DataType(DataType.MultilineText)]
        public string OptionB { get; set; }
        /// <summary>
        /// Desribes if Option B is a correct option in the question.
        /// </summary>
        [Required]
        [Display(Name = "B es correcta")]
        public bool OptionBCorrect { get; set; }
        /// <summary>
        /// Feedback for choosing Option B.
        /// </summary>
        [Required]
        [Display(Name = "Retroalimentacion B")]
        [DataType(DataType.MultilineText)]
        public string OptionBFeedback { get; set; }
        /// <summary>
        /// Description of Option C. This field can be interpreted as a LaTeX mathematical formula, and can contain
        /// both variables (Identified by a '%', e.g. "%x") and expressions that should be evaluated (Identified by
        /// surrounding '|', e.g. "|2+3|"). 
        /// </summary>
        [Required]
        [Display(Name = "Inciso C")]
        [DataType(DataType.MultilineText)]
        public string OptionC { get; set; }
        /// <summary>
        /// Desribes if Option C is a correct option in the question.
        /// </summary>
        [Required]
        [Display(Name = "C es correcta")]
        public bool OptionCCorrect { get; set; }
        /// <summary>
        /// Feedback for choosing Option C.
        /// </summary>
        [Required]
        [Display(Name = "Retroalimentacion C")]
        [DataType(DataType.MultilineText)]
        public string OptionCFeedback { get; set; }
        /// <summary>
        /// Description of Option D. This field can be interpreted as a LaTeX mathematical formula, and can contain
        /// both variables (Identified by a '%', e.g. "%x") and expressions that should be evaluated (Identified by
        /// surrounding '|', e.g. "|2+3|"). 
        /// </summary>
        [Required]
        [Display(Name = "Inciso D")]
        [DataType(DataType.MultilineText)]
        public string OptionD { get; set; }
        /// <summary>
        /// Desribes if Option D is a correct option in the question.
        /// </summary>
        [Required]
        [Display(Name = "D es correcta")]
        public bool OptionDCorrect { get; set; }
        /// <summary>
        /// Feedback for choosing Option D.
        /// </summary>
        [Required]
        [Display(Name = "Retroalimentacion D")]
        [DataType(DataType.MultilineText)]
        public string OptionDFeedback { get; set; }

        /// <summary>
        /// List containing all correct choices for this question.
        /// </summary>
        [Display(Name = "Respuestas correctas")]
        public List<Choice> CorrectAnswers
        {
            get
            {
                var correct = new List<Choice>();
                if (OptionACorrect) correct.Add(Choice.A);
                if (OptionBCorrect) correct.Add(Choice.B);
                if (OptionCCorrect) correct.Add(Choice.C);
                if (OptionDCorrect) correct.Add(Choice.D);
                return correct;
            }
        }

        /// <summary>
        /// Exam to which the question belongs.
        /// </summary>
        public virtual Exam Exam { get; set; }
        /// <summary>
        /// All answers that have been registered for this question.
        /// </summary>
        public virtual ICollection<Answer> Answers { get; set; }
        /// <summary>
        /// Variables that the question contains.
        /// </summary>
        public virtual ICollection<Variable> Variables { get; set; }

        /// <summary>
        /// Copies the question, but eliminating all notation from it ('|' and '%')
        /// </summary>
        /// <returns>A new question, with no notation on its description or options.</returns>
        public Question CopyWithNoNotation()
        {
            return new Question
            {
                ID = this.ID,
                ExamID = this.ExamID,
                Description = this.Description.Replace("%", "").Replace("|", ""),
                OptionA = this.OptionA.Replace("%", "").Replace("|", ""),
                OptionACorrect = this.OptionACorrect,
                OptionAFeedback = this.OptionAFeedback,
                OptionB = this.OptionB.Replace("%", "").Replace("|", ""),
                OptionBCorrect = this.OptionBCorrect,
                OptionBFeedback = this.OptionBFeedback,
                OptionC = this.OptionC.Replace("%", "").Replace("|", ""),
                OptionCCorrect = this.OptionCCorrect,
                OptionCFeedback = this.OptionCFeedback,
                OptionD = this.OptionD.Replace("%", "").Replace("|", ""),
                OptionDCorrect = this.OptionDCorrect,
                OptionDFeedback = this.OptionDFeedback,
                Exam = this.Exam,
                Answers = this.Answers,
                Variables = this.Variables
            };
        }

        /// <summary>
        /// Copies the question, but replacing each variable with one of its possible values, and evaluating every
        /// marked operation from the description, and its four options.
        /// </summary>
        /// <returns>An evaluated copy of the question.</returns>
        public Question CopyEvaluatedWithRandomValues()
        {
            Question question = new Question
            {
                ID = this.ID,
                ExamID = this.ExamID,
                Description = this.Description,
                OptionA = this.OptionA,
                OptionACorrect = this.OptionACorrect,
                OptionAFeedback = this.OptionAFeedback,
                OptionB = this.OptionB,
                OptionBCorrect = this.OptionBCorrect,
                OptionBFeedback = this.OptionBFeedback,
                OptionC = this.OptionC,
                OptionCCorrect = this.OptionCCorrect,
                OptionCFeedback = this.OptionCFeedback,
                OptionD = this.OptionD,
                OptionDCorrect = this.OptionDCorrect,
                OptionDFeedback = this.OptionDFeedback,
                Exam = this.Exam,
                Answers = this.Answers,
                Variables = this.Variables
            };

            foreach(var variable in question.Variables)
            {
                var value = variable.RandomValue;

                question.Description = question.Description.Replace("%" + variable.Symbol, value.ToString());
                question.OptionA = question.OptionA.Replace("%" + variable.Symbol, value.ToString());
                question.OptionB = question.OptionB.Replace("%" + variable.Symbol, value.ToString());
                question.OptionC = question.OptionC.Replace("%" + variable.Symbol, value.ToString());
                question.OptionD = question.OptionD.Replace("%" + variable.Symbol, value.ToString());
            }

            var descriptionSegments = question.Description.Split('|');
            for (int operation = 1; operation < descriptionSegments.Length; operation += 2)
            {
                descriptionSegments[operation] = ((int)Evaluate(descriptionSegments[operation])).ToString();
            }
            question.Description = String.Join("", descriptionSegments);

            var optionSegments = question.OptionA.Split('|');
            for (int operation = 1; operation < optionSegments.Length; operation += 2)
            {
                optionSegments[operation] = ((int)Evaluate(optionSegments[operation])).ToString();
            }
            question.OptionA = String.Join("", optionSegments);

            optionSegments = question.OptionB.Split('|');
            for (int operation = 1; operation < optionSegments.Length; operation += 2)
            {
                optionSegments[operation] = ((int)Evaluate(optionSegments[operation])).ToString();
            }
            question.OptionB = String.Join("", optionSegments);

            optionSegments = question.OptionC.Split('|');
            for (int operation = 1; operation < optionSegments.Length; operation += 2)
            {
                optionSegments[operation] = ((int)Evaluate(optionSegments[operation])).ToString();
            }
            question.OptionC = String.Join("", optionSegments);

            optionSegments = question.OptionD.Split('|');
            for (int operation = 1; operation < optionSegments.Length; operation += 2)
            {
                optionSegments[operation] = ((int)Evaluate(optionSegments[operation])).ToString();
            }
            question.OptionD = String.Join("", optionSegments);

            return question;
        }

        //Gotten from:
        //http://stackoverflow.com/questions/333737/evaluating-string-342-yield-int-18
        /// <summary>
        /// Evaluates a numeric expression
        /// </summary>
        /// <param name="expression">The expression to be evaluated.</param>
        /// <returns>The resulting value.</returns>
        private double Evaluate(string expression)
        {
            var loDataTable = new System.Data.DataTable();
            var loDataColumn = new System.Data.DataColumn("Eval", typeof(double), expression);
            loDataTable.Columns.Add(loDataColumn);
            loDataTable.Rows.Add(0);
            return (double)(loDataTable.Rows[0]["Eval"]);
        }
    }
}