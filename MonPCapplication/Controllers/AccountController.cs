using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MonPCapplication.Models;
namespace MonPCapplication.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            AccountLogin AL = new AccountLogin();
            AccountLogin.est_connecté = 0;
            return View(AL);
        }

        [HttpPost]
        public ActionResult Login(AccountLogin account)
        {
            AccountLogin.est_connecté = 0;
            MonPCEntities model = new MonPCEntities();
            var password = account.password;
            var username = account.username;

            var acc = model.CLIENTs.Where(o => o.username == username && o.password == password).FirstOrDefault();
            if (acc != null)
            {
                int timeout = account.RememberMe ? 525600 : 20; // 525600 min = 1 year
                var ticket = new FormsAuthenticationTicket(account.username, account.RememberMe, timeout);
                string encrypted = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                cookie.Expires = DateTime.Now.AddMinutes(timeout);
                cookie.HttpOnly = true;
                Response.Cookies.Add(cookie);
                AccountLogin.est_connecté = 1;
                AccountLogin.id_connecté = acc.idClient;
                return RedirectToAction("Index", "Home");
            }
            else
            {

                ADMINISTRATEUR z = model.ADMINISTRATEURs.Where(a => a.username == account.username && a.password == account.password).FirstOrDefault();
                if (z != null)
                {
                    AccountLogin.est_connecté = 1;
                    AccountLogin.est_admin= 1;
                    AccountLogin.id_connecté = z.id;
                    return RedirectToAction("Index", "Admin");
                }
            }
            ViewBag.Message = "Password ou username est incorrecte!";
            return Login(account);
        }




        [NonAction]
        public bool DoesUsernameExist(string usrname)
        {
            using (MonPCEntities model = new MonPCEntities())
            {
                var v = model.CLIENTs.Where(a => a.username == usrname).FirstOrDefault();
                return v != null;
            }
        }

        public ActionResult Registration()
        {
            ClientRegistration cR = new ClientRegistration();
            return View(cR);
        }


        //Regestration post action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(ClientRegistration Clr)
        {
            //Username does exist

            var isExist = DoesUsernameExist(Clr.username);
            if (isExist)
            {
                ModelState.AddModelError("EmailExist", "Email already exist");
                return View(Clr);
            }
            //Save to database 
            using (MonPCEntities model = new MonPCEntities())
            {
                CLIENT clt = new CLIENT();
                clt.username = Clr.username;
                clt.prenom = Clr.prenom;
                clt.nom = Clr.nom;
                clt.mail = Clr.mail;
                clt.password = Clr.password;
                clt.telephone = Clr.telephone;
                clt.Budget = Clr.Budget;

                model.CLIENTs.Add(clt);
                model.SaveChanges();

            }
                return RedirectToAction("Login", "Account");

        }
    }
}