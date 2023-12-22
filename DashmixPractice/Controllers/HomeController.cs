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
                int userId = Convert.ToInt32(Session["UserId"]);
                List<Social_Connections> socialConnectionsList = _context.Social_Connections.Where(model => model.User_Id == userId).ToList();

                var groupedByPlatform = socialConnectionsList
                            .GroupBy(connection => connection.Platform)
                            .ToList();

                return View(groupedByPlatform);
            }
            return RedirectToAction("Home");
        }

        [HttpPost]
        public ActionResult CreateSocialConnection(Social_Connections newCon)
        {
            var user = _context.User.Where(model => model.Id == newCon.User_Id).FirstOrDefault();
            newCon.User = user;
            _context.Social_Connections.Add(newCon);
            int r = _context.SaveChanges();
            if (r > 0)
            {
                return Json(true);
            }
            return Json(false);
        }

        [HttpPost]
        public ActionResult RetriveSocialConnections(int User_Id)
        {
            List<Social_Connections> socialConnectionsList = _context.Social_Connections.Where(model => model.User_Id == User_Id).ToList();

            if (socialConnectionsList != null)
            {
                var groupedByPlatform = socialConnectionsList
                        .GroupBy(connection => connection.Platform)
                        .ToList();
                return PartialView("_SocialConnectionsList", groupedByPlatform);
            }
            return Json(false);
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