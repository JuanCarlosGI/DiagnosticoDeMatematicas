namespace DiagnosticoDeMatematicas.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using DAL;
    using Helpers;
    using Models.ViewModels;

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

            if (details.StartDate != null && details.EndDate != null && details.StartDate.Value > details.EndDate.Value)
            {
                ModelState.AddModelError("EndDate", "La fecha de terminación debe ser igual o mayor a la fecha de inicio.");
            }
            else
            {
                if (!details.ExamID.HasValue)
                {
                    return RedirectToAction("GlobalStatistics", "Statistics", details);
                }

                return RedirectToAction("Statistics", "Statistics", details);
            }

            details.ExamID = 0;
            ViewBag.ExamID = new SelectList(db.Exams, "ID", "Name");
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
                Responses = db.Responses.ToList(),
                Exam = db.Exams.Find(details.ExamID.Value),
                StartDate = details.StartDate,
                EndDate = details.EndDate
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

            var model = new GlobalStatisticsViewModel
            {
                Responses = db.Responses.ToList(),
                StartDate = details.StartDate,
                EndDate = details.EndDate
            };

            return View(model);
        }
    }
}