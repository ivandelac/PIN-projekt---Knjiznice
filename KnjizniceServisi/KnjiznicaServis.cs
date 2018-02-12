using System;
using System.Collections.Generic;
using System.Linq;
using KnjizniceData;
using KnjizniceData.Models;
using Microsoft.EntityFrameworkCore;

namespace KnjizniceServisi
{
    public class KnjiznicaServis : IKnjiznica
    {
        private KnjizniceContext _context;

        public KnjiznicaServis(KnjizniceContext context)
        {
            _context = context;
        }

        public void Add(Knjiznica newKnjiznica)
        {
            _context.Add(newKnjiznica);
            _context.SaveChanges();
        }

        public Knjiznica Get(int Id)
        {
            return _context.Knjiznice
                            .Include(b => b.Clanovi)
                            .Include(b => b.GradjaKnjiznice)
                            .FirstOrDefault(p => p.Id == Id);
        }

        public IEnumerable<Knjiznica> GetAll()
        {
            return _context.Knjiznice.Include(a => a.Clanovi).Include(a => a.GradjaKnjiznice);
        }

        public IEnumerable<Clan> GetClanovi(int Id)
        {
            return _context.Knjiznice.Include(a => a.Clanovi).FirstOrDefault(b => b.Id == Id).Clanovi;
        }

        public int GetClanoviCount(IEnumerable<Clan> clanovi)
        {
            if (clanovi == null)
            {
                return 0;
            }

            else return clanovi.Count();
        }

        public IEnumerable<GradjaKnjiznice> GetGradja(int id)
        {
            return _context.Knjiznice.Include(a => a.GradjaKnjiznice)
                .FirstOrDefault(b => b.Id == id)
                .GradjaKnjiznice;
        }

        public int GetGradjaCount(IEnumerable<GradjaKnjiznice> gradjaKnjiznice)
        {
            if (gradjaKnjiznice == null)
            {
                return 0;
            }

            else return gradjaKnjiznice.Count();
        }

        public decimal GetGradjaValue(int id)
        {
            var vrijednostGradje = GetGradja(id).Select(a => a.Cijena);
            return vrijednostGradje.Sum();
        }

        public IEnumerable<string> GetRadnoVrijeme(int id)
        {
            var sati = _context.RadnoVrijeme.Where(a => a.Knjiznica.Id == id);

            var prikaziSate =
                DataHelper.HumanizeBusinessHours(sati);

            return prikaziSate;
        }

        public bool Otvoreno(int Id)
        {
            var trenutnoVrijeme = DateTime.Now;
            return true;
        }
    }
}
