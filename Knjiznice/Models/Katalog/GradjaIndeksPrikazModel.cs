namespace Knjiznice.Models.Katalog
{
    public class GradjaIndeksPrikazModel //POCO klasa
    {
        public int Id { get; set; } //uzimamo property-e iz domain entity modela
        public string ImageURL { get; set; }
        public string Naslov{ get; set; }
        public string AutorOrRedatelj { get; set; }
        public string Vrsta { get; set; }
        public string BrojPrimjeraka { get; set; }
        
    }
}
