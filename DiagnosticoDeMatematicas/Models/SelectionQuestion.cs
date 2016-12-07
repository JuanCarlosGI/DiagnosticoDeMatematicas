namespace DiagnosticoDeMatematicas.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// A model representing a question that will be answered using some sort of selections.
    /// </summary>
    [Table("SelectionQuestion")]
    public class SelectionQuestion : QuestionAbstract
    {
        /// <summary>
        /// Gets or sets the collection of options of the question.
        /// </summary>
        public virtual ICollection<QuestionOption> Options { get; set; }
    }
}