using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DiagnosticoDeMatematicas.Models
{
    [Table("MultipleSelectionAnswer")]
    public sealed class MultipleSelectionAnswer : SelectionAnswer
    {
        [Display(Name = "Es correcta")]
        public override bool IsCorrect
        {
            get
            {
                return Selections.All(s => s.IsCorrect());
            }
        }

        public ICollection<BinaryOptionSelection> Selections { get; set; }

        public MultipleSelectionAnswer()
        {

        }

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
    }
}