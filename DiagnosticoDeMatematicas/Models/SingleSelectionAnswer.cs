namespace DiagnosticoDeMatematicas.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Class representing a question and the answer that was chosen.
    /// </summary>
    [Table("SingleSelectionAnswer")]
    public class SingleSelectionAnswer : SelectionAnswer
    {
        [Required]
        public int SelectionId { get; set; }

        [ForeignKey("SelectionId")]
        public virtual QuestionOption Selection { get; set; } 

        /// <summary>
        /// Gets a value indicating whether the option selected is a correct one.
        /// </summary>
        [Display(Name = "Es correcta")]
        public override bool IsCorrect => Selection != null && Selection.IsCorrect;
    }
}