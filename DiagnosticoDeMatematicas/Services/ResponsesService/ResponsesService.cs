using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DiagnosticoDeMatematicas.DAL;
using DiagnosticoDeMatematicas.Helpers;
using DiagnosticoDeMatematicas.Helpers.IEvaluator;
using DiagnosticoDeMatematicas.Models;

namespace DiagnosticoDeMatematicas.Services.ResponsesService
{
    public class ResponsesService : IResponsesService
    {
        private readonly SiteContext _db;

        public ResponsesService(SiteContext db)
        {
            _db = db;
        }

        public Response FindResponse(int id)
        {
            return _db.Responses.Find(id);
        }

        public void LoadMultipleSelectionAnswers(ICollection<Answer> responseAnswers)
        {
            foreach (var answer in responseAnswers.ToArray())
            {
                var multipleAnswer = answer as MultipleSelectionAnswer;
                if (multipleAnswer != null)
                {
                    responseAnswers.Remove(answer);
                    responseAnswers.Add(_db.MultipleSelectionAnswers
                        .Include(a => a.Selections)
                        .Include(a => a.Question)
                        .Include(a => a.Response)
                        .SingleOrDefault(e => e.QuestionId == answer.QuestionId && e.ResponseId == answer.ResponseId));
                }
            }
        }

        public Response PrepareNewResponse(int examId)
        {
            // TODO: Use IF
            var response = new Response { ExamId = examId, UserId = "a@a.a", Exam = FindExam(examId) };
            response.Answers = CreateAndEvaluateAnswers(response.Exam.Questions);

            return response;
        }

        public Exam FindExam(int examId)
        {
            return _db.Exams.Find(examId);
        }

        public void PopulateResponseModel(Response response)
        {
            response.Date = DateTime.Now;
            response.Exam = _db.Exams.Find(response.ExamId);
            response.User = _db.Users.Find(response.UserId);

            foreach (var answer in response.Answers)
            {
                answer.Question = _db.Questions.Find(answer.QuestionId);
            }
        }

        public void SaveResponse(Response response)
        {
            _db.Responses.Add(response);
            _db.Entry(response).State = EntityState.Added;
            _db.SaveChanges();
        }

        public void DeleteResponse(int id)
        {
            var response = FindResponse(id);
            _db.Answers.RemoveRange(response.Answers);
            _db.Responses.Remove(response);
            _db.SaveChanges();
        }

        public void DisposeDb()
        {
            _db.Dispose();
        }

        public List<Response> GetAllResponses()
        {
            var responses = _db.Responses.Include(r => r.Exam).Include(r => r.User).ToList();
            foreach (var response in responses)
                foreach (var answer in response.Answers.ToArray())
                {
                    var multipleAnswer = answer as MultipleSelectionAnswer;
                    if (multipleAnswer != null)
                    {
                        response.Answers.Remove(answer);
                        response.Answers.Add(_db.MultipleSelectionAnswers
                            .Include(a => a.Selections)
                            .SingleOrDefault(e => e.QuestionId == answer.QuestionId && e.ResponseId == answer.ResponseId));
                    }
                }

            return responses;
        }

        private List<Answer> CreateAndEvaluateAnswers(ICollection<Question> questions)
        {
            var answers = new List<Answer>();
            foreach (var question in questions)
            {
                if (question is SingleSelectionQuestion)
                    answers.Add(new SingleSelectionAnswer { Question = question as SingleSelectionQuestion, QuestionId = question.Id });
                else if (question is MultipleSelectionQuestion)
                    answers.Add(new MultipleSelectionAnswer(question as MultipleSelectionQuestion));
            }

            var evaluator = new RandomValueEvaluator();
            foreach (var answer in answers)
            {
                if (answer is SelectionAnswer)
                {
                    var question = _db.SelectionQuestions.Find(answer.QuestionId);
                    question.Options = question.Options.ToList().Shuffle().ToList();
                    answer.Question = evaluator.Evaluate(question);
                }
            }

            return answers;
        }
    }
}