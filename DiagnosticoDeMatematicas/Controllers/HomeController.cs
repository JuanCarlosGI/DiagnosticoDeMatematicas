namespace DiagnosticoDeMatematicas.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using DAL;
    using Helpers;

    public class HomeController : Controller
    {
        private readonly SiteContext _db = new SiteContext();

        public ActionResult Index()
        {
            return View(_db.Exams.Where(m => m.Active).ToList());
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