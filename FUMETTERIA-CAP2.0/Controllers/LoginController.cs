using FUMETTERIA_CAP2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FUMETTERIA_CAP2._0.Controllers
{
    public class LoginController : Controller
    {
       
        private Model1 db = new Model1();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User u)
        {
            // Cerca l'utente nel db in base all'username 
            User user = db.User.FirstOrDefault(x => x.username == u.username);
            // Se l'utente esiste, verifica la password
            if (user.username != null)
            {
                if (user.password == u.password)
                {  // Carica i preferiti dell'utente dal db.
                    user.Preferiti = db.preferito.Where(p => p.IDpreferito == user.IDutente).Select(p => p.Manga).ToList();
                    //  cookie di autenticazione per l'utente
                    FormsAuthentication.SetAuthCookie(u.username, false);
                    if (user.Role == "admin")
                    {
                        return RedirectToAction("AdminHome","Home");
                    }
                    else { return RedirectToAction("UserHome", "Home"); }


                }
                else
                {
                    return View();
                }

            }
            return View();
        }



        public ActionResult Logout()
        {
            // logout dell'utente, rimuove il cookie di autenticazione e il carrello dalla sessione.
            FormsAuthentication.SignOut();
            Session.Remove("Carrello");

            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Registrazione()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Registrazione([Bind(Exclude = "Role")] User u)
        {
            // Cerca se l'utente esiste nel db in base all'username
            User user = db.User.FirstOrDefault(y => y.username == u.username);
            //se non esiste gli assegna di default il ruolo di user e lo salva nel db
            if (user == null)
            {
                u.Role = "user";
                db.User.Add(u);
                db.SaveChanges();
            }
            return RedirectToAction("Login", "Login");
        }
    }
}