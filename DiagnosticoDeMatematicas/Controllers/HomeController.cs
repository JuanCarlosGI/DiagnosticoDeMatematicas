using DiagnosticoDeMatematicas.DAL;
using DiagnosticoDeMatematicas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.DataVisualization.Charting;

namespace DiagnosticoDeMatematicas.Controllers
{
    public class HomeController : Controller
    {
        private SiteContext db = new SiteContext();

        public ActionResult Index()
        {
            return View(db.Exams.Where(m => m.Active == true).ToList());
        }

        public ActionResult SignIn(string Email, string Password)
        {
            if (Session.Contents["Email"] == null)
            {
                if (Email != null && Password != null)
                {
                    var user = db.Users.Find(Email);
                    if (user != null) 
                    {
                        Session.Contents["Email"] = user.Email;
                        Session.Contents["FullName"] = user.FullName;
                        Session.Contents["Role"] = user.Role;
                        Session.Timeout = 30;
                        return RedirectToAction("Index");
                    }

                }
                
                return View();
            }

            return RedirectToAction("Index");
        }

        public ActionResult SignOut()
        {
            Session.RemoveAll();
            return RedirectToAction("Index");
        }

        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}