namespace DiagnosticoDeMatematicas.Controllers
{
    using System.Web.Mvc;
    using DAL;

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
