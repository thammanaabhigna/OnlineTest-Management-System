using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using OnlineTest.Models;
using System.Web.Security;

namespace OnlineTest.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult login(Admin admin)
        {
            using (var context = new OnlineTestDBEntities())
            {
                bool isvalid = context.Admins.Any(x => x.Admin_Name == admin.Admin_Name && x.Password == admin.Password);
                if (isvalid)
                {
                    FormsAuthentication.SetAuthCookie(admin.Admin_Name, false);

                    return RedirectToAction("Index", "Tests");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Username or Password");
                    return View();
                }

            }
        }


        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login");
        }

    }
}