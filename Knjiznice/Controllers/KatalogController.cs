using Knjiznice.Models.Katalog;
using Knjiznice.Models.Posudba;
using KnjizniceData;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Knjiznice.Controllers
{
    public class KatalogController : Controller  //koristi GradjaKnjiznice interface
    {
        private IGradjaKnjiznice _gradja;
        private IPosudba _posudbe;

        public KatalogController(IGradjaKnjiznice gradja, IPosudba posudbe) //konstruktor kojem predajemo servis 
        {
            _gradja = gradja;
            _posudbe = posudbe; //spremamo ga u private field kako bi mu imali pristup u ostatku kontrolera
        }

        public IActionResult Index()
        {
            var gradjaModeli = _gradja.GetAll();


            var prikazRezultata = gradjaModeli
                .Select(rezultat => new GradjaIndeksPrikazModel // LINQ upit ,mapirati će svaki element u gradjaModeli u novi GradjaIndeksPrikaz model
                {
                    Id = rezultat.Id,
                    ImageURL = rezultat.ImageURL,
                    AutorOrRedatelj = _gradja.GetAutorOrRedatelj(rezultat.Id),
                    Naslov = rezultat.Naslov,
                    Vrsta = _gradja.GetVrsta(rezultat.Id)
                });

            var model = new GradjaIndeksModel()
            {
                Gradja = prikazRezultata
            };

            return View(model);
           
         }

        public IActionResult Detalji(int id)
        {
            var jedinicagradje = _gradja.GetById(id);

            var trenutneRezervacije = _posudbe.GetCurrentRezervacije(id)
                .Select(a => new GradjaRezervacijeModel
                {
                    Rezervirano = _posudbe.GetCurrentRezervacija(a.Id),
                    Clan = _posudbe.GetCurrentClanRezervacija(a.Id)

                });

            var model = new GradjaDetaljiModel
            {
                GradjaId = id,
                Naslov = jedinicagradje.Naslov,
                GodinaIzdavanja = jedinicagradje.GodinaIzdavanja,
                Cijena = jedinicagradje.Cijena,
                Status = jedinicagradje.Status.Naziv,
                ImageURL = jedinicagradje.ImageURL,
                AutorOrRedatelj = _gradja.GetAutorOrRedatelj(id),
                Lokacija = _gradja.GetCurrentLokacija(id).Naziv,
                ISBN = _gradja.GetISBN(id),
                ZadnjaPosudba = _posudbe.GetLatestPosudba(id),
                Clan = _posudbe.GetCurrentClan(id),
                TrenutneRezervacije = trenutneRezervacije,
                PovijestPosudbi = _posudbe.GetPovijestPosudbi(id)

            };

            return View(model);
        }

        public IActionResult Posudba(int id)
        {
            var gradja = _gradja.GetById(id);

            var model = new PosudbaModel
            {
                GradjaId = id,
                ImageUrl = gradja.ImageURL,
                Naslov = gradja.Naslov,
                ClanskaIskaznicaId = "",
                Izdano = _posudbe.Izdano(id)
            };
            return View(model);
        }

        public IActionResult Rezervacija(int id)
        {
            var gradja = _gradja.GetById(id);

            var model = new PosudbaModel
            {
                GradjaId = id,
                ImageUrl = gradja.ImageURL,
                Naslov = gradja.Naslov,
                ClanskaIskaznicaId = "",
                Izdano = _posudbe.Izdano(id),
                BrojRezervacija = _posudbe.GetCurrentRezervacije(id).Count()
            };
            return View(model);
        }

        public IActionResult OznaciIzgubljeno(int gradjaId)
        {
            _posudbe.OznaciIzgubljeno(gradjaId);
            return RedirectToAction("Detalji", new { id = gradjaId });

        }

        public IActionResult OznaciNadjeno(int gradjaId)
        {
            _posudbe.OznaciNadjeno(gradjaId);
            return RedirectToAction("Detalji", new { id = gradjaId });

        }

        [HttpPost] //ova akcija podržava samo POST metodu
        public IActionResult Posudi (int gradjaId, int clanskaIskaznicaId)
        {
            _posudbe.Posudi(gradjaId, clanskaIskaznicaId);
            return RedirectToAction("Detalji", new { id = gradjaId });
        }



        [HttpPost] //ova akcija podržava samo POST metodu
        public IActionResult Rezerviraj(int gradjaId, int clanskaIskaznicaId)
        {
            _posudbe.Rezerviraj(gradjaId, clanskaIskaznicaId);
            return RedirectToAction("Detalji", new { id = gradjaId }); //vraćamo se nazad na Detail stranicu knjige/videa
        }

        
        public IActionResult Vrati(int id)
        {
            _posudbe.Vrati(id);
            return RedirectToAction("Detalji", new { id = id });
        }
        


    }
}
