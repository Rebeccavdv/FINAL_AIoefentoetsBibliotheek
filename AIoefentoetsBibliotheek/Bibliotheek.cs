using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIoefentoetsBibliotheek
{
    public class BibliotheekPas
    {
        public string PasType { get; set; }
        public DateTime GeldigTot { get; set; }

        public BibliotheekPas(string pasType, DateTime geldigTot)
        {
            PasType = pasType;
            GeldigTot = geldigTot;
        }
    }

    public class Bibliotheek
    {
        private static Bibliotheek? _instance;
        public List<Item> Items { get; private set; }
        public List<Gebruiker> Gebruikers { get; private set; }

        private Bibliotheek()
        {
            Items = new List<Item>();
            Gebruikers = new List<Gebruiker>();
        }

        public static Bibliotheek GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Bibliotheek();
            }
            return _instance;
        }

        public void VoegItemToe(Item item)
        {
            Items.Add(item);
        }

        public void VoegGebruikerToe(Gebruiker gebruiker)
        {
            Gebruikers.Add(gebruiker);
        }

        public Item ZoekItem(string titel)
        {
            return Items.FirstOrDefault(i => i.Titel.Equals(titel, StringComparison.OrdinalIgnoreCase));
        }

        public void LeenItem(string titel, Gebruiker gebruiker, int dagen)
        {
            var item = ZoekItem(titel);
            if (item == null) throw new InvalidOperationException("Item niet gevonden.");
            item.Leen(dagen);

            var lening = new Lening
            {
                Item = item,
                Gebruiker = gebruiker,
                LeenDatum = DateTime.Now,
                InleverDatum = DateTime.Now.AddDays(dagen)
            };

            gebruiker.VoegLeningToe(lening);
        }
    }

}
