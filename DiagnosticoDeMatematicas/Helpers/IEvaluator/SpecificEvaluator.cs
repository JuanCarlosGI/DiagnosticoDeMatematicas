namespace DiagnosticoDeMatematicas.Helpers.IEvaluator
{
    using System.Collections.Generic;
    using System.Data;
    using System.Globalization;
    using System.Text.RegularExpressions;
    using Models;

    /// <summary>
    /// Static class in charge of evaluating a specific variable with a specific value.
    /// </summary>
    public static class SpecificEvaluator
    {
        /// <summary>
        /// Evaluates a specific variable in a question with a specific value. Note that
        /// this does not evaluate expressions.
        /// </summary>
        /// <param name="question">Question to be evaluated</param>
        /// <param name="variable">Symbol of the variable to be evaluated</param>
        /// <param name="value">Value to evaluate with.</param>
        /// <returns>The evaluated question.</returns>
        public static Question Evaluate(Question question, string variable, int value)
        {
            var selectionQuestion = question as SelectionQuestion;
            if (selectionQuestion != null)
            {
                var options = new List<QuestionOption>();
                foreach (var option in selectionQuestion.Options)
                {
                    options.Add(new QuestionOption
                    {
                        Description = option.Description
                    });
                }

                SelectionQuestion aux = new SelectionQuestion
                {
                    Description = selectionQuestion.Description,
                    ExamId = selectionQuestion.ExamId,
                    Options = options,
                    Answers = selectionQuestion.Answers,
                    Exam = selectionQuestion.Exam,
                    Id = selectionQuestion.Id,
                    Variables = selectionQuestion.Variables
                };

                aux.Description = aux.Description.Replace("%" + variable, value.ToString());

                foreach (var option in aux.Options)
                {
                    option.Description = option.Description.Replace("%" + variable, value.ToString());
                }

                return aux;
            }

            return null;
        }

        /// <summary>
        /// Evaluates all expressions in the question.
        /// </summary>
        /// <param name="question">Question to be evaluated.</param>
        /// <returns>The evaluated question.</returns>
        public static Question EvaluateParts(Question question)
        {
            var selectionQuestion = question as SelectionQuestion;
            if (selectionQuestion != null)
            {
                selectionQuestion.Description = EvaluatePart(selectionQuestion.Description);

                foreach (var option in selectionQuestion.Options)
                {
                    option.Description = EvaluatePart(option.Description);
                }
            }

            return selectionQuestion;
        }

        /// <summary>
        /// Evaluates a single string.
        /// </summary>
        /// <param name="part">String to be evaluated.</param>
        /// <returns>Evaluated string.</returns>
        private static string EvaluatePart(string part)
        {
            var partSegments = part.Split('|');
            for (int operation = 1; operation < partSegments.Length; operation += 2)
            {
                partSegments[operation] = Evaluate(partSegments[operation]).ToString(CultureInfo.CurrentCulture);
            }

            var aux = string.Join(string.Empty, partSegments);
            aux = CancelNegativeDivNegative(aux);
            aux = TakeSingleMinusOutOfDivision(aux);
            aux = EliminateDoubleSigns(aux);
            aux = EliminateMultiplyingOnes(aux);
            aux = SimplifyFraction(aux);
            aux = EliminateDivisionByOne(aux);

            return aux;
        }

        /// <summary>
        /// Evaluates a numeric expression
        /// Gotten from:
        /// http://stackoverflow.com/questions/333737/evaluating-string-342-yield-int-18
        /// </summary>
        /// <param name="expression">The expression to be evaluated.</param>
        /// <returns>The resulting value.</returns>
        private static double Evaluate(string expression)
        {
            var dataTable = new DataTable();
            var dataColumn = new DataColumn("Eval", typeof(double), expression);
            dataTable.Columns.Add(dataColumn);
            dataTable.Rows.Add(0);
            return (double)dataTable.Rows[0]["Eval"];
        }

        /// <summary>
        /// Replaces double signs (+-) or (--) with their equivalent single sign.
        /// </summary>
        /// <param name="expression">String to be modified.</param>
        /// <returns>Modified string.</returns>
        private static string EliminateDoubleSigns(string expression)
        {
            var pattern = Regex.Escape("+") + "\\s*-";
            var replacement = "-";
            var rgx = new Regex(pattern);
            var result = rgx.Replace(expression, replacement);

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
        private static string EliminateMultiplyingOnes(string expression)
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
        private static string CancelNegativeDivNegative(string expression)
        {
            string s = "(\\s|\\\\,)*";
            string pattern = $"\\\\dfrac{s}{{{s}-{s}([0-9a-zA-Z]+){s}}}{s}{{{s}-{s}([0-9a-zA-Z]+){s}}}";
            string replacement = "\\dfrac{$4}{$9}";
            Regex rgx = new Regex(pattern);
            string result = rgx.Replace(expression, replacement);

            return result;
        }

        /// <summary>
        /// Modifies a string so that if a division is present in which either the numerator or the denominator are 
        /// negative (but not both), the negative sign is put outside the division instead.
        /// </summary>
        /// <param name="expression">String to be modified.</param>
        /// <returns>Modified string.</returns>
        private static string TakeSingleMinusOutOfDivision(string expression)
        {
            string s = "(\\s|\\\\,)*";
            string pattern = $"\\\\dfrac{s}({{{s}-{s}([0-9a-zA-Z]+){s}}}{s}{{{s}([0-9a-zA-Z]+){s}}}|{{{s}([0-9a-zA-Z]+){s}}}{s}{{{s}-{s}([0-9a-zA-Z]+){s}}})";
            string replacement = "-\\dfrac{$5$12}{$9$17}";
            Regex rgx = new Regex(pattern);
            string result = rgx.Replace(expression, replacement);

            return result;
        }

        private static string SimplifyFraction(string expression)
        {
            string pattern = "\\\\dfrac\\{(\\d*)\\}\\{(\\d*)\\}";

            MatchCollection matches = Regex.Matches(expression, pattern);

            var result = expression;
            foreach (Match match in matches)
            {
                var nominator = int.Parse(match.Groups[1].Value);
                var denominator = int.Parse(match.Groups[2].Value);
                Regex aux = new Regex($"\\\\dfrac\\{{({nominator})\\}}\\{{({denominator})\\}}");

                var lowest = nominator > denominator ? denominator : nominator;
                for (int factor = lowest; factor > 1; factor--)
                {
                    if (nominator%factor == 0 && denominator%factor == 0)
                    {
                        nominator = nominator/factor;
                        denominator = denominator/factor;
                        break;
                    }
                }

                var replacement = $"\\dfrac{{{nominator}}}{{{denominator}}}";
                result = aux.Replace(result, replacement);

            }

            return result;
        }
        private static string EliminateDivisionByOne(string expression)
        {
            string pattern = "\\\\dfrac\\{([^}\\n]*)\\}\\{1\\}";
            string replacement = "$1";
            Regex rgx = new Regex(pattern);
            string result = rgx.Replace(expression, replacement);

            return result;
        }
    }
}