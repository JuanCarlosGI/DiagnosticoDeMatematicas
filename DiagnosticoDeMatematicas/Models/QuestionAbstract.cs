namespace DiagnosticoDeMatematicas.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Model representing a question.
    /// </summary>
    public class QuestionAbstract
    {
        /// <summary>
        /// Gets or sets the ID of the question.
        /// </summary>
        [Display(Name = "Pregunta")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of the exam to which this question belongs.
        /// </summary>
        [Required]
        [Display(Name = "Examen")]
        public int ExamId { get; set; }

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
        /// Gets or sets the exam to which the question belongs.
        /// </summary>
        public virtual Exam Exam { get; set; }

        /// <summary>
        /// Gets or sets the answers that have been registered for this question.
        /// </summary>
        public virtual ICollection<AnswerAbstract> Answers { get; set; }

        /// <summary>
        /// Gets or sets the variables that the question contains.
        /// </summary>
        public virtual ICollection<Variable> Variables { get; set; }
    }
}