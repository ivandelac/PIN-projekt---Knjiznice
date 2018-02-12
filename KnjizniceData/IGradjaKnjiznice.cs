using KnjizniceData.Models;
using System.Collections.Generic;

namespace KnjizniceData
{
    public interface IGradjaKnjiznice
    {
        IEnumerable<GradjaKnjiznice> GetAll(); //dohvaćanje kompletne građe
        GradjaKnjiznice GetById(int id);  //dohvaćanje građe prema ID-u tj. primary key-u u tablici GradjaKnjiznice

        //metode
        void Add(GradjaKnjiznice newGradja);
        string GetAutorOrRedatelj(int id);
        string GetVrsta(int id);
        string GetNaslov(int id);
        string GetISBN(int id);

        Knjiznica GetCurrentLokacija(int id);

    }
}
