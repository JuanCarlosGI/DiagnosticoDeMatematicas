using System.Web.Mvc;
using DiagnosticoDeMatematicas.DAL;

namespace DiagnosticoDeMatematicas.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly SiteContext _db = new SiteContext();

        public PartialViewResult CreateNew(int examId)
        {
            return PartialView("CreateNew", examId);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
