﻿namespace DiagnosticoDeMatematicas.Helpers.IEvaluator
{
    using System.Data;
    using System.Globalization;
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
            var selectionQuestion = question as SelectionQuestion;
            if (selectionQuestion != null)
            {
                SelectionQuestion aux = new SelectionQuestion
                {
                    Description = selectionQuestion.Description,
                    ExamId = selectionQuestion.ExamId,
                    Options = selectionQuestion.Options,
                    Answers = selectionQuestion.Answers,
                    Exam = selectionQuestion.Exam,
                    Id = selectionQuestion.Id,
                    Variables = selectionQuestion.Variables
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
                partSegments[operation] = Evaluate(partSegments[operation]).ToString(CultureInfo.CurrentCulture);
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
        private string EliminateDoubleSigns(string expression)
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
        /// Modifies a string so that if a division is present in which either the numerator or the denominator are 
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