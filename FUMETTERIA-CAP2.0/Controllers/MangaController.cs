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
  
    public class MangaController : Controller
    {
        private Model1 db = new Model1();
        // GET: Manga
          [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            //lista dei manga
            return View(db.Manga.ToList());
        }
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            ViewBag.IDgenere = new SelectList(db.Genere, "IDgenere", "genere1");

            ViewBag.IDautore = new SelectList(db.Autore, "IDautore", "nome");
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Manga m, HttpPostedFileBase foto)
        { // Verifica la validità del modello e carica l'immagine del manga.
            if (ModelState.IsValid)
            {
                //determina il tipo di file dell'immagine.
                string ext = Path.GetExtension(foto.FileName);
                //percorso dove verrà salvata l'immagine.
                string pathToSave = Path.Combine(Server.MapPath("~/Content/img"), foto.FileName);
                foto.SaveAs(pathToSave);
                //associa l'immagine al manga nel db.
                m.foto = foto.FileName;

                // Se l'immagine è stata caricata , aggiunge il manga al db e salva.
                if (m.foto != null)
                {
                    db.Manga.Add(m);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.IDgenere = new SelectList(db.Genere, "IDgenere", "genere1", m.IDgenere);

            ViewBag.IDautore = new SelectList(db.Autore, "IDautore", "nome", m.IDautore);
            return View(m);
        }
        [Authorize(Roles = "admin")]
        //modifica il manga
        public ActionResult Edit(int id)
        {

            Manga m = db.Manga.Find(id);
            ViewBag.IDgenere = new SelectList(db.Genere, "IDgenere", "genere1");

            ViewBag.IDautore = new SelectList(db.Autore, "IDautore", "nome");
            return View(m);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Manga m, HttpPostedFileBase foto)
        {


            if (ModelState.IsValid)
            {
                string ext = Path.GetExtension(foto.FileName);
                string pathToSave = Path.Combine(Server.MapPath("~/Content/img"), foto.FileName);
                foto.SaveAs(pathToSave);
                m.foto = foto.FileName;
                if (m.foto != null)
                {
                    //la modifica viene effetuata e salvata nel db
                    db.Entry(m).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.IDgenere = new SelectList(db.Genere, "IDgenere", "genere1", m.IDgenere);

            ViewBag.IDautore = new SelectList(db.Autore, "IDautore", "nome", m.IDautore);
            return View(m);

        }
        [Authorize(Roles = "admin")]
        // cancella un manga dal db
        public ActionResult delete(int id)
        {
            Manga m = db.Manga.Find(id);
            return View(m);
        }
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {

            Manga m = db.Manga.Find(id);
            db.Manga.Remove(m);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "admin,user")]
        public ActionResult Details(int id)
        {//dettaglio del manga
            Manga m = db.Manga.Find(id);
            return View(m);
        }
    }
}