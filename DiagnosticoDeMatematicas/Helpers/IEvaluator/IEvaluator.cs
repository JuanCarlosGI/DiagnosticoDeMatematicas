namespace DiagnosticoDeMatematicas.Helpers.IEvaluator
{
    using Models;

    /// <summary>
    /// Interface for an object that can evaluate a question's variables.
    /// </summary>
    public interface IEvaluator
    {
        /// <summary>
        /// Evaluates a question.
        /// </summary>
        /// <param name="question">Question to be evaluated.</param>
        /// <returns>Evaluated question.</returns>
        QuestionAbstract Evaluate(QuestionAbstract question);
    }
}
