using FUMETTERIA_CAP2._0.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FUMETTERIA_CAP2._0.Controllers
{

    public class AutoreController : Controller
    {
    
        private Model1 db = new Model1();
        [Authorize(Roles = "admin")]
        // GET: Autore
        public ActionResult Index()
        {
            // mostra la lista degli autori
            return View(db.Autore.ToList());
        }

        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Autore autore)
        {
            if (ModelState.IsValid)
            {// se il modello è valido aggiuunge un autore  e lo salva nel db
                db.Autore.Add(autore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(autore);
        }
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            // metodo per cancellare un autore dal db tramite il suo id
            Autore autore = db.Autore.Find(id);
            return View(autore);
        }

        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete2(int id)
        {
            Autore autore = db.Autore.Find(id);
            db.Autore.Remove(autore);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            //metodo per modificare le proprietà dell'autore 

            Autore autore = db.Autore.Find(id);
            return View(autore);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Autore autore)
        {
            if (ModelState.IsValid)
            {
                //dopo aver effettuato le modifiche vengono salvate nel db
                db.Entry(autore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(autore);
        }

        [Authorize(Roles = "admin,user")]
        public ActionResult Details(int id)
        {  //dettagli autore
            Autore a = db.Autore.Find(id);
            return View(a);
        }
    }
}