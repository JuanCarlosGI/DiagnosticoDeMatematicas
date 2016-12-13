namespace DiagnosticoDeMatematicas.Helpers.IEvaluator
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    /// <summary>
    /// Static class in charge of obtaining all possible evaluations of a question.
    /// </summary>
    public static class SpectrumEvaluator
    {
        /// <summary>
        /// Obtains a list with all possible evaluations of variables in a question.
        /// </summary>
        /// <param name="question">Question to be evaluated.</param>
        /// <param name="variables">Variables to be evaluated.</param>
        /// <returns>A list containing all possible combinations of variables.</returns>
        public static List<Question> Evaluate(Question question, List<Variable> variables)
        {
            if (variables.Count == 0)
            {
                return new List<Question>
                {
                    SpecificEvaluator.EvaluateParts(question)
                };
            }

            var variable = variables.First();
            var variablesAux = new List<Variable>(variables);
            variablesAux.Remove(variable);

            var results = new List<Question>();
            foreach (var range in variable.Ranges)
            {
                for (int n = range.Minimum; n <= range.Maximum; n++)
                {
                    var aux = SpecificEvaluator.Evaluate(question, variable.Symbol, n);
                    results.AddRange(Evaluate(aux, variablesAux));
                }    
            }

            return results;
        }
    }
}