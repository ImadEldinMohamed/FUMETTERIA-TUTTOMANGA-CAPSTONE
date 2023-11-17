namespace FUMETTERIA_CAP2._0.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Popolare")]
    public partial class Popolare
    {
        [Key]
        public int IDpopolare { get; set; }

        [Required]
        [StringLength(50)]
        public string nome { get; set; }

        [Required]
        [StringLength(50)]
        public string foto { get; set; }

        public string descrizione { get; set; }

        [StringLength(50)]
        public string serie { get; set; }
    }
}
