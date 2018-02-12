using System.Collections.Generic;
using System.Linq;
using KnjizniceData;
using KnjizniceData.Models;
using Microsoft.EntityFrameworkCore;

namespace KnjizniceServisi
{
    public class ClanServis : IClan
    {
        private KnjizniceContext _context; 

        public ClanServis(KnjizniceContext context)
        {
            _context = context;
        }

        public void Add(Clan newClan)
        {
            _context.Add(newClan);
            _context.SaveChanges();
        }

        public Clan Get(int id)
        {
            return _context.Clanovi
                .Include(a => a.ClanskaIskaznica)
                .Include(a => a.MaticnaKnjiznica)
                .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Clan> GetAll()
        {
            return _context.Clanovi
                .Include(a => a.ClanskaIskaznica)
                .Include(a => a.MaticnaKnjiznica);
        }

        public IEnumerable<Posudbe> GetPosudbe(int id)
        {
            var clanskaIskaznicaId = Get(id).ClanskaIskaznica.Id;
            return _context.Posudbe
                .Include(a => a.ClanskaIskaznica)
                .Include(a => a.GradjaKnjiznice)
                .Where(v => v.ClanskaIskaznica.Id == clanskaIskaznicaId);
        }

        public IEnumerable<PovijestPosudbi> GetPovijestPosudbi(int clanId)
        {
            var clanskaIskaznicaId = _context.Clanovi
                .Include(a => a.ClanskaIskaznica)
                .FirstOrDefault(a => a.Id == clanId)
                .ClanskaIskaznica.Id;

            return _context.PovijestPosudbi
                .Include(a => a.ClanskaIskaznica)
                .Include(a => a.GradjaKnjiznice)
                .Where(a => a.ClanskaIskaznica.Id == clanskaIskaznicaId)
                .OrderByDescending(a => a.Posudjeno);
        }

        public IEnumerable<Rezervacije> GetRezervacije(int clanId)
        {
            var clanskaIskaznicaId = _context.Clanovi
                .Include(a => a.ClanskaIskaznica)
                .FirstOrDefault(a => a.Id == clanId)
                .ClanskaIskaznica.Id;

            return _context.Rezervacije
                .Include(a => a.ClanskaIskaznica)
                .Include(a => a.GradjaKnjiznice)
                .Where(a => a.ClanskaIskaznica.Id == clanskaIskaznicaId)
                .OrderByDescending(a => a.Rezervirano);
        }
    }
}
