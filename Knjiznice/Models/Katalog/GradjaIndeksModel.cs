using System.Collections.Generic;

namespace Knjiznice.Models.Katalog
{
    public class GradjaIndeksModel
    {
        public IEnumerable<GradjaIndeksPrikazModel> Gradja { get; set; }  //korištenjem MVC-a bi mogli prebaciti ovu kolekciju direktno na View , no ideja je da imam
                                                                          //page model za svaka stranicu,  i pojedinčani model  za svaku "komponentu"
    }
}
