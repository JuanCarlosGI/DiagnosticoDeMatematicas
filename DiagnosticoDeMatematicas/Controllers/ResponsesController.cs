using System.Net;
using System.Web.Mvc;
using DiagnosticoDeMatematicas.Helpers;
using DiagnosticoDeMatematicas.Models;
using DiagnosticoDeMatematicas.Services.ResponsesService;

namespace DiagnosticoDeMatematicas.Controllers
{
    public class ResponsesController : Controller
    {
        private readonly IResponsesService _service;

        public ResponsesController()
        {
            _service = new ResponsesService(new DAL.SiteContext());
        }

        public ResponsesController(IResponsesService service)
        {
            _service = service;
        }

        // GET: Responses
        public ActionResult Index()
        {
            if (!SessionValidator.IsAdminSignedIn)
            {
                if (SessionValidator.IsSignedIn)
                {
                    return RedirectToAction("AccessDenied", "Home");
                }

                return RedirectToAction("SignIn", "Home");
            }

            var responses = _service.GetAllResponses();
            
            return View(responses);
        }

        // GET: Responses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!SessionValidator.IsSignedIn)
            {
                return RedirectToAction("SignIn", "Home");
            }

            Response response = _service.FindResponse(id.Value);
            if (response == null)
            {
                return HttpNotFound();
            }

            _service.LoadMultipleSelectionAnswers(response.Answers);

            if (!SessionValidator.IsAdminSignedIn &&
                response.User.Email != SessionService.User.Email)
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            return View(response);
        }
        
        // GET: Responses/Create
        public ActionResult Create(int? examId)
        {
            if (!SessionValidator.IsSignedIn)
            {
                return RedirectToAction("SignIn", "Home");
            }

            if (examId == null || _service.FindExam(examId.Value) == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var response = _service.PrepareNewResponse(examId.Value);

            return View(response);
        }

        // POST: Responses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,ExamId,Answers")]Response response)
        {
            _service.PopulateResponseModel(response);

            if (ModelState.IsValid)
            {
                _service.SaveResponse(response);

                return RedirectToAction("ThankYou");
            }
            
            return View(response);
        }

        public ActionResult ThankYou()
        {
            return View();
        }

        // GET: Responses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!SessionValidator.IsSignedIn)
            {
                return RedirectToAction("SignIn", "Home");
            }

            var response = _service.FindResponse(id.Value);

            if (response == null)
            {
                return HttpNotFound();
            }

            if (!SessionValidator.IsAdminSignedIn &&
                response.User.Email != SessionService.User.Email)
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            return View(response);
        }

        // POST: Responses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _service.DeleteResponse(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _service.DisposeDb();
            }

            base.Dispose(disposing);
        }
    }
}
