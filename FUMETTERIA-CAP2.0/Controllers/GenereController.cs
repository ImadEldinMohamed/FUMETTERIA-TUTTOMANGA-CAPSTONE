using FUMETTERIA_CAP2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FUMETTERIA_CAP2._0.Controllers
{
    [Authorize(Roles = "admin")]
    public class GenereController : Controller
    {
   
        private Model1 db = new Model1();
        // GET: Genere
        public ActionResult Index()
        {
            //lista dei generi
            return View(db.Genere.ToList());
        }
        //creo un genere
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genere genere)
        {//se il modello è valido il nuovo genere vienne aggiunto nel db
            if (ModelState.IsValid)
            {
                db.Genere.Add(genere);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genere);
        }

        //eliminare un genere
        public ActionResult Delete(int id)
        {
            Genere genere = db.Genere.Find(id);
            return View(genere);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete2(int id)
        {
            Genere genere = db.Genere.Find(id);
            db.Genere.Remove(genere);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}