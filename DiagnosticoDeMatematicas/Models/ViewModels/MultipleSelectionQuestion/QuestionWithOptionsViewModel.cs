using System.Collections.Generic;

namespace DiagnosticoDeMatematicas.Models.ViewModels.MultipleSelectionQuestion
{
    /// <summary>
    /// View Model of a <see cref="MultipleSelectionQuestion"/> with all its <see cref="QuestionOption"/>.
    /// </summary>
    public class QuestionWithOptionsViewModel
    {
        /// <summary>
        /// Gets or sets the ID of the question.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of the exam to which the question belongs to.
        /// </summary>
        public int ExamId { get; set; }

        /// <summary>
        /// Gets or sets the description of the question.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the list of options that the question has.
        /// </summary>
        public List<QuestionOption> Options { get; set; }
    }
}