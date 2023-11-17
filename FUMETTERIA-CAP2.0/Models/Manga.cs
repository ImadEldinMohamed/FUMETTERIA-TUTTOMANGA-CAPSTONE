namespace FUMETTERIA_CAP2._0.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Manga")]
    public partial class Manga
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Manga()
        {
            DettaglioOrdine = new HashSet<DettaglioOrdine>();
            preferito = new HashSet<preferito>();
        }

        [Key]
        public int IDmanga { get; set; }

        [Required]
        [StringLength(50)]
        public string nome { get; set; }

        [Required]
        [StringLength(50)]
        public string foto { get; set; }

        [Column(TypeName = "money")]
        public decimal prezzo { get; set; }

        public string descrizione { get; set; }

        public int IDgenere { get; set; }

        public int IDautore { get; set; }

        public virtual Autore Autore { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DettaglioOrdine> DettaglioOrdine { get; set; }

        public virtual Genere Genere { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<preferito> preferito { get; set; }
    }
}
