using System.Collections.Generic;

namespace Knjiznice.Models.Knjiznica
{
    public class KnjiznicaDetailModel
    {
        public int Id { get; set; }
        public string Adresa { get; set; }
        public string Naziv { get; set; }
        public string DatumOtvaranja { get; set; }
        public string Telefon { get; set; }
        public bool Otvoreno { get; set; }
        public string Opis { get; set; }
        public int BrojClanova { get; set; }
        public int BrojGradje { get; set; }
        public decimal VrijednostGradje { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<string> RadnoVrijeme { get; set; }
    }
}
