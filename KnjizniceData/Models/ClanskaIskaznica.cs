using System;
using System.Collections.Generic;

namespace KnjizniceData.Models
{
    public class ClanskaIskaznica
    {
        public int Id { get; set; }
        public decimal Zakasnine { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public virtual IEnumerable<Posudbe> Posudbe { get; set; }
    }
}
