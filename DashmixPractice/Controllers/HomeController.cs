using DashmixPractice.Models;
using DashmixPractice.ViewModels;
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

        public ActionResult SocialConnections()
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
                var contactInfo = _context.Contact_Information.Where(model => model.User_Id == user.Id).FirstOrDefault();

                UserContactInformationViewModel viewModel = new UserContactInformationViewModel
                {
                    User = user,
                    ContactInforamation = contactInfo
                };

                return View(viewModel);
            }
            return RedirectToAction("Home");
        }

    }
}