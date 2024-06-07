using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Abidi.DataLayer.Context;
using Abidi.DataLayer.Repositories;
using Abidi.DataLayer.Services;
using Abidi.DataLayer.ViewModels;

namespace Abidi.Web.Controllers
{
    public class AccountController : Controller
    {
        private UnitOfWork db = new UnitOfWork();
        // GET: Account

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Obsolete]
        public ActionResult Login(LoginViewModel login/*, string ReturnUrl = "/"*/)
        {
            if (ModelState.IsValid)
            {
                string MyHash = FormsAuthentication.HashPasswordForStoringInConfigFile(login.Password, "MD5");

                if (db.UserRepository.IsExistUser(login.Username, MyHash))
                {
                    FormsAuthentication.SetAuthCookie(login.Username,true);
                    return Redirect("/Admin/Dashboard/Index");
                }
                else
                {
                    ModelState.AddModelError("UserName", "کاربری یافت نشد");
                }
            }
            return View(login);
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Account/login");
        }

    }
}