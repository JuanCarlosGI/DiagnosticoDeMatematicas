namespace DiagnosticoDeMatematicas.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Class representing an abstract answer to a given question.
    /// </summary>
    public abstract class Answer
    {
        /// <summary>
        /// Gets or sets the ID of the response it belongs to.
        /// </summary>
        [Key, Column(Order = 0)]
        public int ResponseId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the question it is answering.
        /// </summary>
        [Key, Column(Order = 1)]
        public int QuestionId { get; set; }
        
        /// <summary>
        /// Gets or sets the response it belongs to.
        /// </summary>
        [ForeignKey("ResponseId")]
        public virtual Response Response { get; set; }

        /// <summary>
        /// Gets or sets the question it is answering.
        /// </summary>
        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }

        /// <summary>
        /// Gets a value indicating whether the answer is correct.
        /// </summary>
        [Display(Name = "Es correcta")]
        public abstract bool IsCorrect { get; }
    }
}