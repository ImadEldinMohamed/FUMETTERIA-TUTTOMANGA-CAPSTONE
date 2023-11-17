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
    [Authorize()]
    public class PreferitoController : Controller
    {
        private Model1 db = new Model1();

        // GET: Preferito

        public ActionResult AggiungiAiPreferiti(int IDmanga, bool aggiuntapreferiti)
        {
            if (aggiuntapreferiti && User.Identity.IsAuthenticated)
            {
                User user = db.User.FirstOrDefault(u => u.username == User.Identity.Name);

                if (user != null)
                {
                    // Trova il manga che si desidera aggiungere ai preferiti
                    Manga manga = db.Manga.Find(IDmanga);

                    if (manga != null)
                    {
                        // Crea un nuovo oggetto Preferito
                        preferito nuovoPreferito = new preferito
                        {
                            IDuser = user.IDutente,
                            IDmanga = manga.IDmanga
                        };

                        // Aggiungi il nuovo Preferito al database
                        db.preferito.Add(nuovoPreferito);
                        db.SaveChanges();
                    }
                }
            }

            return RedirectToAction("VisualizzaPreferiti", "Preferito");
        }

        public ActionResult VisualizzaPreferiti()
        {
            // Controlla se l'utente è autenticato
            if (User.Identity.IsAuthenticated)
            {
                User user = db.User.FirstOrDefault(u => u.username == User.Identity.Name);


                List<Manga> preferiti = db.preferito
               .Where(p => p.IDuser == user.IDutente) // Filtra per ID dell'utente
               .Select(p => p.Manga) // Seleziona i manga associati ai preferiti
               .ToList();

                return View(preferiti);
            }

            return View(new List<Manga>()); 
        }
        public ActionResult RimuoviDaPreferiti(int IDmanga)
        {
            if (User.Identity.IsAuthenticated)
            {
                User user = db.User.FirstOrDefault(u => u.username == User.Identity.Name);

                if (user != null)
                {
                    // Trova il Preferito corrispondente all'utente e al manga da rimuovere
                    preferito DaRimuovere = db.preferito.FirstOrDefault(p => p.IDuser == user.IDutente && p.IDmanga == IDmanga);

                    if (DaRimuovere != null)
                    {
                        // Rimuovi il Preferito dal database
                        db.preferito.Remove(DaRimuovere);
                        db.SaveChanges();
                    }
                }
            }

      

            return RedirectToAction("VisualizzaPreferiti", "Preferito");
        }
    }
}