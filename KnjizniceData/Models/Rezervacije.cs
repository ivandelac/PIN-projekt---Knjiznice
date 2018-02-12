using System;

namespace KnjizniceData.Models
{
    public class Rezervacije
    {
        public int Id { get; set; }
        public virtual GradjaKnjiznice GradjaKnjiznice { get; set; }
        public virtual ClanskaIskaznica ClanskaIskaznica { get; set; }
        public DateTime Rezervirano { get; set; }

       
    }
}
