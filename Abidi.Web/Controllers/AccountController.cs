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
        private ILoginRepository loginRepository;

        AbidiContext db = new AbidiContext();

        public AccountController()
        {
            loginRepository = new LoginRepository(db);
        }
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
                string MyHash = FormsAuthentication.HashPasswordForStoringInConfigFile(login.NationalCode, "MD5");

                var person = db.People.FirstOrDefault(u => u.PersonalCode == login.PersonalCode && u.NationalCode == MyHash);

                if (loginRepository.IsExistUser(login.PersonalCode, MyHash))
                {
                    FormsAuthentication.SetAuthCookie(login.PersonalCode,true);
                    return Redirect("/Admin/Dashboard/Index");
                }
                else
                {
                    ModelState.AddModelError("PersonalCode", "کاربری یافت نشد");
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