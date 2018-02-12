using KnjizniceData.Models;
using System.Collections.Generic;

namespace KnjizniceData
{
    public interface IClan
    {
        IEnumerable<Clan> GetAll();
        Clan Get(int id);
        void Add(Clan newClan);
        IEnumerable<PovijestPosudbi> GetPovijestPosudbi(int clanId);
        IEnumerable<Rezervacije> GetRezervacije(int clanId);
        IEnumerable<Posudbe> GetPosudbe(int id);
    }
}
