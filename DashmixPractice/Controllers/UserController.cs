using DashmixPractice.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DashmixPractice.Controllers
{
    public class UserController : Controller
    {
        public static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        //this function Convert to Decord your Password
        public string DecodeFrom64(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }

        // GET: User
        ScanMeDBContext _context = new ScanMeDBContext();

        public ActionResult SignIn()
        {
            if (Request.Cookies["Username"] != null && Request.Cookies["Password"] != null)
            {
                string username = Request.Cookies["Username"].Value.ToString();
                string password = Request.Cookies["Password"].Value.ToString();
                string decryptedPassword = DecodeFrom64(password);
                var user = _context.User.Where(model => model.Username == username && model.Password == decryptedPassword).FirstOrDefault();
                if (user != null)
                {
                    Session["Username"] = user.Username.ToString();
                    Session["ProfilePicture"] = user.ProfilePicturePath.ToString();
                    Session["Password"] = user.Password.ToString();
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(User u)
        {
            if (u.Username != null && u.Password != null)
            {
                var user = _context.User.Where(model => model.Username == u.Username && model.Password == u.Password).FirstOrDefault();
                if (user != null)
                {
                    if (u.RememberMe)
                    {
                        string encrypted_password = EncodePasswordToBase64(u.Password);
                        Response.Cookies["Username"].Value = u.Username;
                        Response.Cookies["Password"].Value = encrypted_password;

                        Response.Cookies["Username"].Expires = DateTime.Now.AddDays(30);
                        Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
                    }
                    else
                    {
                        Response.Cookies["Username"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
                    }
                    Session["Username"] = user.Username.ToString();
                    Session["ProfilePicture"] = user.ProfilePicturePath.ToString();
                    Session["Password"] = user.Password.ToString();
                    return Json(true);
                }
            }
            return Json(false);
        }

        [HttpPost]
        public ActionResult SignUp(User u)
        {
            if (ModelState.IsValid)
            {
                _context.User.Add(u);
                int i = _context.SaveChanges();
                if (i > 0)
                {
                    Session["Username"] = u.Username.ToString();
                    Session["ProfilePicture"] = u.ProfilePicturePath.ToString();
                    Session["Password"] = u.Password.ToString();
                    return Json(true);
                }
            }
            return View("SignIn");
        }

        [HttpPost]
        public ActionResult ForgetPassword(string credentials)
        {
            return Json(true);
        }

        public ActionResult SignOut()
        {
            if (Request.Cookies["Username"] != null && Request.Cookies["Password"] != null)
            {
                Response.Cookies["Username"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
            }
            Session.Abandon();
            return RedirectToAction("SignIn");
        }

        [HttpPost]
        public ActionResult UpdatePassword(User u)
        {
            if (Session["Username"] != null && u.Password != null)
            {
                string username;
                username = Session["Username"].ToString();

                var user = _context.User.Where(model => model.Username == username && model.Password == u.Password).FirstOrDefault();
                if (user != null)
                {
                    user.Password = u.ConfirmPassword;
                    user.ConfirmPassword = u.ConfirmPassword;

                    int r = _context.SaveChanges();
                    if (r > 0)
                    {
                        if (Request.Cookies["Username"] != null && Request.Cookies["Password"] != null)
                        {
                            Response.Cookies["Username"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
                        }
                        Session.Abandon();
                        return Json("Updated Successfully");
                    }
                }
                else
                {
                    return Json("Incorrect Password");
                }
            }
            return Json(false);
        }

        [HttpPost]
        public ActionResult UpdateProfile(HttpPostedFileBase ProfilePicture, User u)
        {
            if (Session["Username"] != null && Session["Password"] != null)
            {
                string password, username, profilePicturePath;
                username = Session["Username"].ToString();
                password = Session["Password"].ToString();

                var user = _context.User.Where(model => model.Username == username && model.Password == password).FirstOrDefault();
                if (user != null)
                {
                    user.Name = u.Name;
                    user.Email = u.Email;
                    user.ConfirmPassword = user.Password;
                    profilePicturePath = u.ProfilePicturePath;

                    if (ProfilePicture != null && ProfilePicture.ContentLength > 0)
                    {
                        string fileName = Path.GetFileName(ProfilePicture.FileName);
                        string filePath = Path.Combine(Server.MapPath("~/Images/Profile Pictures"), fileName);
                        ProfilePicture.SaveAs(filePath);
                        profilePicturePath = "/Images/Profile Pictures/" + fileName;
                    }

                    user.ProfilePicturePath = profilePicturePath;

                    int r = _context.SaveChanges();
                    if (r > 0)
                    {
                        Session["ProfilePicture"] = user.ProfilePicturePath;
                        return Json("Updated Successfully");

                    }
                }
            }
            return Json(false);
        }
    }
}