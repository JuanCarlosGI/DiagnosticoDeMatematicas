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
using DiagnosticoDeMatematicas.Models.ViewModels.Users;
using DiagnosticoDeMatematicas.Services;

namespace DiagnosticoDeMatematicas.Controllers
{
    public class UsersController : Controller
    {
        private readonly SiteContext _db;
        private readonly UsersService _service;

        public UsersController()
        {
            _db = new SiteContext();
            _service = new UsersService(_db);
        }

        public UsersController(UsersService service)
        {
            _service = service;
        }

        // GET: Users
        public ActionResult Index()
        {
            var model = _service.GetUsersWithRoles();
            return View(model);
        }

        // GET: Users/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = _service.GetUser(id);
            if (user == null)
            {
                return HttpNotFound();
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
            var model = new CreateUserViewModel { DateOfBirth = DateTime.Now };
            return View(model);
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Email,FirstName,LastName,Password,DateOfBirth,Gender,Interest,Facility,Liking,UserName,RepeatPassword")] CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _service.AddUser(model);

                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn", "Home");
                }
                
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error);
            }

            return View(model);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = _service.GetUser(id);
            if (user == null)
            {
                return HttpNotFound();
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

            User user = _service.GetUser(id);
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
