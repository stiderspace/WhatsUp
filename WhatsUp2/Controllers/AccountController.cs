using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WhatsUp2.Models;
using WhatsUp2.Repository;
using WhatsUp2.Controllers;
using System.Web.Security;

namespace WhatsUp2.Controllers
{
    public class AccountController : Controller
    {
        private IAccountRepository accountRepository = new AccountRepository();

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // get account with given credentials
                Account account = accountRepository.GetAccount(model.EmailAddress, model.Password);
                if (account != null)
                {
                    FormsAuthentication.SetAuthCookie(account.EmailAddress, false);

                    // remember complete account
                    Session["loggedin_account"] = account;

                    // redirect to default entry of ContactController
                    return RedirectToAction("Index", "Contacts");
                }
                else
                {
                    ModelState.AddModelError("login-error", "The user name or password provided is incorrect.");
                }
            }
            // there was an error, go back to login page
            return View(model);
        }

        [HttpPost]
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            // redirect to login of account controller
            Session["loggedin_account"] = null;
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegistreerModel model)
        {
            if (ModelState.IsValid)
            {
                bool isvalid = false;

                isvalid = accountRepository.CreateAccount(model);
                if (isvalid)
                    return RedirectToAction("index", "home");
                else
                    ModelState.AddModelError("ExistError", "Email address already exists");
            }
            return View(model);
        }
    }
}