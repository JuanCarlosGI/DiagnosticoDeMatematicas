using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiagnosticoDeMatematicas.Models;

namespace DiagnosticoDeMatematicas.Services.ResponsesService
{
    public interface IResponsesService
    {
        /// <summary>
        /// Gets a response
        /// </summary>
        /// <param name="id">ID of the response</param>
        /// <returns></returns>
        Response FindResponse(int id);

        /// <summary>
        /// Lazy loading was a problem, so load them eagerly
        /// </summary>
        /// <param name="responseAnswers">Collectio of responses to load.</param>
        void LoadMultipleSelectionAnswers(ICollection<Answer> responseAnswers);

        /// <summary>
        /// Generates new response, with current User in session and Exam loaded,
        /// and creates shuffled answers with evaluated variables.
        /// </summary>
        /// <param name="examId">Exam to which the response belongs.</param>
        /// <returns></returns>
        Response PrepareNewResponse(int examId);

        /// <summary>
        /// Finds an exam
        /// </summary>
        /// <param name="examIdValue">Exam to evaluate</param>
        /// <returns></returns>
        Exam FindExam(int examIdValue);

        /// <summary>
        /// Populates every object in the model and fills creation date.
        /// </summary>
        /// <param name="response">Response to be populated.</param>
        void PopulateResponseModel(Response response);

        /// <summary>
        /// Saves the response.
        /// </summary>
        /// <param name="response"></param>
        void SaveResponse(Response response);

        /// <summary>
        /// Deletes a response.
        /// </summary>
        /// <param name="id">ID of the response to delete.</param>
        void DeleteResponse(int id);

        void DisposeDb();

        /// <summary>
        /// Gets a list with all responses.
        /// </summary>
        /// <returns></returns>
        List<Response> GetAllResponses();
    }
}
