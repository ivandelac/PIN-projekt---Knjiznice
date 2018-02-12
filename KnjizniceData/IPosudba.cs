using KnjizniceData.Models;
using System.Collections.Generic;

namespace KnjizniceData
{
    public interface IPosudba
    {
        IEnumerable<Posudbe> GetAll();
        IEnumerable<PovijestPosudbi> GetPovijestPosudbi(int id);
        Posudbe Get(int id);
        void Add(Posudbe newPosudba);
         Posudbe GetLatestPosudba(int id);
        void Rezerviraj(int gradjaId, int clanskaIskaznicaId);
        void Posudi(int gradjaId, int clanskaIskaznicaId);
        void Vrati(int gradjaId);
        int GetBrojPrimjeraka(int id);
        int GetRaspoloziviPrimjerci(int id);
        bool Izdano(int id);

        string GetCurrentClanRezervacija(int id);
        string GetCurrentRezervacija(int id);
        string GetCurrentClan(int id);
        IEnumerable<Rezervacije> GetCurrentRezervacije(int id);

        void OznaciIzgubljeno(int id);
        void OznaciNadjeno(int id);
    }
}