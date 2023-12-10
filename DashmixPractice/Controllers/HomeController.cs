using DashmixPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DashmixPractice.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        ScanMeDBContext _context = new ScanMeDBContext();
        public ActionResult Index()
        {
            if (Session["Username"] != null && Session["Password"] != null)
            {
                string username = Session["Username"].ToString();
                string password = Session["Password"].ToString();
                var user = _context.User.Where(model => model.Username == username && model.Password == password).FirstOrDefault();

                return View(user);
            }
            return RedirectToAction("Home");
        }

        public ActionResult Home()
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        public ActionResult SocialMediaLinks()
        {
            if (Session["Username"] != null && Session["Password"] != null)
            {
                return View();
            }
            return RedirectToAction("Home");
        }

        public ActionResult Settings()
        {
            if (Session["Username"] != null && Session["Password"] != null)
            {
                string username = Session["Username"].ToString();
                string password = Session["Password"].ToString();
                var user = _context.User.Where(model => model.Username == username && model.Password == password).FirstOrDefault();

                return View(user);
            }
            return RedirectToAction("Home");
        }

    }
}