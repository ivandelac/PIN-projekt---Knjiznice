using System.Linq;
using Microsoft.AspNetCore.Mvc;
using KnjizniceData;
using Knjiznice.Models.Knjiznica;


namespace Knjiznice.Controllers
{
    public class KnjizniceController : Controller
    {
        
        private IKnjiznica _knjiznica;

        public KnjizniceController(IKnjiznica knjiznica)
        {

            _knjiznica = knjiznica;
        }

       
        public IActionResult Index()
        {
            var knjizniceModeli = _knjiznica.GetAll()
                .Select(br => new KnjiznicaDetailModel
                {
                    Id = br.Id,
                    Naziv = br.Naziv,
                    BrojGradje = _knjiznica.GetGradjaCount(br.GradjaKnjiznice),
                    BrojClanova = _knjiznica.GetClanoviCount(br.Clanovi),
                    Otvoreno = _knjiznica.Otvoreno(br.Id)
                }).ToList();

            var model = new KnjiznicaIndeksModel()
            {
                Knjižnice = knjizniceModeli
            };

            return View(model);
        }

        public IActionResult Detalji(int Id)
        {
            var knjiznica = _knjiznica.Get(Id);
            var model = new KnjiznicaDetailModel
            {
                Naziv = knjiznica.Naziv,
                Opis = knjiznica.Opis,
                Adresa = knjiznica.Adresa,
                Telefon = knjiznica.Telefon,
                DatumOtvaranja = knjiznica.DatumOtvaranja.ToString("yyyy-MM-dd"),
                BrojClanova = _knjiznica.GetClanoviCount(knjiznica.Clanovi),
                BrojGradje = _knjiznica.GetGradjaCount(knjiznica.GradjaKnjiznice),
                VrijednostGradje = _knjiznica.GetGradjaValue(Id),
                ImageUrl = knjiznica.ImageURL,
                RadnoVrijeme = _knjiznica.GetRadnoVrijeme(Id)
            };

            return View(model);
        }
    }
}