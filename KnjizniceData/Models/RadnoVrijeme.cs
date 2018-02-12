using System.ComponentModel.DataAnnotations;

namespace KnjizniceData.Models
{
    public class RadnoVrijeme
    {
        public int Id { get; set; }
        public Knjiznica Knjiznica { get; set; }

        [Range(0, 6)]
        public int DanTjedna { get; set; }

        [Range(0, 20)]
        public int VrijemeOtvaranja { get; set; }

        [Range(0, 20)]
        public int VrijemeZatvaranja { get; set; }

    }
}
