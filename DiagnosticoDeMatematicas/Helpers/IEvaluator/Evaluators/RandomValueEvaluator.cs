namespace DiagnosticoDeMatematicas.Helpers.IEvaluator
{
    using System.Text.RegularExpressions;
    using Models;

    /// <summary>
    /// Class responsible for evaluating a question with valid random values.
    /// </summary>
    public class RandomValueEvaluator : IEvaluator
    {
        /// <summary>
        /// Evaluates a question with a valid random value for each variable.
        /// </summary>
        /// <param name="question">Question to be evaluated.</param>
        /// <returns>The evaluated question.</returns>
        public Question Evaluate(Question question)
        {
            Question aux = question.Copy();

            // Evaluate each variable
            foreach (var variable in aux.Variables)
            {
                var value = variable.RandomValue();

                aux.Description = aux.Description.Replace("%" + variable.Symbol, value.ToString());
                aux.OptionA = aux.OptionA.Replace("%" + variable.Symbol, value.ToString());
                aux.OptionB = aux.OptionB.Replace("%" + variable.Symbol, value.ToString());
                aux.OptionC = aux.OptionC.Replace("%" + variable.Symbol, value.ToString());
                aux.OptionD = aux.OptionD.Replace("%" + variable.Symbol, value.ToString());
            }

            aux.Description = EvaluatePart(aux.Description);
            aux.OptionA = EvaluatePart(aux.OptionA);
            aux.OptionB = EvaluatePart(aux.OptionB);
            aux.OptionC = EvaluatePart(aux.OptionC);
            aux.OptionD = EvaluatePart(aux.OptionD);

            return aux;
        }

        /// <summary>
        /// Evaluates a single string.
        /// </summary>
        /// <param name="part">String to be evaluated.</param>
        /// <returns>Evaluated string.</returns>
        private string EvaluatePart(string part)
        {
            var partSegments = part.Split('|');
            for (int operation = 1; operation < partSegments.Length; operation += 2)
            {
                partSegments[operation] = Evaluate(partSegments[operation]).ToString();
            }

            var aux = string.Join(string.Empty, partSegments);

            aux = EliminateDoubleSigns(aux);
            aux = EliminateMultiplyingOnes(aux);

            return aux;
        }

        /// <summary>
        /// Evaluates a numeric expression
        /// Gotten from:
        /// http://stackoverflow.com/questions/333737/evaluating-string-342-yield-int-18
        /// </summary>
        /// <param name="expression">The expression to be evaluated.</param>
        /// <returns>The resulting value.</returns>
        private double Evaluate(string expression)
        {
            var dataTable = new System.Data.DataTable();
            var dataColumn = new System.Data.DataColumn("Eval", typeof(double), expression);
            dataTable.Columns.Add(dataColumn);
            dataTable.Rows.Add(0);
            return (double)dataTable.Rows[0]["Eval"];
        }

        /// <summary>
        /// Replaces double signs (+-) or (--) with their equivalent single sign.
        /// </summary>
        /// <param name="expression">String to be modified.</param>
        /// <returns>Modified string.</returns>
        private string EliminateDoubleSigns(string expression)
        {
            string pattern;
            string replacement;
            Regex rgx;
            string result;

            pattern = Regex.Escape("+") + "\\s*-";
            replacement = "-";
            rgx = new Regex(pattern);
            result = rgx.Replace(expression, replacement);

            pattern = "-\\s*-";
            replacement = "+";
            rgx = new Regex(pattern);
            result = rgx.Replace(result, replacement);

            return result;
        }

        /// <summary>
        /// Eliminates '1' when it precedes a letter as a multiplication.
        /// </summary>
        /// <param name="expression">String to be modified.</param>
        /// <returns>Modified string.</returns>
        private string EliminateMultiplyingOnes(string expression)
        {
            string pattern = "([^\\d])1([a-zA-Z])";
            string replacement = "$1$2";
            Regex rgx = new Regex(pattern);
            string result = rgx.Replace(expression, replacement);

            return result;
        }
    }
}