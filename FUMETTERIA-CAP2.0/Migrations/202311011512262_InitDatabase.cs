namespace FUMETTERIA_CAP2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autore",
                c => new
                    {
                        IDautore = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 50),
                        descrizione = c.String(),
                    })
                .PrimaryKey(t => t.IDautore);
            
            CreateTable(
                "dbo.Manga",
                c => new
                    {
                        IDmanga = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 50),
                        foto = c.String(nullable: false, maxLength: 50),
                        prezzo = c.Decimal(nullable: false, storeType: "money"),
                        descrizione = c.String(),
                        IDgenere = c.Int(nullable: false),
                        IDautore = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDmanga)
                .ForeignKey("dbo.Genere", t => t.IDgenere)
                .ForeignKey("dbo.Autore", t => t.IDautore)
                .Index(t => t.IDgenere)
                .Index(t => t.IDautore);
            
            CreateTable(
                "dbo.DettaglioOrdine",
                c => new
                    {
                        IDdettaglio = c.Int(nullable: false, identity: true),
                        quantita = c.Int(nullable: false),
                        IDmanga = c.Int(nullable: false),
                        IDordine = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDdettaglio)
                .ForeignKey("dbo.Ordine", t => t.IDordine)
                .ForeignKey("dbo.Manga", t => t.IDmanga)
                .Index(t => t.IDmanga)
                .Index(t => t.IDordine);
            
            CreateTable(
                "dbo.Ordine",
                c => new
                    {
                        IDordine = c.Int(nullable: false, identity: true),
                        data = c.DateTime(nullable: false, storeType: "date"),
                        isSpedito = c.Boolean(nullable: false),
                        isConcluso = c.Boolean(nullable: false),
                        indirizzo = c.String(maxLength: 50),
                        importo = c.Decimal(nullable: false, storeType: "money"),
                        IdUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDordine)
                .ForeignKey("dbo.User", t => t.IdUser)
                .Index(t => t.IdUser);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        IDutente = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false, maxLength: 50),
                        password = c.String(nullable: false, maxLength: 50),
                        nome = c.String(maxLength: 50),
                        cognome = c.String(maxLength: 50),
                        Role = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.IDutente);
            
            CreateTable(
                "dbo.preferito",
                c => new
                    {
                        IDpreferito = c.Int(nullable: false, identity: true),
                        IDuser = c.Int(nullable: false),
                        IDmanga = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDpreferito)
                .ForeignKey("dbo.User", t => t.IDuser)
                .ForeignKey("dbo.Manga", t => t.IDmanga)
                .Index(t => t.IDuser)
                .Index(t => t.IDmanga);
            
            CreateTable(
                "dbo.Recensione",
                c => new
                    {
                        IDrecensione = c.Int(nullable: false, identity: true),
                        descrizione = c.String(nullable: false),
                        IDuser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDrecensione)
                .ForeignKey("dbo.User", t => t.IDuser)
                .Index(t => t.IDuser);
            
            CreateTable(
                "dbo.Genere",
                c => new
                    {
                        IDgenere = c.Int(nullable: false, identity: true),
                        genere = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.IDgenere);
            
            CreateTable(
                "dbo.Popolare",
                c => new
                    {
                        IDpopolare = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 50),
                        foto = c.String(nullable: false, maxLength: 50),
                        descrizione = c.String(),
                        serie = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.IDpopolare);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Manga", "IDautore", "dbo.Autore");
            DropForeignKey("dbo.preferito", "IDmanga", "dbo.Manga");
            DropForeignKey("dbo.Manga", "IDgenere", "dbo.Genere");
            DropForeignKey("dbo.DettaglioOrdine", "IDmanga", "dbo.Manga");
            DropForeignKey("dbo.Recensione", "IDuser", "dbo.User");
            DropForeignKey("dbo.preferito", "IDuser", "dbo.User");
            DropForeignKey("dbo.Ordine", "IdUser", "dbo.User");
            DropForeignKey("dbo.DettaglioOrdine", "IDordine", "dbo.Ordine");
            DropIndex("dbo.Recensione", new[] { "IDuser" });
            DropIndex("dbo.preferito", new[] { "IDmanga" });
            DropIndex("dbo.preferito", new[] { "IDuser" });
            DropIndex("dbo.Ordine", new[] { "IdUser" });
            DropIndex("dbo.DettaglioOrdine", new[] { "IDordine" });
            DropIndex("dbo.DettaglioOrdine", new[] { "IDmanga" });
            DropIndex("dbo.Manga", new[] { "IDautore" });
            DropIndex("dbo.Manga", new[] { "IDgenere" });
            DropTable("dbo.Popolare");
            DropTable("dbo.Genere");
            DropTable("dbo.Recensione");
            DropTable("dbo.preferito");
            DropTable("dbo.User");
            DropTable("dbo.Ordine");
            DropTable("dbo.DettaglioOrdine");
            DropTable("dbo.Manga");
            DropTable("dbo.Autore");
        }
    }
}
