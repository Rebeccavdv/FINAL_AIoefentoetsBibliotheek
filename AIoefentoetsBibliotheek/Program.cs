namespace AIoefentoetsBibliotheek
{
    internal class Program
    {
        static void Main()
        {
            // Initialiseer de bibliotheek
            Bibliotheek bibliotheek = Bibliotheek.GetInstance();

            // Voeg items toe aan de bibliotheek
            bibliotheek.VoegItemToe(new Boek { Titel = "De Hobbit", Auteur = "J.R.R. Tolkien" });
            bibliotheek.VoegItemToe(new Film { Titel = "Inception", Regisseur = "Christopher Nolan" });
            bibliotheek.VoegItemToe(new Spel { Titel = "The Witcher 3", Platform = "PC" });

            // Voeg gebruikers toe aan de bibliotheek
            var gebruiker1 = new Beginner { Naam = "Jan", BibliotheekPas = new BibliotheekPas("Beginner", DateTime.Now.AddYears(1)) };
            var gebruiker2 = new Pro { Naam = "Piet", BibliotheekPas = new BibliotheekPas("Pro", DateTime.Now.AddYears(1)) };
            var gebruiker3 = new Nerd { Naam = "Klaas", BibliotheekPas = new BibliotheekPas("Nerd", DateTime.Now.AddYears(1)) };

            bibliotheek.VoegGebruikerToe(gebruiker1);
            bibliotheek.VoegGebruikerToe(gebruiker2);
            bibliotheek.VoegGebruikerToe(gebruiker3);

            // Leen items uit
            try
            {
                bibliotheek.LeenItem("De Hobbit", gebruiker1, 14);
                bibliotheek.LeenItem("Inception", gebruiker2, 7);
                bibliotheek.LeenItem("The Witcher 3", gebruiker3, 21);

                Console.WriteLine("Items succesvol geleend.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fout bij lenen: {ex.Message}");
            }

            // Lening details en te laat kosten berekening
            foreach (var lening in gebruiker1.Leningen)
            {
                Console.WriteLine(lening.GetLeningDetails());
                Console.WriteLine($"Te laat kosten: {lening.BerekenTeLaatKosten()} EUR");
            }
        }
    }


}
