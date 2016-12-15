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
    public class RangesController : Controller
    {
        private readonly SiteContext _db = new SiteContext();

        public PartialViewResult Create(int questionId, string symbol)
        {
            var range = new Range
            {
                QuestionId = questionId,
                Symbol = symbol
            };

            return PartialView("_Create", range);
        }

        [HttpPost]
        public PartialViewResult Create([Bind(Include = "Id,QuestionId,Symbol,Maximum,Minimum")]Range range)
        {
            if (ModelState.IsValid)
            {
                _db.Ranges.Add(range);
                _db.Entry(range).State = EntityState.Added;
                _db.SaveChanges();

                return PartialView("_DetailsNew", range);
            }

            return PartialView("_Create", range);
        }

        public PartialViewResult Details(Range range)
        {
            return PartialView("_Details", range);
        }

        [HttpPost]
        public PartialViewResult Delete(int id)
        {
            var range = _db.Ranges.Find(id);
            _db.Ranges.Remove(range);
            _db.SaveChanges();
            return null; ;
        }
    }
}