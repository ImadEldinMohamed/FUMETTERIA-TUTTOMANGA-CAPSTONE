using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FUMETTERIA_CAP2._0.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Autore> Autore { get; set; }
        public virtual DbSet<DettaglioOrdine> DettaglioOrdine { get; set; }
        public virtual DbSet<Genere> Genere { get; set; }
        public virtual DbSet<Manga> Manga { get; set; }
        public virtual DbSet<Ordine> Ordine { get; set; }
        public virtual DbSet<Popolare> Popolare { get; set; }
        public virtual DbSet<preferito> preferito { get; set; }
        public virtual DbSet<Recensione> Recensione { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autore>()
                .HasMany(e => e.Manga)
                .WithRequired(e => e.Autore)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Genere>()
                .HasMany(e => e.Manga)
                .WithRequired(e => e.Genere)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Manga>()
                .Property(e => e.prezzo)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Manga>()
                .HasMany(e => e.DettaglioOrdine)
                .WithRequired(e => e.Manga)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Manga>()
                .HasMany(e => e.preferito)
                .WithRequired(e => e.Manga)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ordine>()
                .Property(e => e.importo)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Ordine>()
                .HasMany(e => e.DettaglioOrdine)
                .WithRequired(e => e.Ordine)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Ordine)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.preferito)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IDuser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Recensione)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IDuser)
                .WillCascadeOnDelete(false);
        }
    }
}
