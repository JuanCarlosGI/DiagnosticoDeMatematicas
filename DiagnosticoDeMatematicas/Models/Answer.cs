namespace DiagnosticoDeMatematicas.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Possible answers for a question.
    /// </summary>
    public enum Choice
    {
        /// <summary>
        /// Option A
        /// </summary>
        A = 'A',

        /// <summary>
        /// Option B
        /// </summary>
        B,

        /// <summary>
        /// Option C
        /// </summary>
        C,

        /// <summary>
        /// Option D
        /// </summary>
        D
    }

    /// <summary>
    /// Class representing a question and the answer that was chosen.
    /// </summary>
    public class Answer
    {
        /// <summary>
        /// Gets or sets the ID of the response this answer belongs to.
        /// </summary>
        [Key, Column(Order = 0)]
        [ForeignKey("Response")]
        [Display(Name = "Entrega")]
        public int ResponseID { get; set; }

        /// <summary>
        /// Gets or sets the ID of the question that is being answered.
        /// </summary>
        [Key, Column(Order = 1)]
        [ForeignKey("Question")]
        [Display(Name = "Pregunta")]
        public int QuestionID { get; set; }

        /// <summary>
        /// Gets or sets the selected option.
        /// </summary>
        [Required]
        [Display(Name = "Eleccion")]
        [EnumDataType(typeof(Choice))]
        public Choice Choice { get; set; }

        /// <summary>
        /// Gets or sets the response to which this answer belongs to.
        /// </summary>
        public virtual Response Response { get; set; }

        /// <summary>
        /// Gets or sets the question that is being answered.
        /// </summary>
        public virtual Question Question { get; set; }

        /// <summary>
        /// Gets a value indicating whether the option selected is a correct one.
        /// </summary>
        [Display(Name = "Es correcta")]
        public bool IsCorrect
        {
            get
            {
                return Question.CorrectAnswers.Contains(Choice);
            }
        }
    }
}