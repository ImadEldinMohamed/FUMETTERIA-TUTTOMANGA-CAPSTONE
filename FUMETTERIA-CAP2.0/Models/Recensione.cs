namespace FUMETTERIA_CAP2._0.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Recensione")]
    public partial class Recensione
    {
        [Key]
        public int IDrecensione { get; set; }

        [Required]
        public string descrizione { get; set; }

        public int IDuser { get; set; }

        public virtual User User { get; set; }
    }
}
