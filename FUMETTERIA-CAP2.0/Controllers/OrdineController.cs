using FUMETTERIA_CAP2._0.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FUMETTERIA_CAP2._0.Controllers
{
    public class OrdineController : Controller
    {
        private Model1 db = new Model1();
        // GET: Ordine

        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            // Recupero tutti gli ordini che non sono ancora conclusi dal db
            List<Ordine> ordiniNonConclusi = db.Ordine.Where(x => x.isConcluso == false).ToList();


            return View(ordiniNonConclusi);
        }


        [Authorize(Roles = "user,admin")]
        public ActionResult creaOrdine()
        {
            // Recupera il carrello dell'utente dalla sessione
            ViewBag.Carrello = Session["Carrello"];
            return View();
        }
        // Questa azione si occupa della creazione dell'ordine e dell'inserimento dei dettagli dell'ordine.
        [HttpPost]
        public ActionResult creaOrdine(Ordine o)
        { //recupera il carrello dalla sessione.
            ViewBag.Carrello = Session["Carrello"];
            //recupera l'utente autenticato.
            User user = db.User.FirstOrDefault(u => u.username == User.Identity.Name);
            o.IdUser = user.IDutente;
            o.data = DateTime.Now;
            o.isSpedito = false;
            o.isConcluso = false;
            o.importo = Carrello.CostoTot(ViewBag.Carrello);
            if (ModelState.IsValid)
            {
                //aggiunge l'ordine al db e lo salva.
                db.Ordine.Add(o);
                db.SaveChanges();
                // Per ciascun elemento del carrello, crea un DettaglioOrdine e lo aggiunge al db.
                foreach (Carrello item in ViewBag.Carrello)
                {
                    DettaglioOrdine d = new DettaglioOrdine(item.Quantita, item.IDmanga, o.IDordine);
                    db.DettaglioOrdine.Add(d);
                    db.SaveChanges();
                }
                Session.Remove("Carrello");
                return RedirectToAction("pagamento", "Home");
            }
            else { return View(); }
        }


        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            return View(db.Ordine.Find(id));
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Edit(Ordine ordine)
        {
            if (ModelState.IsValid)
            {
                // Salva le modifiche apportate 
                db.Entry(ordine).State = EntityState.Modified;
                db.SaveChanges();


                return RedirectToAction("Index", "Ordine");
            }


            return View(ordine);
        }
        //questa azione consente all'admin di vedere i guadagni di una determinata giornata tramite chiamata asincrona
        [Authorize(Roles = "admin")]
        public JsonResult guadagni(DateTime date)
        {
            decimal totale = db.Ordine
                            .Where(x => x.data == date && x.isConcluso)
                           .Select(o => o.importo)
                           .DefaultIfEmpty()
                           .Sum();

            return Json(totale,JsonRequestBehavior.AllowGet);
        }
    }
}