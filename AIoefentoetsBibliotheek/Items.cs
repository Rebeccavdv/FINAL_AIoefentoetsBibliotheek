using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIoefentoetsBibliotheek
{
    public interface ILeenbaar
    {
        void Leen(int dagen);
        void LeverIn();
    }

    public interface IKostBerekenbaar
    {
        decimal BerekenKosten();
    }

    public abstract class Item : ILeenbaar
    {
        private string titel;
        private string auteur;
        private bool isGeleend;

        public string Titel
        {
            get { return titel; }
            set { titel = value; }
        }

        public string Auteur
        {
            get { return auteur; }
            set { auteur = value; }
        }

        public bool IsGeleend
        {
            get { return isGeleend; }
            private set { isGeleend = value; }
        }

        public void Leen(int dagen)
        {
            if (IsGeleend) throw new InvalidOperationException("Item is al geleend.");
            IsGeleend = true;
            // Logica voor lenen
        }

        public void LeverIn()
        {
            if (!IsGeleend) throw new InvalidOperationException("Item is niet geleend.");
            IsGeleend = false;
            // Logica voor inleveren
        }
    }

    public class Boek : Item
    {
        // Extra eigenschappen en methoden voor Boek
    }

    public class Film : Item, IKostBerekenbaar
    {
        private string regisseur;

        public string Regisseur
        {
            get { return regisseur; }
            set { regisseur = value; }
        }

        public decimal BerekenKosten()
        {
            return 0.30m; // voorbeeldkosten
        }
    }

    public class Spel : Item, IKostBerekenbaar
    {
        private string platform;

        public string Platform
        {
            get { return platform; }
            set { platform = value; }
        }

        public decimal BerekenKosten()
        {
            return 0.60m; // voorbeeldkosten
        }
    }
}
