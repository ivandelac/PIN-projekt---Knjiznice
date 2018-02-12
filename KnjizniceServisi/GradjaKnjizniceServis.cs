using KnjizniceData;
using KnjizniceData.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace KnjizniceServisi
{
    public class GradjaKnjizniceServis : IGradjaKnjiznice  //implement interface-a i onda scaffoldamo metode iz interface-a (svaka metoda dohvaća instancu GradjaKnjiznice tablice)
    {
        
        private KnjizniceContext _context; //spremamo taj context u private field

        public GradjaKnjizniceServis(KnjizniceContext context) //ovoj klasi dodjeljujemo konstruktor koji koristi DbContext kojeg smo spremili u private field
        {
            _context = context;  //ovaj kontekst sada možemo koristiti za manipulaciju podataka iz baze
        }



        public void Add(GradjaKnjiznice newGradja)
        {
            _context.Add(newGradja);
            _context.SaveChanges();
        }

        public IEnumerable<GradjaKnjiznice> GetAll()
        {
            return _context.GradjaKnjiznice //query bez LINQa
                .Include(Gradja => Gradja.Status)
                .Include(Gradja => Gradja.Lokacija);
        }

        
        public GradjaKnjiznice GetById(int id)
        {
            return GetAll().FirstOrDefault(Gradja => Gradja.Id == id);   //LINQ query
            
        }

        public Knjiznica GetCurrentLokacija(int id)
        {
            return GetById(id).Lokacija;

            //return _context.GradjaKnjiznice. FirstOrDefult(gradja => gradja == gradja.Id).Location  - isti query, samo nije LINQ
        }

        public string GetISBN(int id)
        {
            if (_context.Knjige.Any(a => a.Id == id))
                {
                return _context.Knjige
                    .FirstOrDefault(a => a.Id == id).ISBN;
            }
            else return "";
        }

        public string GetNaslov(int id)
        {
            return _context.GradjaKnjiznice.FirstOrDefault(a => a.Id == id).Naslov;
        }

        public string GetVrsta(int id)
        {
            var knjiga = _context.GradjaKnjiznice.OfType<Knjiga>()
                .Where(b => b.Id == id);

            return knjiga.Any() ? "Knjiga" : "Video";
       
        }

        public string GetAutorOrRedatelj(int id)
        {
            var isKnjiga = _context.GradjaKnjiznice.OfType<Knjiga>()
                .Where(Gradja => Gradja.Id == id).Any();

            var isVideo = _context.GradjaKnjiznice.OfType<Video>() //ova varijabla nije potrebna (tu je radi prakse u sintaksi :))
                .Where(Gradja => Gradja.Id == id).Any();

            //ternary operator - returns one of two values depending on the value of a Boolean expression
            //condition ? a : b ("is condition true? then a, else b")

            return isKnjiga ?
                _context.Knjige.FirstOrDefault(Knjiga => Knjiga.Id == id).Autor :
                _context.Filmovi.FirstOrDefault(Video => Video.Id == id).Redatelj
                ?? "Nepoznata građa"; // u slučaju da nam ne vrati ništa iz prethodna 2 uvjeta
        }
    }
}
