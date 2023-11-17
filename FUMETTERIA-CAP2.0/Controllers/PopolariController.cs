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
  
    public class PopolariController : Controller
    {
        private Model1 db = new Model1();
        [Authorize(Roles = "admin")]
        // GET: Manga
        public ActionResult Index()
        {
            //lista dei popolari
            return View(db.Popolare.ToList());
        }
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {

            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Popolare p, HttpPostedFileBase foto)
        {
            if (ModelState.IsValid)
            {
                string ext = Path.GetExtension(foto.FileName);
                string pathToSave = Path.Combine(Server.MapPath("~/Content/img"), foto.FileName);
                foto.SaveAs(pathToSave);
                p.foto = foto.FileName;
                if (p.foto != null)
                {
                    db.Popolare.Add(p);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(p);
        }
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            Popolare p = db.Popolare.Find(id);

            return View(p);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Popolare p, HttpPostedFileBase foto)
        {


            if (ModelState.IsValid)
            {
                string ext = Path.GetExtension(foto.FileName);
                string pathToSave = Path.Combine(Server.MapPath("~/Content/img"), foto.FileName);
                foto.SaveAs(pathToSave);
                p.foto = foto.FileName;
                if (p.foto != null)
                {
                    db.Entry(p).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(p);

        }
        [Authorize(Roles = "admin")]
        public ActionResult delete(int id)
        {
            Popolare p = db.Popolare.Find(id);
            return View(p);
        }
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {

            Popolare p = db.Popolare.Find(id);
            db.Popolare.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "admin,user")]
        public ActionResult Details(int id)
        {
            Popolare p = db.Popolare.Find(id);
            return View(p);
        }
    }
}