namespace FUMETTERIA_CAP2._0.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("preferito")]
    public partial class preferito
    {
        [Key]
        public int IDpreferito { get; set; }

        public int IDuser { get; set; }

        public int IDmanga { get; set; }

        public bool isPreferito { get; set; }

        public virtual Manga Manga { get; set; }

        public virtual User User { get; set; }
    }
}
