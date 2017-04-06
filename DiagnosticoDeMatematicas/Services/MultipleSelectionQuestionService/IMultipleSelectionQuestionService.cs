using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiagnosticoDeMatematicas.Models;
using DiagnosticoDeMatematicas.Models.ViewModels.MultipleSelectionQuestion;

namespace DiagnosticoDeMatematicas.Services.MultipleSelectionQuestionService
{
    public interface IMultipleSelectionQuestionService
    {
        /// <summary>
        /// Creates a question beloinging to the corresponging exam.
        /// </summary>
        /// <param name="examId">ID of the Exam it will belong to.</param>
        /// <returns>The created question.</returns>
        MultipleSelectionQuestion CreateQuestion(int examId);

        /// <summary>
        /// Removes all special notation from a question.
        /// </summary>
        /// <param name="question">Question to be evaluated.</param>
        /// <returns>The evaluated question.</returns>
        MultipleSelectionQuestion EvaluateNotationless(MultipleSelectionQuestion question);

        /// <summary>
        /// Finds a question.
        /// </summary>
        /// <param name="questionId">ID of the question</param>
        /// <returns>The question.</returns>
        MultipleSelectionQuestion FindQuestion(int questionId);

        /// <summary>
        /// Finds a question and populates all its options.
        /// </summary>
        /// <param name="questionId">ID of the question</param>
        /// <returns>The question with options</returns>
        QuestionWithOptionsViewModel GetQuestionWithOptions(int questionId);

        /// <summary>
        /// Saves a question and its options.
        /// </summary>
        /// <param name="model">The model with the data.</param>
        void SaveQuestion(QuestionWithOptionsViewModel model);

        /// <summary>
        /// Deletes a question from DB.
        /// </summary>
        /// <param name="questionId">ID of the question to be removed.</param>
        void DeleteQuestion(int questionId);

        /// <summary>
        /// Disposes the DB.
        /// </summary>
        void DisposeDb();
    }
}
