namespace DiagnosticoDeMatematicas.Controllers
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;
    using DAL;
    using Helpers;
    using Models;
    using Models.ViewModels;

    public class StatisticsController : Controller
    {
        private readonly SiteContext _db = new SiteContext();

        // GET: Statistics
        public ActionResult Index()
        {
            return RedirectToAction("StatisticDetails");
        }

        public ActionResult StatisticDetails()
        {
            if (!SessionValidator.IsAdminSignedIn)
            {
                if (SessionValidator.IsSignedIn)
                {
                    return RedirectToAction("AccessDenied", "Home");
                }

                return RedirectToAction("SignIn", "Home");
            }

            ViewBag.ExamID = new SelectList(_db.Exams, "ID", "Name", string.Empty);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StatisticDetails([Bind(Include = "ExamID,StartDate,EndDate")]StatisticDetailsViewModel details)
        {
            if (!SessionValidator.IsAdminSignedIn)
            {
                if (SessionValidator.IsSignedIn)
                {
                    return RedirectToAction("AccessDenied", "Home");
                }

                return RedirectToAction("SignIn", "Home");
            }

            if (details.EndDate == null && details.StartDate != null)
            {
                details.EndDate = DateTime.Today;
                if (details.EndDate >= details.StartDate)
                {
                    ModelState["EndDate"].Errors.Clear();
                }
            }

            if (ModelState.IsValid)
            {
                if (!details.ExamId.HasValue)
                {
                    return RedirectToAction("GlobalStatistics", "Statistics", details);
                }

                return RedirectToAction("Statistics", "Statistics", details);
            }

            ViewBag.ExamID = new SelectList(_db.Exams, "ID", "Name", string.Empty);
            return View(details);
        }

        public ActionResult Statistics(StatisticDetailsViewModel details)
        {
            if (!SessionValidator.IsAdminSignedIn)
            {
                if (SessionValidator.IsSignedIn)
                {
                    return RedirectToAction("AccessDenied", "Home");
                }

                return RedirectToAction("SignIn", "Home");
            }

            var exam = _db.Exams.Find(details.ExamId);
            var responses = exam.Responses.ToList();
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
            exam.Responses = responses;

            var statistics = new StatisticsViewModel
            {
                ExamAnalyzer = new ExamAnalyzer(exam, details.StartDate, details.EndDate)
            };

            return View(statistics);
        }
        
        public PartialViewResult OptionStatistics(int optionId)
        {
            var option =
                _db.QuestionOptions.Include(o => o.BinaryOptionSelections)
                    .Include(o => o.SingleSelectionAnswers)
                    .Include(o => o.Question.Answers)
                    .SingleOrDefault(o => o.Id == optionId);

            if (option == null)
            {
                return null;
            }

            double percentage;
            if (option.BinaryOptionSelections.Count != 0)
            {
                percentage = (double)option.BinaryOptionSelections.Count(s => s.Selected)/option.BinaryOptionSelections.Count * 100;
            }
            else if (option.SingleSelectionAnswers.Count != 0)
            {
                var amountOfResponses =
                    _db.SingleSelectionAnswers.Count(a => a.QuestionId == option.QuestionId);
                percentage = (double)option.SingleSelectionAnswers.Count/amountOfResponses * 100;
            }
            else
            {
                percentage = 0;
            }

            var model = new OptionStatisticsViewModel
            {
                Description = option.Description.Replace("|", "").Replace("%", ""),
                IsCorrect = option.IsCorrect,
                Percentage = percentage
            };

            return PartialView("_OptionStatistics", model);
        }

        public ActionResult GlobalStatistics(StatisticDetailsViewModel details)
        {
            if (!SessionValidator.IsAdminSignedIn)
            {
                if (SessionValidator.IsSignedIn)
                {
                    return RedirectToAction("AccessDenied", "Home");
                }

                return RedirectToAction("SignIn", "Home");
            }

            var exams = _db.Exams.ToList();
            foreach (var exam in exams)
            {
                var responses = exam.Responses.ToList();
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
                exam.Responses = responses;
            }
            
            var model = new GlobalStatisticsViewModel(exams, details.StartDate, details.EndDate);

            return View(model);
        }
    }
}