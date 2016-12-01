namespace DiagnosticoDeMatematicas.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Class representing an option of a question.
    /// </summary>
    public class QuestionOption
    {
        /// <summary>
        /// Gets or sets the Id of the option.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Id of the question it belongs to.
        /// </summary>
        [Required]
        [Display(Name = "Pregunta")]
        public int QuestionId { get; set; }

        /// <summary>
        /// Gets or sets the description of the option
        /// </summary>
        [Required]
        [Display(Name = "Descripción")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the option is true or not.
        /// </summary>
        [Required]
        [Display(Name = "Es correcta")]
        public bool IsCorrect { get; set; }

        /// <summary>
        /// Gets or sets the feedback that the option will give.
        /// </summary>
        [Required]
        [Display(Name = "Retroalimentación")]
        public string Feedback { get; set; }

        /// <summary>
        /// Gets or sets the question it belongs to.
        /// </summary>
        [ForeignKey("QuestionId")]
        public virtual SelectionQuestion Question { get; set; }
    }
}