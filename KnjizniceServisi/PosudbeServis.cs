using KnjizniceData.Models;
using KnjizniceData;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace KnjizniceServisi
{
    public class PosudbeServis : IPosudba
    {


        private KnjizniceContext _context; 


        public PosudbeServis(KnjizniceContext context)
        {
            _context = context; // private field unutar konstruktora za pohranjivanje konteksta
        }



        public void Add(Posudbe newPosudba)
        {
            _context.Add(newPosudba);
            _context.SaveChanges();
        }

        public Posudbe Get(int id)
        {
            return _context.Posudbe.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Posudbe> GetAll()
        {
            return _context.Posudbe;
        }

        public int GetBrojPrimjeraka(int id)
        {
            return _context.GradjaKnjiznice
                .FirstOrDefault(a => a.Id == id)
                .BrojPrimjeraka;
        }

        public int GetRaspoloziviPrimjerci(int id)
        {
            var brojPrimjeraka = GetBrojPrimjeraka(id);

            var brojPosudjenih = _context.Posudbe
                .Where(a => a.GradjaKnjiznice.Id == id
                         && a.GradjaKnjiznice.Status.Naziv == "Izdano")
                         .Count();

            return brojPrimjeraka - brojPosudjenih;
        }

        public string GetCurrentClanRezervacija(int id)
        {
            var rezervacija = _context.Rezervacije
                .Include(a => a.GradjaKnjiznice)
                .Include(a => a.ClanskaIskaznica)
                .Where(v => v.Id == id);

            var iskaznicaId = rezervacija
                .Include(a => a.ClanskaIskaznica)
                .Select(a => a.ClanskaIskaznica.Id)
                .FirstOrDefault();

            var clan = _context.Clanovi
                .Include(p => p.ClanskaIskaznica)
                .FirstOrDefault(p => p.ClanskaIskaznica.Id == iskaznicaId);

            return clan.Ime + " " + clan.Prezime;
        }

        public string GetCurrentRezervacija(int id)
        {
            var rezervacija = _context.Rezervacije
                .Include(a => a.GradjaKnjiznice)
                .Include(a => a.ClanskaIskaznica)
                .Where(v => v.Id == id);

            return rezervacija.Select(a => a.Rezervirano)
                .FirstOrDefault().ToString();
        }

        public string GetCurrentClan(int id)
        {
            var posudba = _context.Posudbe
               .Include(a => a.GradjaKnjiznice)
               .Include(a => a.ClanskaIskaznica)
               .Where(a => a.GradjaKnjiznice.Id == id)
               .FirstOrDefault();

            if (posudba == null)
            {
                return "Nije izdano.";
            }

            var iskaznicaId = posudba.ClanskaIskaznica.Id;

            var clan = _context.Clanovi
                .Include(p => p.ClanskaIskaznica)
                .Where(c => c.ClanskaIskaznica.Id == iskaznicaId)
                .FirstOrDefault();

            return clan.Ime + " " + clan.Prezime;
        }

        public IEnumerable<Rezervacije> GetCurrentRezervacije(int id)
        {
            return _context.Rezervacije
                .Include(h => h.GradjaKnjiznice)
                .Where(a => a.GradjaKnjiznice.Id == id);
        }

        public Posudbe GetLatestPosudba(int id)
        {
            return _context.Posudbe
                .Where(c => c.GradjaKnjiznice.Id == id)
                .OrderByDescending(c => c.Od)
                .FirstOrDefault();
        }

        public IEnumerable<PovijestPosudbi> GetPovijestPosudbi(int id)
        {
            return _context.PovijestPosudbi
                .Include(a => a.GradjaKnjiznice)
                .Include(a => a.ClanskaIskaznica)
                .Where(a => a.GradjaKnjiznice.Id == id);
        }

        

        public bool Izdano(int id)
        {
            var Izdano = _context.Posudbe.Where(a => a.GradjaKnjiznice.Id == id).Any();

            return Izdano;
        }

        public void OznaciIzgubljeno(int id)
        {
            var primjerak = _context.GradjaKnjiznice
               .FirstOrDefault(a => a.Id == id);

            _context.Update(primjerak);

            primjerak.Status = _context.Statusi.FirstOrDefault(a => a.Naziv == "Izgubljeno");

            _context.SaveChanges();
        }

        public void OznaciNadjeno(int id)
        {
            var primjerak = _context.GradjaKnjiznice
                .FirstOrDefault(a => a.Id == id);

            _context.Update(primjerak);
            primjerak.Status = _context.Statusi.FirstOrDefault(a => a.Naziv == "Raspoloživo");
            var now = DateTime.Now;

            // mičemo sve posudbe tog primjerka
            var posudba = _context.Posudbe
                .FirstOrDefault(a => a.GradjaKnjiznice.Id == id);
            if (posudba != null)
            {
                _context.Remove(posudba);
            }

            // zatvaramo povijest posudbi ako postoji
            var povijestPosudbi = _context.PovijestPosudbi
                .FirstOrDefault(h =>
                h.GradjaKnjiznice.Id == id
                && h.Vraceno == null);
            if (povijestPosudbi != null)
            {
                _context.Update(povijestPosudbi);
                povijestPosudbi.Vraceno = now;
            }

            _context.SaveChanges();
        }

        public void Posudi(int gradjaId, int clanskaIskaznicaId)
        {
            if (Izdano(gradjaId))
            {
                return;
               
            }

            var primjerak = _context.GradjaKnjiznice
                .Include(a => a.Status)
                .FirstOrDefault(a => a.Id == gradjaId);

            _context.Update(primjerak);

            primjerak.Status = _context.Statusi
                .FirstOrDefault(a => a.Naziv == "Izdano");

            var now = DateTime.Now;

            var clanskaIskaznica = _context.ClanskeIskaznice
                .Include(c => c.Posudbe)
                .FirstOrDefault(a => a.Id == clanskaIskaznicaId);

            var posudba = new Posudbe
            {
                GradjaKnjiznice = primjerak,
                ClanskaIskaznica = clanskaIskaznica,
                Od = now,
                Do = GetDefaultCheckoutTime(now)
            };

            _context.Add(posudba);

            var povijestPosudbi = new PovijestPosudbi
            {
                Posudjeno = now,
                GradjaKnjiznice = primjerak,
                ClanskaIskaznica = clanskaIskaznica
            };

            _context.Add(povijestPosudbi);
            _context.SaveChanges();
        }

        public DateTime GetDefaultCheckoutTime(DateTime now)
        {
            return now.AddDays(30);
        }



        public void Rezerviraj(int gradjaId, int clanskaIskaznicaId)
        {
            var now = DateTime.Now;

            var gradja = _context.GradjaKnjiznice
                .Include(a => a.Status)
                .FirstOrDefault(a => a.Id == gradjaId);

            var clanskaIskaznica = _context.ClanskeIskaznice
                .FirstOrDefault(a => a.Id == clanskaIskaznicaId);

            _context.Update(gradja);

            if (gradja.Status.Naziv == "Raspoloživo")
            {
                gradja.Status = _context.Statusi.FirstOrDefault(a => a.Naziv == "Rezervirano");
            }

            var rezervacija = new Rezervacije
            {
                Rezervirano = now,
                GradjaKnjiznice = gradja,
                ClanskaIskaznica = clanskaIskaznica
            };

            _context.Add(rezervacija);
            _context.SaveChanges();
        }

        public void Vrati(int gradjaId)
        {
            var now = DateTime.Now;

            var primjerak = _context.GradjaKnjiznice
                .FirstOrDefault(a => a.Id == gradjaId);

            _context.Update(primjerak);

            // mičemo postojeće posudbe primjerka
            var posudba = _context.Posudbe
                .Include(c => c.GradjaKnjiznice)
                .Include(c => c.ClanskaIskaznica)
                .FirstOrDefault(a => a.GradjaKnjiznice.Id == gradjaId);
            if (posudba != null)
            {
                _context.Remove(posudba);
            }

            // zatvaramo postojeću povijest posudbi
            var povijestPosudbi = _context.PovijestPosudbi
                .Include(h => h.GradjaKnjiznice)
                .Include(h => h.ClanskaIskaznica)
                .FirstOrDefault(h =>
                h.GradjaKnjiznice.Id == gradjaId
                && h.Vraceno == null);
            if (povijestPosudbi != null)
            {
                _context.Update(povijestPosudbi);
                povijestPosudbi.Vraceno = now;
            }

            // traži trenutne rezervacije
            var trenutneRezervacije = _context.Rezervacije
                .Include(a => a.GradjaKnjiznice)
                .Include(a => a.ClanskaIskaznica)
                .Where(a => a.GradjaKnjiznice.Id == gradjaId);

            // ako postoje rezervacije, izdaj primjerak članu koji je najranije rezervirao
            if (trenutneRezervacije.Any())
            {
                IzdajNajranijojRezervaciji(gradjaId, trenutneRezervacije);
                return;
            }

            // u suprotnome, stavi primjerku status "Raspoloživo
            primjerak.Status = _context.Statusi.FirstOrDefault(a => a.Naziv == "Raspoloživo");

            _context.SaveChanges();
        }

       

        public void IzdajNajranijojRezervaciji(int gradjaId, IEnumerable<Rezervacije> trenutneRezervacije)
        {
            var najranijaRezervacija = trenutneRezervacije.OrderBy(a => a.Rezervirano).FirstOrDefault();
            var clanskaIskaznica = najranijaRezervacija.ClanskaIskaznica;
            _context.Remove(najranijaRezervacija);
            _context.SaveChanges();

            Posudi(gradjaId, clanskaIskaznica.Id);
        }
    }
}
