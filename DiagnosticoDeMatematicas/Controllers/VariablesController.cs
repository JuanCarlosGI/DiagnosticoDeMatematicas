using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiagnosticoDeMatematicas.DAL;
using DiagnosticoDeMatematicas.Models;

namespace DiagnosticoDeMatematicas.Controllers
{
    public class VariablesController : Controller
    {
        private readonly SiteContext _db = new SiteContext();

        public PartialViewResult Create(int questionId)
        {
            var variable = new Variable
            {
                QuestionId = questionId
            };

            return PartialView("_Create", variable);
        }

        [HttpPost]
        public PartialViewResult Create([Bind(Include = "QuestionId,Symbol")]Variable variable)
        {
            if (ModelState.IsValid)
            {
                _db.Variables.Add(variable);
                _db.Entry(variable).State = EntityState.Added;
                _db.SaveChanges();

                return PartialView("_DetailsNew", variable);
            }

            return PartialView("_Create", variable);
        }

        public PartialViewResult Details(Variable variable)
        {
            return PartialView("_Details", variable);
        }

        [HttpPost]
        public PartialViewResult Delete(int questionId, string symbol)
        {
            var variable = _db.Variables.Find(symbol,questionId);
            _db.Variables.Remove(variable);
            _db.SaveChanges();
            return null;
        }
    }
}