using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiagnosticoDeMatematicas.Models
{
    public class Question
    {
        [Display(Name = "Pregunta")]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Examen")]
        public int ExamID { get; set; }
        [Required]
        [Display(Name = "Pregunta")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Inciso A")]
        [DataType(DataType.MultilineText)]
        public string OptionA { get; set; }
        [Required]
        [Display(Name = "A es correcta")]
        public bool OptionACorrect { get; set; }
        [Required]
        [Display(Name = "Retroalimentacion A")]
        [DataType(DataType.MultilineText)]
        public string OptionAFeedback { get; set; }
        [Required]
        [Display(Name = "Inciso B")]
        [DataType(DataType.MultilineText)]
        public string OptionB { get; set; }
        [Required]
        [Display(Name = "B es correcta")]
        public bool OptionBCorrect { get; set; }
        [Required]
        [Display(Name = "Retroalimentacion B")]
        [DataType(DataType.MultilineText)]
        public string OptionBFeedback { get; set; }
        [Required]
        [Display(Name = "Inciso C")]
        [DataType(DataType.MultilineText)]
        public string OptionC { get; set; }
        [Required]
        [Display(Name = "C es correcta")]
        public bool OptionCCorrect { get; set; }
        [Required]
        [Display(Name = "Retroalimentacion C")]
        [DataType(DataType.MultilineText)]
        public string OptionCFeedback { get; set; }
        [Required]
        [Display(Name = "Inciso D")]
        [DataType(DataType.MultilineText)]
        public string OptionD { get; set; }
        [Required]
        [Display(Name = "D es correcta")]
        public bool OptionDCorrect { get; set; }
        [Required]
        [Display(Name = "Retroalimentacion D")]
        [DataType(DataType.MultilineText)]
        public string OptionDFeedback { get; set; }

        [Display(Name = "Respuestas correctas")]
        public List<char> CorrectAnswers
        {
            get
            {
                var correct = new List<char>();
                if (OptionACorrect) correct.Add('A');
                if (OptionBCorrect) correct.Add('B');
                if (OptionCCorrect) correct.Add('C');
                if (OptionDCorrect) correct.Add('D');
                return correct;
            }
        }

        public virtual Exam Exam { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Variable> Variables { get; set; }

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