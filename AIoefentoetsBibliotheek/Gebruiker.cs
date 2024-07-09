using System;

namespace AIoefentoetsBibliotheek
{
    public abstract class Gebruiker
    {
        private string naam;
        private BibliotheekPas bibliotheekPas;
        private List<Lening> leningen;

        public string Naam
        {
            get { return naam; }
            set { naam = value; }
        }

        public BibliotheekPas BibliotheekPas
        {
            get { return bibliotheekPas; }
            set { bibliotheekPas = value; }
        }

        public List<Lening> Leningen
        {
            get { return leningen; }
        }

        public Gebruiker()
        {
            leningen = new List<Lening>();
        }

        public void VoegLeningToe(Lening lening)
        {
            leningen.Add(lening);
        }

        public abstract int MaximaalAantalBoeken();
        public abstract decimal FilmKostenPerDag();
        public abstract decimal SpelKostenPerDag();
    }

    public class Beginner : Gebruiker
    {
        public override int MaximaalAantalBoeken() => 3;
        public override decimal FilmKostenPerDag() => 0.30m;
        public override decimal SpelKostenPerDag() => 0.60m;
    }

    public class Pro : Gebruiker
    {
        public override int MaximaalAantalBoeken() => 5;
        public override decimal FilmKostenPerDag() => 0.15m;
        public override decimal SpelKostenPerDag() => 0.30m;
    }

    public class Nerd : Gebruiker
    {
        public override int MaximaalAantalBoeken() => 8;
        public override decimal FilmKostenPerDag() => 0.15m;
        public override decimal SpelKostenPerDag() => 0.30m;
    }


}
