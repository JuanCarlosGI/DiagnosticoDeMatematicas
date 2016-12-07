using System;
using System.Linq;
using System.Web.Mvc;
using DiagnosticoDeMatematicas.DAL;
using DiagnosticoDeMatematicas.Helpers;
using DiagnosticoDeMatematicas.Models.ViewModels;

namespace DiagnosticoDeMatematicas.Controllers
{
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

            var statistics = new StatisticsViewModel
            {
                ExamAnalyzer = new ExamAnalyzer(_db.Exams.Find(details.ExamId), details.StartDate, details.EndDate)
            };

            return View(statistics);
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

            var model = new GlobalStatisticsViewModel(_db.Exams.ToList(), details.StartDate, details.EndDate);

            return View(model);
        }
    }
}