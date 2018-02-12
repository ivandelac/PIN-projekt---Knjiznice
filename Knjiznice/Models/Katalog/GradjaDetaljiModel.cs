using KnjizniceData.Models;
using System.Collections.Generic;

namespace Knjiznice.Models.Katalog
{
    public class GradjaDetaljiModel
    {
        public int GradjaId { get; set; }
        public string Naslov { get; set; }
        public string AutorOrRedatelj { get; set; }
        public string Vrsta { get; set; }
        public int GodinaIzdavanja { get; set; }
        public string ISBN { get; set; }
        public string Status { get; set; }
        public decimal Cijena { get; set; }
        public string Lokacija { get; set; }
        public string ImageURL { get; set; }
        public string Clan { get; set; }
        public Posudbe ZadnjaPosudba { get; set; }
        public IEnumerable<PovijestPosudbi> PovijestPosudbi { get; set; }
        public IEnumerable<GradjaRezervacijeModel> TrenutneRezervacije { get; set; }
    }

    public class GradjaRezervacijeModel
    {
        public string Clan { get; set; }
        public string Rezervirano { get; set; }
     
    }
}
