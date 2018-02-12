using System.ComponentModel.DataAnnotations;

namespace KnjizniceData.Models
{
    public abstract class GradjaKnjiznice  //stavljamo abstract da "child" klase mogu nasljeđivati svojstva
    {
        public int Id { get; set; }

        [Required]
        public string Naslov { get; set; }

        [Required]
        public int GodinaIzdavanja { get; set; }

        [Required]
        public Status Status{ get; set; }
         
        [Required]
        public decimal Cijena { get; set; }

        [Required]
        public string ImageURL { get; set; }

        public int BrojPrimjeraka { get; set; }
        
        public virtual Knjiznica Lokacija { get; set; }
    }
}
