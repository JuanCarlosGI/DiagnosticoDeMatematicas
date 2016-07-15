namespace DiagnosticoDeMatematicas.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using DAL;
    using Helpers;

    public class HomeController : Controller
    {
        private SiteContext db = new SiteContext();

        public ActionResult Index()
        {
            return View(db.Exams.Where(m => m.Active == true).ToList());
        }

        public ActionResult SignIn(string email, string password)
        {
            if (!SessionValidator.IsSignedIn && !SessionManager.TrySignIn(email, password))
            {
                return View();
            }

            return RedirectToAction("Index");
        }
        
        public ActionResult SignOut()
        {
            SessionManager.SignOut();
            return RedirectToAction("Index");
        }

        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}