using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using DiagnosticoDeMatematicas.DAL;
using DiagnosticoDeMatematicas.Helpers;
using DiagnosticoDeMatematicas.Models;
using DiagnosticoDeMatematicas.Models.ViewModels;
using DiagnosticoDeMatematicas.Services;

namespace DiagnosticoDeMatematicas.Controllers
{
    public class UsersController : Controller
    {
        private readonly SiteContext _db = new SiteContext();
        private readonly UsersService _service;

        public UsersController()
        {
            _service = new UsersService(_db);
        }

        // GET: Users
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

            return View(_db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!SessionValidator.IsSignedIn)
            {
                return RedirectToAction("SignIn", "Home");
            }

            User user = _db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            if (!SessionValidator.IsAdminSignedIn &&
                user.Email != SessionService.User.Email)
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            var responses = user.Responses.Where(r => r.Exam.Active).ToList();
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
            user.Responses = responses;

            return View(new UserDetailsViewModel(user, _db.Exams.Where(e => e.Active)) {ExamGrades = _service.ExamGrades(user.Email) });
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            var user = new User { Role = Role.Usuario, DateOfBirth = DateTime.Now };
            return View(user);
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Email,Role,FirstName,LastName,Password,DateOfBirth,Gender,Interest,Facility,Liking")] User user)
        {
            if (ModelState.IsValid)
            {
                HashAlgorithm hashAlgo = new SHA256Managed();
                byte[] plainTextBytes = Encoding.Unicode.GetBytes(user.Password);
                byte[] hash = hashAlgo.ComputeHash(plainTextBytes);
                user.Password = Encoding.Unicode.GetString(hash);
                _db.Users.Add(user);
                _db.SaveChanges();
                return RedirectToAction("SignIn", "Home");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!SessionValidator.IsSignedIn)
            {
                return RedirectToAction("SignIn", "Home");
            }

            User user = _db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            if (!SessionValidator.IsAdminSignedIn &&
                user.Email != SessionService.User.Email)
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Email,Role,FirstName,LastName,Password,DateOfBirth,Gender,Interest,Facility,Liking")] User user)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(user).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!SessionValidator.IsAdminSignedIn)
            {
                if (SessionValidator.IsSignedIn)
                {
                    return RedirectToAction("AccessDenied", "Home");
                }

                return RedirectToAction("SignIn", "Home");
            }

            User user = _db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            User user = _db.Users.Find(id);
            _db.Users.Remove(user);
            _db.SaveChanges();
            return RedirectToAction("Index");
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
