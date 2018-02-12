using System;

namespace KnjizniceData.Models
{
    public class Clan
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public DateTime DatRod { get; set; }
        public string KontaktBroj { get; set; }

        public virtual ClanskaIskaznica ClanskaIskaznica { get; set; }
        public virtual Knjiznica MaticnaKnjiznica { get; set; }
    }
}
