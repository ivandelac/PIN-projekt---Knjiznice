using KnjizniceData.Models;
using Microsoft.EntityFrameworkCore;

namespace KnjizniceData
{
    public class KnjizniceContext : DbContext //context klasa koja nasljeđuje od EntityFramework DbContext apstraktne klase
    {
        public KnjizniceContext(DbContextOptions options) : base(options) { } //konstruktor kojem predajemo context options

        public DbSet<Clan> Clanovi { get; set; }
        public DbSet<ClanskaIskaznica> ClanskeIskaznice { get; set; }
        public DbSet<GradjaKnjiznice> GradjaKnjiznice { get; set; }
        public DbSet<Knjiga> Knjige { get; set; }  //nema tablicu u DB-u jer nasljeđuje svojstva od GradjaKnjiznice (discriminator radi razliku)
        public DbSet<Knjiznica> Knjiznice { get; set; }
        public DbSet<Posudbe> Posudbe { get; set; }
        public DbSet<PovijestPosudbi> PovijestPosudbi { get; set; }
        public DbSet<RadnoVrijeme> RadnoVrijeme { get; set; }
        public DbSet<Rezervacije> Rezervacije { get; set; }
        public DbSet<Status> Statusi { get; set; }
        public DbSet<Video> Filmovi { get; set; } //nema tablicu u DB-u jer nasljeđuje svojstva od GradjaKnjiznice

    }
}
