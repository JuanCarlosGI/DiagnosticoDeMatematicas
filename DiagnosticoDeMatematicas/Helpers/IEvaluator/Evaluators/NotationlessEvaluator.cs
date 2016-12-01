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
            if (question is SelectionQuestion)
            {
                SelectionQuestion aux = new SelectionQuestion
                {
                    Description = question.Description,
                    ExamID = question.ExamID,
                    Options = (question as SelectionQuestion).Options,
                    Answers = question.Answers,
                    Exam = question.Exam,
                    Id = question.Id,
                    Variables = question.Variables
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