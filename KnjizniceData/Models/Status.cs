using System.ComponentModel.DataAnnotations;

namespace KnjizniceData.Models
{
    public class Status
    {
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }

        [Required]
        public string Opis { get; set; }
    }
}
