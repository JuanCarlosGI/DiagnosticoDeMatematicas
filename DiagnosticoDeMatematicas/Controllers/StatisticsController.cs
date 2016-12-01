namespace DiagnosticoDeMatematicas.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using DAL;
    using Helpers;
    using Models.ViewModels;
    using System;
    public class StatisticsController : Controller
    {
        private SiteContext db = new SiteContext();

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

            ViewBag.ExamID = new SelectList(db.Exams, "ID", "Name", string.Empty);
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
                if (!details.ExamID.HasValue)
                {
                    return RedirectToAction("GlobalStatistics", "Statistics", details);
                }

                return RedirectToAction("Statistics", "Statistics", details);
            }

            ViewBag.ExamID = new SelectList(db.Exams, "ID", "Name", string.Empty);
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
                ExamAnalyzer = new ExamAnalyzer(db.Exams.Find(details.ExamID), details.StartDate, details.EndDate)
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

            var model = new GlobalStatisticsViewModel(db.Exams.ToList(), details.StartDate, details.EndDate);

            return View(model);
        }
    }
}