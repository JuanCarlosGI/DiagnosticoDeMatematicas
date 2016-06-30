namespace DiagnosticoDeMatematicas.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Foolproof;

    /// <summary>
    /// Model representing a range of integers.
    /// </summary>
    public class Range
    {
        /// <summary>
        /// Gets or sets the ID of the range
        /// </summary>
        [Display(Name = "Rango")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the ID of the question this range belongs to.
        /// </summary>
        [Required]
        [ForeignKey("Variable"), Column(Order = 1)]
        [Display(Name = "Pregunta")]
        public int QuestionId { get; set; }

        /// <summary>
        /// Gets or sets the symbol that has this range.
        /// </summary>
        [Required]
        [ForeignKey("Variable"), Column(Order = 0)]
        [Display(Name = "Variable")]
        public string Symbol { get; set; }

        /// <summary>
        /// Gets or sets the minimum value of the range.
        /// </summary>
        [Required]
        [Display(Name = "Mínimo")]
        public int Minimum { get; set; }

        /// <summary>
        /// Gets or sets the maximum value of the range.
        /// </summary>
        [Required]
        [Display(Name = "Máximo")]
        [GreaterThanOrEqualTo("Minimum", ErrorMessage = "Debe de ser un valor igual o mayor al mínimo.")]
        public int Maximum { get; set; }

        /// <summary>
        /// Gets or sets the variable that this range belongs to.
        /// </summary>
        public virtual Variable Variable { get; set; }
    }
}