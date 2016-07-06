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
        public Question Evaluate(Question question)
        {
            Question aux = question.Copy();

            aux.Description = aux.Description.Replace("%", string.Empty).Replace("|", string.Empty);
            aux.OptionA = aux.OptionA.Replace("%", string.Empty).Replace("|", string.Empty);
            aux.OptionB = aux.OptionB.Replace("%", string.Empty).Replace("|", string.Empty);
            aux.OptionC = aux.OptionC.Replace("%", string.Empty).Replace("|", string.Empty);
            aux.OptionD = aux.OptionD.Replace("%", string.Empty).Replace("|", string.Empty);

            return aux;
        }
    }
}