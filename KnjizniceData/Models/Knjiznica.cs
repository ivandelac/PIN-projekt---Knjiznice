using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KnjizniceData.Models
{
    public class Knjiznica
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Maksimalno 30 znakova.")]
        public string Naziv { get; set; }

        [Required]
        public string Adresa { get; set; }

        [Required]
        public string Telefon { get; set; }
        public string Opis { get; set; }
        public DateTime DatumOtvaranja { get; set; }

        public virtual IEnumerable<Clan> Clanovi { get; set; }
        public virtual IEnumerable<GradjaKnjiznice> GradjaKnjiznice { get; set; }

        public string ImageURL { get; set; }
    }
}
