namespace FUMETTERIA_CAP2._0.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DettaglioOrdine")]
    public partial class DettaglioOrdine
    {
        [Key]
        public int IDdettaglio { get; set; }

        public int quantita { get; set; }

        public int IDmanga { get; set; }

        public int IDordine { get; set; }

        public virtual Manga Manga { get; set; }

        public virtual Ordine Ordine { get; set; }

        public DettaglioOrdine() { }

        public DettaglioOrdine(int quantita, int iDmanga, int iDordine)
        {

            this.quantita = quantita;
            IDmanga = iDmanga;
            IDordine = iDordine;

        }
    }
}
