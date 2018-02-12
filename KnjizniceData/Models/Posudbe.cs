using System;
using System.ComponentModel.DataAnnotations;

namespace KnjizniceData.Models
{
    public class Posudbe
    {
        public int Id { get; set; }

        [Required]
        public GradjaKnjiznice GradjaKnjiznice { get; set; }
        public ClanskaIskaznica ClanskaIskaznica { get; set; }
        public DateTime Od { get; set; }
        public DateTime Do { get; set; }

    }
}
