using System.Web.Mvc;
using DiagnosticoDeMatematicas.DAL;
using DiagnosticoDeMatematicas.Helpers.IEvaluator;
using System.Data.Entity;
using System.Linq;

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

        public ActionResult TestCombinations(int questionId)
        {
            var question = _db.Questions.Include(q => q.Variables).Single(q => q.Id == questionId);

            var combinations = SpectrumEvaluator.Evaluate(question, question.Variables.ToList());

            combinations.Insert(0, new NotationlessEvaluator().Evaluate(question));

            return View(combinations);
        }
    }
}
