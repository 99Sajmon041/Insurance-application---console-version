namespace EvidencePojistencuV2
{
    internal class Program
    {
        /// <summary>
        ///Hlavní vstup aplikace
        /// </summary>
        static void Main(string[] args)
        {
            // Vytvoření instance uživatelského rozhraní
            UzivatelskeRozhrani uRozhrani = new UzivatelskeRozhrani();
            char vstupUzivatele;
            // Hlavní smyčka programu
            do
            {
                // Zobrazení hlavního menu
                uRozhrani.VypisObrazovku();
                uRozhrani.VypisPoVypisuAkce();

                // Čtení vstupu od uživatele
                vstupUzivatele = Console.ReadKey().KeyChar;
                Console.WriteLine();

                // Vyhodnocení volby uživatele
                switch (vstupUzivatele)
                {
                    case '1':
                        Console.Clear();
                        uRozhrani.PridejPojistence();
                        break;
                    case '2':
                        Console.Clear();
                        uRozhrani.VypisAktivniPojistence();
                        break;
                    case '3':
                        Console.Clear();
                        uRozhrani.NajdiPojistence();
                        break;
                    case '4':
                        Console.Clear();
                        uRozhrani.UpravPojistence();
                        break;
                    case '5':
                        Console.Clear();
                        uRozhrani.OdeberPojistence();
                        break;
                    case '6':
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Zadal jste neplatnou hodnotu !");
                        break;
                }
            }
            while (vstupUzivatele != '6'); // Ukončení smyčky při volbě '6'
            Console.WriteLine("Děkujeme za použití aplikace :-)");
            Console.ReadKey();
        }
    }
}
