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
        /// Copies the question, but eliminating all notation from it ('|' and '%')
        /// </summary>
        /// <returns>A new question, with no notation on its description or options.</returns>
        public Question CopyWithNoNotation()
        {
            return new Question
            {
                ID = ID,
                ExamID = ExamID,
                Description = Description.Replace("%", string.Empty).Replace("|", string.Empty),
                OptionA = OptionA.Replace("%", string.Empty).Replace("|", string.Empty),
                OptionACorrect = OptionACorrect,
                OptionAFeedback = OptionAFeedback,
                OptionB = OptionB.Replace("%", string.Empty).Replace("|", string.Empty),
                OptionBCorrect = OptionBCorrect,
                OptionBFeedback = OptionBFeedback,
                OptionC = OptionC.Replace("%", string.Empty).Replace("|", string.Empty),
                OptionCCorrect = OptionCCorrect,
                OptionCFeedback = OptionCFeedback,
                OptionD = OptionD.Replace("%", string.Empty).Replace("|", string.Empty),
                OptionDCorrect = OptionDCorrect,
                OptionDFeedback = OptionDFeedback,
                Exam = Exam,
                Answers = Answers,
                Variables = Variables
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
                ID = ID,
                ExamID = ExamID,
                Description = Description,
                OptionA = OptionA,
                OptionACorrect = OptionACorrect,
                OptionAFeedback = OptionAFeedback,
                OptionB = OptionB,
                OptionBCorrect = OptionBCorrect,
                OptionBFeedback = OptionBFeedback,
                OptionC = OptionC,
                OptionCCorrect = OptionCCorrect,
                OptionCFeedback = OptionCFeedback,
                OptionD = OptionD,
                OptionDCorrect = OptionDCorrect,
                OptionDFeedback = OptionDFeedback,
                Exam = Exam,
                Answers = Answers,
                Variables = Variables
            };

            foreach (var variable in question.Variables)
            {
                var value = variable.RandomValue();

                question.Description = question.Description.Replace("%" + variable.Symbol, value.ToString());
                question.OptionA = question.OptionA.Replace("%" + variable.Symbol, value.ToString());
                question.OptionB = question.OptionB.Replace("%" + variable.Symbol, value.ToString());
                question.OptionC = question.OptionC.Replace("%" + variable.Symbol, value.ToString());
                question.OptionD = question.OptionD.Replace("%" + variable.Symbol, value.ToString());
            }

            var descriptionSegments = question.Description.Split('|');
            for (int operation = 1; operation < descriptionSegments.Length; operation += 2)
            {
                descriptionSegments[operation] = Evaluate(descriptionSegments[operation]).ToString();
            }

            question.Description = string.Join(string.Empty, descriptionSegments);

            var optionSegments = question.OptionA.Split('|');
            for (int operation = 1; operation < optionSegments.Length; operation += 2)
            {
                optionSegments[operation] = Evaluate(optionSegments[operation]).ToString();
            }

            question.OptionA = string.Join(string.Empty, optionSegments);

            optionSegments = question.OptionB.Split('|');
            for (int operation = 1; operation < optionSegments.Length; operation += 2)
            {
                optionSegments[operation] = Evaluate(optionSegments[operation]).ToString();
            }

            question.OptionB = string.Join(string.Empty, optionSegments);

            optionSegments = question.OptionC.Split('|');
            for (int operation = 1; operation < optionSegments.Length; operation += 2)
            {
                optionSegments[operation] = Evaluate(optionSegments[operation]).ToString();
            }

            question.OptionC = string.Join(string.Empty, optionSegments);

            optionSegments = question.OptionD.Split('|');
            for (int operation = 1; operation < optionSegments.Length; operation += 2)
            {
                optionSegments[operation] = Evaluate(optionSegments[operation]).ToString();
            }

            question.OptionD = string.Join(string.Empty, optionSegments);

            return question;
        }

        /// <summary>
        /// Evaluates a numeric expression
        /// Gotten from:
        /// http://stackoverflow.com/questions/333737/evaluating-string-342-yield-int-18
        /// </summary>
        /// <param name="expression">The expression to be evaluated.</param>
        /// <returns>The resulting value.</returns>
        private double Evaluate(string expression)
        {
            var dataTable = new System.Data.DataTable();
            var dataColumn = new System.Data.DataColumn("Eval", typeof(double), expression);
            dataTable.Columns.Add(dataColumn);
            dataTable.Rows.Add(0);
            return (double)dataTable.Rows[0]["Eval"];
        }
    }
}