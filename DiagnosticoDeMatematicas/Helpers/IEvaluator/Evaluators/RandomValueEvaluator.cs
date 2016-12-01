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

                // Evaluate each variable
                foreach (var variable in aux.Variables)
                {
                    var value = variable.RandomValue();

                    aux.Description = aux.Description.Replace("%" + variable.Symbol, value.ToString());

                    foreach (var option in aux.Options)
                    {
                        option.Description = option.Description.Replace("%" + variable.Symbol, value.ToString());
                    }
                }

                aux.Description = EvaluatePart(aux.Description);

                foreach (var option in aux.Options)
                {
                    option.Description = EvaluatePart(option.Description);
                }

                return aux;
            }

            return null;
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
            aux = CancelNegativeDivNegative(aux);
            aux = TakeSingleMinusOutOfDivision(aux);
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

        /// <summary>
        /// Simplifies a division where both the numerator and denominator are negative, and eliminates the negative 
        /// signs.
        /// </summary>
        /// <param name="expression">String to be modified.</param>
        /// <returns>Modified string.</returns>
        private string CancelNegativeDivNegative(string expression)
        {
            string s = "(\\s|\\\\,)*";
            string pattern = $"\\\\dfrac{s}{{{s}-{s}([0-9a-zA-Z]+){s}}}{s}{{{s}-{s}([0-9a-zA-Z]+){s}}}";
            string replacement = "\\dfrac{$4}{$9}";
            Regex rgx = new Regex(pattern);
            string result = rgx.Replace(expression, replacement);

            return result;
        }

        /// <summary>
        /// Modifies a string so that if a division is present in which either the numerator or the denumerator are 
        /// negative (but not both), the negative sign is put outside the division instead.
        /// </summary>
        /// <param name="expression">String to be modified.</param>
        /// <returns>Modified string.</returns>
        private string TakeSingleMinusOutOfDivision(string expression)
        {
            string s = "(\\s|\\\\,)*";
            string pattern = $"\\\\dfrac{s}({{{s}-{s}([0-9a-zA-Z]+){s}}}{s}{{{s}([0-9a-zA-Z]+){s}}}|{{{s}([0-9a-zA-Z]+){s}}}{s}{{{s}-{s}([0-9a-zA-Z]+){s}}})";
            string replacement = "-\\dfrac{$5$12}{$9$17}";
            Regex rgx = new Regex(pattern);
            string result = rgx.Replace(expression, replacement);

            return result;
        }
    }
}