namespace FUMETTERIA_CAP2._0.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Autore")]
    public partial class Autore
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Autore()
        {
            Manga = new HashSet<Manga>();
        }

        [Key]
        public int IDautore { get; set; }

        [Required]
        [StringLength(50)]
        public string nome { get; set; }

        public string descrizione { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Manga> Manga { get; set; }
    }
}
