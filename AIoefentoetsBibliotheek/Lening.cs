using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIoefentoetsBibliotheek
{
    public class Lening
    {
        public Item Item { get; set; }
        public Gebruiker Gebruiker { get; set; }
        public DateTime LeenDatum { get; set; }
        public DateTime InleverDatum { get; set; }

        public string GetLeningDetails()
        {
            return $"Item: {Item.Titel}, Geleend door: {Gebruiker.Naam}, Leendatum: {LeenDatum}, Inleverdatum: {InleverDatum}";
        }

        public decimal BerekenTeLaatKosten()
        {
            if (DateTime.Now <= InleverDatum) return 0;

            int teLateDagen = (DateTime.Now - InleverDatum).Days;
            return teLateDagen * 0.05m; // 0.05 per dag te laat
        }
    }

}
