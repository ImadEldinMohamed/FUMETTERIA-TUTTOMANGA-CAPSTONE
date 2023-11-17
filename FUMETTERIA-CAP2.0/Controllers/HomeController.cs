using FUMETTERIA_CAP2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FUMETTERIA_CAP2._0.Controllers
{

    public class HomeController : Controller
    {
        private Model1 db = new Model1();
        [Authorize(Roles = "admin,user")]
        public ActionResult Index()
        {
            //lista dei manga disponibili 
            return View(db.Manga.ToList());
        }
        [Authorize(Roles = "admin,user")]
        public ActionResult Index2()
        {
            //lista dei personaggi popolari
            return View(db.Popolare.ToList());
        }

        [Authorize(Roles = "admin,user")]
        public ActionResult Index3()
        {
            //lista autori
            return View(db.Autore.ToList());
        }
        [Authorize(Roles = "admin,user")]
        public ActionResult CercaManga(string nome)
        {
            //questa azione serve a cercare i manga.
            var risultati = db.Manga.Where(l => l.nome.Contains(nome)).ToList();

            return View(risultati);
        }
        [Authorize(Roles = "admin")]
        public ActionResult AdminHome() {
            //pagina iniziale  admin
        return View();
        }

        [Authorize(Roles = "user")]
        public ActionResult UserHome()
        {
            //pagina iniziale dello user
            return View();
        }
        [Authorize(Roles = "user")]
        public ActionResult pagamento()
        {//questa azione permette di avere una view per il pagamento
            return View();
        }
    }
}
