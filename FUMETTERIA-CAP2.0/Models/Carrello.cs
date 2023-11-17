using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FUMETTERIA_CAP2._0.Models
{
    public class Carrello
    {
        public string Nome { get; set; }
        public int Quantita { get; set; }

        public decimal CostoFumetti { get; set; }

        public int IDmanga { get; set; }

        public  string Foto { get; set; }


        public static decimal CostoTot(List<Carrello> carr)
        {
            decimal tot = 0;
            foreach (Carrello el in carr)
            {// Calcola il costo dell'elemento moltiplicando la quantità per il costo
                decimal costoelementi = el.Quantita * el.CostoFumetti;
                // Aggiunge il costo dell'elemento al totale.
                tot += costoelementi;
            }
            return tot;
        }

        public Carrello() { }
        public Carrello(string nome, int quantita, decimal costoFumetti,string foto, int iDmanga)
        {
            Nome = nome;
            Quantita = quantita;
            CostoFumetti = costoFumetti;
            Foto = foto;
            IDmanga = iDmanga;
        }
    }
}