namespace DiagnosticoDeMatematicas.Helpers.IEvaluator
{
    using Models;

    /// <summary>
    /// Class responsible for removing all notation from a question.
    /// </summary>
    public class NotationlessEvaluator : IEvaluator
    {
        /// <summary>
        /// Evaluates a question, removing all notation and leaving the variables' names.
        /// </summary>
        /// <param name="question">Question to be evaluated.</param>
        /// <returns>Evaluated question.</returns>
        public QuestionAbstract Evaluate(QuestionAbstract question)
        {
            var selectionQuestion = question as SelectionQuestion;
            if (selectionQuestion != null)
            {
                SelectionQuestion aux;
                if (question is MultipleSelectionQuestion)
                    aux = new MultipleSelectionQuestion
                    {
                        Description = selectionQuestion.Description,
                        ExamId = selectionQuestion.ExamId,
                        Options = selectionQuestion.Options,
                        Answers = selectionQuestion.Answers,
                        Exam = selectionQuestion.Exam,
                        Id = selectionQuestion.Id,
                        Variables = selectionQuestion.Variables
                    };
                else
                    aux = new SingleSelectionQuestion
                    {
                        Description = selectionQuestion.Description,
                        ExamId = selectionQuestion.ExamId,
                        Options = selectionQuestion.Options,
                        Answers = selectionQuestion.Answers,
                        Exam = selectionQuestion.Exam,
                        Id = selectionQuestion.Id,
                        Variables = selectionQuestion.Variables
                    };

                aux.Description = aux.Description.Replace("%", string.Empty).Replace("|", string.Empty);

                foreach (var option in aux.Options)
                {
                    option.Description = option.Description.Replace("%", string.Empty).Replace("|", string.Empty);
                }

                return aux;
            }

            return null;
        }
    }
}