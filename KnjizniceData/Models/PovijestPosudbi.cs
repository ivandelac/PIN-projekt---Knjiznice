using System;
using System.ComponentModel.DataAnnotations;

namespace KnjizniceData.Models
{
    public class PovijestPosudbi
    {
        public int Id { get; set; }

        [Required]
        public GradjaKnjiznice GradjaKnjiznice { get; set; }

        [Required]
        public ClanskaIskaznica ClanskaIskaznica { get; set; }

        [Required]
        public DateTime Posudjeno { get; set; }

        public DateTime? Vraceno { get; set; }
    }
}
