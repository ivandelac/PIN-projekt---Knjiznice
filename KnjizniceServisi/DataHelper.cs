using System;
using System.Collections.Generic;
using KnjizniceData.Models;

namespace KnjizniceServisi
{
    public class DataHelper
    {
        public static IEnumerable<string>
               HumanizeBusinessHours(IEnumerable<RadnoVrijeme> radnoVrijeme)
        {
            var sati = new List<string>();

            foreach (var vrijeme in radnoVrijeme)
            {
                var DanTjedna = HumanizeDayOfWeek(vrijeme.DanTjedna);
                var VrijemeOtvaranja = HumanizeTime(vrijeme.VrijemeOtvaranja);
                var VrijemeZatvaranja = HumanizeTime(vrijeme.VrijemeZatvaranja);
                var unosVremena = $"{DanTjedna} {VrijemeOtvaranja} to {VrijemeZatvaranja}";
                sati.Add(unosVremena);
            };

            return sati;
        }

        private static string HumanizeDayOfWeek(int number)
        {
            return Enum.GetName(typeof(DayOfWeek), number);
        }

        private static string HumanizeTime(int time)
        {
            TimeSpan result = TimeSpan.FromHours(time);
            return result.ToString("hh':'mm");
        }
    }
}