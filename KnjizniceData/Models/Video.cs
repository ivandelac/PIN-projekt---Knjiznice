using System.ComponentModel.DataAnnotations;

namespace KnjizniceData.Models
{
    public class Video : GradjaKnjiznice
    {
        [Required]
        public string Redatelj { get; set; }
    }
}
