using KnjizniceData.Models;
using System;
using System.Collections.Generic;

namespace Knjiznice.Models.Clan
{
    public class ClanDetailModel
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int ClanskaIskaznicaId { get; set; }
        public string Adresa { get; set; }
        public DateTime Uclanjen { get; set; }
        public string KontaktBroj { get; set; }
        public string MaticnaKnjiznica { get; set; }
        public decimal Zakasnine { get; set; }
        public IEnumerable<Posudbe> PosudjenaGradja { get; set; }
        public IEnumerable<PovijestPosudbi> PovijestPosudbi { get; set; }
        public IEnumerable<Rezervacije> Rezervacije { get; set; }
    }
}
