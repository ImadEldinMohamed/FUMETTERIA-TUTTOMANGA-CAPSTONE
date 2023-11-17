using FUMETTERIA_CAP2._0.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FUMETTERIA_CAP2._0.Controllers
{

    public class RecensioneController : Controller
    {

        private Model1 db = new Model1();

        [Authorize(Roles = "admin,user")]
        // GET: Recensione
        public ActionResult Index()
        {
            //lista delle recensioni 
            return View(db.Recensione.ToList());
        }
        [Authorize(Roles = "user")]
        public ActionResult CreaRecensione()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreaRecensione(Recensione recensione)
        {
            if (ModelState.IsValid)
            {//si identifica l'utente e si crea la recensione che viene poi salvata nel db.
               
                string username = User.Identity.Name;
                User user = db.User.FirstOrDefault(u => u.username == username);

                if (user != null)
                {
                    recensione.IDuser = user.IDutente;
                   

                    db.Recensione.Add(recensione);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(recensione);
        }
    }
}