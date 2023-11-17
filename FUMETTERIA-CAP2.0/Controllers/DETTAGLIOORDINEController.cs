using FUMETTERIA_CAP2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FUMETTERIA_CAP2._0.Controllers
{
    [Authorize(Roles = "user")]
    public class DETTAGLIOORDINEController : Controller
    {
     
        private Model1 db = new Model1();
        // GET: DETTAGLIOORDINE
        public ActionResult MostraDettagli()
        {
            // Trova l'utente corrente
            User user = db.User.FirstOrDefault(u => u.username == User.Identity.Name);

            // Cerca gli ordini non conclusi,quindi dove concluso = falso
            List<Ordine> ordini = db.Ordine.Where(x => x.IdUser == user.IDutente && x.isConcluso == false).ToList();
            if (ordini.Count == 0)
            {
                // Se non ci sono ordini , mostra un messaggio di errore
                ViewBag.errore = "nessun ordine";
            }
            else
            {
                List<DettaglioOrdine> dettagli = new List<DettaglioOrdine>();
                foreach (Ordine ordine in ordini)
                {
                    List<DettaglioOrdine> dettagliOrdine = db.DettaglioOrdine.Where(x => x.IDordine == ordine.IDordine).ToList();
                    // aggiungi tutti gli elementi della lista dettagliOrdine alla lista dettagli
                    dettagli.AddRange(dettagliOrdine);

                }



                return View(dettagli);
            }


            return View();
        }
    }
}