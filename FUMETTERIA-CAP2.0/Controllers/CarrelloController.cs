using FUMETTERIA_CAP2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FUMETTERIA_CAP2._0.Controllers
{
    [Authorize(Roles = "user,admin")]
    public class CarrelloController : Controller
    {
        private Model1 db = new Model1();

        // GET: Carrello
        public ActionResult Index()
        {
            // la sessione con oggetto Carrello viene memorizzata all'interno della viewbag
            ViewBag.Carrello = Session["Carrello"];
            return View();

        }

        //eliminare elementi dal carrello

        public ActionResult Rimuovi(string nomeProdotto)
        {
            // recupero l'oggetto Carrello dalla sessione e lo assegno alla variabile carrello di tipo list<carrello>

            List<Carrello> carrello = Session["Carrello"] as List<Carrello>;

            // Trovo l'elemento nel carrello che voglio eliminare
            Carrello elementoDaRimuovere = carrello.FirstOrDefault(item => item.Nome == nomeProdotto);

            // Se l'elemento viene trovato viene rimosso.

            if (elementoDaRimuovere != null)
            {
                carrello.Remove(elementoDaRimuovere);
            }

            // la sessione carrello dopo aver eliminato l'lelemento che abbiamo rimosso viene aggiornata

            Session["Carrello"] = carrello;
            return RedirectToAction("Index");
        }

        // aggiungo elementi nel carrello e per farlo gli passo 2 parametri che sono IDmanga e la quantità
        public ActionResult aggiungialcarrello(int IDmanga, int Quantita)
        {
            Manga m = db.Manga.Find(IDmanga);

            Carrello car = new Carrello(m.nome, Quantita, m.prezzo,m.foto, IDmanga);
            // cerca il carrello dell'utente dalla sessione. Se non è presente, crea una  nuova lista di oggetti Carrello vuota.
            List<Carrello> carrello = Session["Carrello"] as List<Carrello> ?? new List<Carrello>();
            carrello.Add(car);
            Session["Carrello"] = carrello;
            return RedirectToAction("Index", "Carrello");
        }

    }
}