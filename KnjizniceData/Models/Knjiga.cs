using System.ComponentModel.DataAnnotations;

namespace KnjizniceData.Models
{
    public class Knjiga : GradjaKnjiznice
    {
        [Required]
        public string ISBN { get; set; }

        [Required]
        public string Autor { get; set; }

    }
}
