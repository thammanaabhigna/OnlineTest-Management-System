using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTest.Models;

namespace OnlineTest.Controllers
{
    public class HomeController : Controller
    {
        private OnlineTestDBEntities db = new OnlineTestDBEntities(); //instance creation

        //**************************************** Index ************************************

        public ActionResult Index()
        {
            return View();
        }

        //**************************************** User Registration ****************************

        public ActionResult Register()   //Registration Of new User to the Website
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserTable usr)
        {
            if (ModelState.IsValid)
            {
                db.UserTables.Add(usr); //Adding User
                db.SaveChanges(); //Saving Changes
                ViewBag.SuccessMessage = "Registration Succesful"; //Displaying Message after Registration
            }
            return RedirectToAction("Login");
        }

        //****************************************  User Login ***************************************

        public ActionResult Login()    //Login For user for Entering in Website for Test
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserTable usr)
        {
            if (ModelState.IsValid)
            {
                //****Login logic*****

                var details = (from userlist in db.UserTables
                               where userlist.User_Name == usr.User_Name && userlist.User_Password == usr.User_Password
                               select new
                               {
                                   userlist.User_Id,
                                   userlist.User_Name
                               }).ToList();
                if (details.FirstOrDefault() != null)
                {
                    Session["User_Id"] = details.FirstOrDefault().User_Id;
                    Session["User_Name"] = details.FirstOrDefault().User_Name;
                    return RedirectToAction("Courses"); //if login successful, then redirect to Courses Page
                }
                else
                {
                    ViewBag.message = "Invalid Credentials"; //Error Message
                }
            }
            return View(usr);
        }

        //**************************************** Welcome **************************************
        public ActionResult Welcome()
        {
            return View();
        }

        //**************************************** Courses **************************************
        public ActionResult Courses()   //It will Display all courses Available in the Database
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Courses(UserTable usr)
        {
            return RedirectToAction("Instructions"); //Redirecting to Instructions Page
        }

        //**************************************** User Instructions **************************************
        public ActionResult Instructions()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Instructions(Question qustn)
        {
            return RedirectToAction("CSharp", "Question");
        }

        //**************************************** About Page **************************************
        public ActionResult About()
        {
            ViewBag.Message = "ABOUT US.";

            return View();
        }

        //**************************************** Contact Page**************************************
        public ActionResult Contact()
        {
            ViewBag.Message = "CONTACT US.";

            return View();
        }
    }
}