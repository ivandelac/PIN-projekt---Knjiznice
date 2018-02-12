using Knjiznice.Models.Clan;
using KnjizniceData;
using KnjizniceData.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Knjiznice.Controllers
{
    public class ClanController : Controller
    {
        private IClan _clan;

        public ClanController(IClan clan)
        {
            _clan = clan;
        }

        public IActionResult Index()
        {
            var sviClanovi = _clan.GetAll();

            var clanModeli = sviClanovi.Select(p => new ClanDetailModel
            {
                Id = p.Id,
                Ime = p.Ime,
                Prezime = p.Prezime,
                ClanskaIskaznicaId = p.ClanskaIskaznica.Id,
                Zakasnine = p.ClanskaIskaznica.Zakasnine,
                MaticnaKnjiznica = p.MaticnaKnjiznica.Naziv
            }).ToList();

            var model = new ClanIndexModel()
            {
                Clanovi = clanModeli
            };

            return View(model);
        }

        public IActionResult Detalji(int id)
        {
            var clan = _clan.Get(id);

            var model = new ClanDetailModel
            {
                Prezime = clan.Prezime,
                Ime = clan.Ime,
                Adresa = clan.Adresa,
                MaticnaKnjiznica = clan.MaticnaKnjiznica.Naziv,
                Uclanjen = clan.ClanskaIskaznica.DatumIzdavanja,
                Zakasnine = clan.ClanskaIskaznica.Zakasnine,
                ClanskaIskaznicaId = clan.ClanskaIskaznica.Id,
                KontaktBroj = clan.KontaktBroj,
                PosudjenaGradja = _clan.GetPosudbe(id).ToList() ?? new List<Posudbe>(),
                PovijestPosudbi = _clan.GetPovijestPosudbi(id),
                Rezervacije = _clan.GetRezervacije(id)
            };

            return View(model);
        }
    }
}
