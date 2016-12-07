namespace DiagnosticoDeMatematicas.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    /// <summary>
    /// Model representing an answer of a <see cref="MultipleSelectionQuestion"/>.
    /// </summary>
    [Table("MultipleSelectionAnswer")]
    public sealed class MultipleSelectionAnswer : SelectionAnswer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleSelectionAnswer"/> class.
        /// </summary>
        public MultipleSelectionAnswer()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleSelectionAnswer"/> class.
        /// Initiates values according to a specific question that will be answered and
        /// a specific response.
        /// </summary>
        /// <param name="question">Question that it will be answering.</param>
        /// <param name="response">Response to which the answer will belong.</param>
        public MultipleSelectionAnswer(MultipleSelectionQuestion question, Response response)
        {
            ResponseId = response.Id;
            QuestionId = question.Id;

            Selections = new List<BinaryOptionSelection>();

            foreach (var option in question.Options)
            {
                Selections.Add(new BinaryOptionSelection
                {
                    MultipleSelectionQuestionId = question.Id,
                    QuestionOptionId = option.Id,
                    ResponseId = response.Id,
                    Selected = false
                });
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleSelectionAnswer"/> class.
        /// Initiates values according to a specific question that will be answered.
        /// </summary>
        /// <param name="question">Question that it will be answering.</param>
        public MultipleSelectionAnswer(MultipleSelectionQuestion question)
        {
            QuestionId = question.Id;

            Selections = new List<BinaryOptionSelection>();

            foreach (var option in question.Options)
            {
                Selections.Add(new BinaryOptionSelection
                {
                    MultipleSelectionQuestionId = question.Id,
                    QuestionOptionId = option.Id,
                    Selected = false
                });
            }
        }

        /// <summary>
        /// Gets or sets a collection of all the selections that the answer has.
        /// </summary>
        public ICollection<BinaryOptionSelection> Selections { get; set; }

        /// <summary>
        /// Gets a value indicating whether the answer is correct.
        /// </summary>
        [Display(Name = "Es correcta")]
        public override bool IsCorrect => Selections.All(s => s.IsCorrect);
    }
}