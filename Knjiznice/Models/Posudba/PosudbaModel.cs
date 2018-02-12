namespace Knjiznice.Models.Posudba
{
    public class PosudbaModel
    {
        public string ClanskaIskaznicaId { get; set; }
        public string Naslov { get; set; }
        public int GradjaId { get; set; }
        public string ImageUrl { get; set; }
        public int BrojRezervacija { get; set; }
        public bool Izdano { get; set; }
    }
}
