using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiagnosticoDeMatematicas.Models;

namespace DiagnosticoDeMatematicas.Services.QuestionsService
{
    interface IQuestionsService
    {
        /// <summary>
        /// Finds a question given its ID.
        /// </summary>
        /// <param name="questionId">ID of the question</param>
        /// <returns>The question.</returns>
        Question FindQuestion(int questionId);

        /// <summary>
        /// Gets a collection of all possible variable combinations.
        /// </summary>
        /// <param name="question">Question to analyze.</param>
        /// <returns>Collection of all combinations.</returns>
        ICollection<Question> GetCombinations(Question question);

        /// <summary>
        /// Removes all special notation from a question.
        /// </summary>
        /// <param name="question">Question to be modified.</param>
        /// <returns>The notationless question.</returns>
        Question EvaluateNotationless(Question question);

        /// <summary>
        /// Disposes the DB.
        /// </summary>
        void DisposeDb();
    }
}
