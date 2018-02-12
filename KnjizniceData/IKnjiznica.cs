using KnjizniceData.Models;
using System.Collections.Generic;

namespace KnjizniceData
{
    public interface IKnjiznica
    {
        IEnumerable<Knjiznica> GetAll();
        IEnumerable<Clan> GetClanovi(int Id);
        IEnumerable<GradjaKnjiznice> GetGradja(int Id);
        Knjiznica Get(int Id);
        void Add(Knjiznica newKnjiznica);
        IEnumerable<string> GetRadnoVrijeme(int Id);
        bool Otvoreno(int Id);
        int GetGradjaCount(IEnumerable<GradjaKnjiznice> gradjaKnjiznice);
        int GetClanoviCount(IEnumerable<Clan> clanovi);
        decimal GetGradjaValue(int id);

    }
}
