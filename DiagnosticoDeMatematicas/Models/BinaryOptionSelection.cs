namespace DiagnosticoDeMatematicas.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Model representing the selection of an option in an answer.
    /// </summary>
    public class BinaryOptionSelection
    {
        /// <summary>
        /// Gets or sets the ID of the response it belongs to.
        /// </summary>
        [Key, Column(Order = 0)]
        public int ResponseId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the question it belongs to.
        /// </summary>
        [Key, Column(Order = 1)]
        public int MultipleSelectionQuestionId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the question option it belongs to.
        /// </summary>
        [Key, Column(Order = 2)]
        public int QuestionOptionId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the option was selected or not.
        /// </summary>
        public bool Selected { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="MultipleSelectionAnswer"/> it belongs to.
        /// </summary>
        [ForeignKey("ResponseId,MultipleSelectionQuestionId")]
        public virtual MultipleSelectionAnswer MultipleSelectionAnswer { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="QuestionOption"/> it belongs to.
        /// </summary>
        [ForeignKey("QuestionOptionId")]
        public virtual QuestionOption QuestionOption { get; set; }

        /// <summary>
        /// Determines if the option is answered correctly.
        /// </summary>
        /// <returns>A value indicating whether the option was answered correctly.</returns>
        public bool IsCorrect => QuestionOption?.IsCorrect == Selected;
    }
}