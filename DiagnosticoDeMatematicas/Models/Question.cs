namespace DiagnosticoDeMatematicas.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Model representing a question.
    /// </summary>
    public class Question
    {
        /// <summary>
        /// Gets or sets the ID of the question.
        /// </summary>
        [Display(Name = "Pregunta")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the ID of the exam to which this question belongs.
        /// </summary>
        [Required]
        [Display(Name = "Examen")]
        public int ExamID { get; set; }

        /// <summary>
        /// Gets or sets the description of the question. This field can be interpreted as a Latex mathematical formula,
        /// and can contain both variables (Identified by a '%', e.g. "%x") and expressions that should be evaluated
        /// (Identified by surrounding '|', e.g. "|2+3|").
        /// Also, it can contain chart definitions. For more information on defining charts, read the documentation on
        /// Helpers.Charts.ChartBuilder.
        /// </summary>
        [Required]
        [Display(Name = "Pregunta")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the description of Option A. This field can be interpreted the same way as the description of
        /// the question.
        /// </summary>
        [Required]
        [Display(Name = "Inciso A")]
        [DataType(DataType.MultilineText)]
        public string OptionA { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Option A is a correct option in the question.
        /// </summary>
        [Required]
        [Display(Name = "A es correcta")]
        public bool OptionACorrect { get; set; }

        /// <summary>
        /// Gets or sets the feedback for choosing Option A.
        /// </summary>
        [Required]
        [Display(Name = "Retroalimentacion A")]
        [DataType(DataType.MultilineText)]
        public string OptionAFeedback { get; set; }

        /// <summary>
        /// Gets or sets the description of Option B. This field can be interpreted the same way as the description of
        /// the question.
        /// </summary>
        [Required]
        [Display(Name = "Inciso B")]
        [DataType(DataType.MultilineText)]
        public string OptionB { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Option B is a correct option in the question.
        /// </summary>
        [Required]
        [Display(Name = "B es correcta")]
        public bool OptionBCorrect { get; set; }

        /// <summary>
        /// Gets or sets the feedback for choosing Option B.
        /// </summary>
        [Required]
        [Display(Name = "Retroalimentacion B")]
        [DataType(DataType.MultilineText)]
        public string OptionBFeedback { get; set; }

        /// <summary>
        /// Gets or sets the description of Option C. This field can be interpreted the same way as the description of
        /// the question.
        /// </summary>
        [Required]
        [Display(Name = "Inciso C")]
        [DataType(DataType.MultilineText)]
        public string OptionC { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Option C is a correct option in the question.
        /// </summary>
        [Required]
        [Display(Name = "C es correcta")]
        public bool OptionCCorrect { get; set; }

        /// <summary>
        /// Gets or sets the feedback for choosing Option C.
        /// </summary>
        [Required]
        [Display(Name = "Retroalimentacion C")]
        [DataType(DataType.MultilineText)]
        public string OptionCFeedback { get; set; }

        /// <summary>
        /// Gets or sets the description of Option D. This field can be interpreted the same way as the description of
        /// the question.
        /// </summary>
        [Required]
        [Display(Name = "Inciso D")]
        [DataType(DataType.MultilineText)]
        public string OptionD { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Option D is a correct option in the question.
        /// </summary>
        [Required]
        [Display(Name = "D es correcta")]
        public bool OptionDCorrect { get; set; }

        /// <summary>
        /// Gets or sets the feedback for choosing Option D.
        /// </summary>
        [Required]
        [Display(Name = "Retroalimentacion D")]
        [DataType(DataType.MultilineText)]
        public string OptionDFeedback { get; set; }

        /// <summary>
        /// Gets a list containing all correct choices for this question.
        /// </summary>
        [Display(Name = "Respuestas correctas")]
        public List<Choice> CorrectAnswers
        {
            get
            {
                var correct = new List<Choice>();

                if (OptionACorrect)
                {
                    correct.Add(Choice.A);
                }

                if (OptionBCorrect)
                {
                    correct.Add(Choice.B);
                }

                if (OptionCCorrect)
                {
                    correct.Add(Choice.C);
                }

                if (OptionDCorrect)
                {
                    correct.Add(Choice.D);
                }

                return correct;
            }
        }

        /// <summary>
        /// Gets or sets the exam to which the question belongs.
        /// </summary>
        public virtual Exam Exam { get; set; }

        /// <summary>
        /// Gets or sets the answers that have been registered for this question.
        /// </summary>
        public virtual ICollection<Answer> Answers { get; set; }

        /// <summary>
        /// Gets or sets the variables that the question contains.
        /// </summary>
        public virtual ICollection<Variable> Variables { get; set; }

        /// <summary>
        /// Creates a shallow copy of the Question.
        /// </summary>
        /// <returns>A copy of the question.</returns>
        public Question Copy()
        {
            return new Question
            {
                ID = ID,
                ExamID = ExamID,

                Description = string.Copy(Description),
                OptionA = string.Copy(OptionA),
                OptionB = string.Copy(OptionB),
                OptionC = string.Copy(OptionC),
                OptionD = string.Copy(OptionD),
                OptionAFeedback = string.Copy(OptionAFeedback),
                OptionBFeedback = string.Copy(OptionBFeedback),
                OptionCFeedback = string.Copy(OptionCFeedback),
                OptionDFeedback = string.Copy(OptionDFeedback),
                OptionACorrect = OptionACorrect,
                OptionBCorrect = OptionBCorrect,
                OptionCCorrect = OptionCCorrect,
                OptionDCorrect = OptionDCorrect,

                Exam = Exam,
                Answers = Answers,
                Variables = Variables
            };
        }
    }
}