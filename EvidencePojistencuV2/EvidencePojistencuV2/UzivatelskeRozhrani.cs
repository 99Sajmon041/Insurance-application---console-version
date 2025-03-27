using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencePojistencuV2
{

    /// <summary>
    /// Třída sloužící jako uživatelské rozhraní pro správu pojištěnců.
    /// Poskytuje metody pro přidání, odebrání, vyhledání a úpravu pojištěnců.
    /// </summary>
    class UzivatelskeRozhrani
    {
        private SpravcePojistencu spravaPojistencu;

        /// <summary>
        /// Konstruktor inicializující správce pojištěnců a nastavující události.
        /// </summary>
        public UzivatelskeRozhrani()
        {
            spravaPojistencu = new SpravcePojistencu();
            spravaPojistencu.PridejPojistenceHandler += VypisPridanehoPojistence;
            spravaPojistencu.OdeberPojistenceHandler += VypisOdebranehoPojistence;
            spravaPojistencu.UpravPojistenceHandler += VypisUpravenehoPojistence;
            spravaPojistencu.NeexistujiciPojistenecInfo += () => Console.WriteLine("Pojištěnec s takovými údaji nenalezen");
        }

        /// <summary>
        /// Přidá nového pojištěnce do evidence.
        /// </summary>
        public void PridejPojistence()
        {
            spravaPojistencu.PridejNovehoPojistnece(VratJmenoPrijmeni(Validator.TypUdaje.jmeno), VratJmenoPrijmeni(Validator.TypUdaje.prijmeni), VratTelefon(), VratVek());
            VypisPoVypisuAkce();
        }

        /// <summary>
        /// Vypíše seznam všech pojištěnců v evidenci.
        /// </summary>
        public void VypisAktivniPojistence()
        {
            if (OverPocetUzivatelu())
            {
                List<Pojistenec> pojistenci = spravaPojistencu.VypisVsechnyPojistence();
                foreach (Pojistenec pojistenec in pojistenci)
                {
                    Console.WriteLine(pojistenec);
                }
            }
            else
            {
                ZadniPojistenciUpozorneni();
            }
            VypisPoVypisuAkce();
        }

        /// <summary>
        /// Vyhledá a vypíše pojištěnce podle jména a příjmení.
        /// </summary>
        public void NajdiPojistence()
        {
            if (OverPocetUzivatelu())
            {

                Console.WriteLine($"\n{spravaPojistencu.VypisHledanehoPojistence(VratJmenoPrijmeni(Validator.TypUdaje.jmeno), VratJmenoPrijmeni(Validator.TypUdaje.prijmeni))}");
            }
            else
            {
                ZadniPojistenciUpozorneni();
            }
            VypisPoVypisuAkce();
        }

        /// <summary>
        /// Upraví údaje existujícího pojištěnce.
        /// </summary>
        public void UpravPojistence()
        {
            if (OverPocetUzivatelu())
            {
                Pojistenec? upravovanyPojistenec = spravaPojistencu.VypisHledanehoPojistence(VratJmenoPrijmeni(Validator.TypUdaje.jmeno), VratJmenoPrijmeni(Validator.TypUdaje.prijmeni));
                if (upravovanyPojistenec != null)
                {
                    Console.WriteLine("Upravte údaje pojištěnce:\n");
                    spravaPojistencu.UpravExistujicihoPojistence(upravovanyPojistenec, VratJmenoPrijmeni(Validator.TypUdaje.jmeno), VratJmenoPrijmeni(Validator.TypUdaje.prijmeni), VratTelefon(), VratVek());
                }
            }
            else
            {
                ZadniPojistenciUpozorneni();
            }
            VypisPoVypisuAkce();
        }

        /// <summary>
        /// Odebere pojištěnce ze seznamu.
        /// </summary>
        public void OdeberPojistence()
        {
            if (OverPocetUzivatelu())
            {
                spravaPojistencu.OdeberExistujicihoPojistence(VratJmenoPrijmeni(Validator.TypUdaje.jmeno), VratJmenoPrijmeni(Validator.TypUdaje.prijmeni));
            }
            else
            {
                ZadniPojistenciUpozorneni();
            }
            VypisPoVypisuAkce();
        }

        /// <summary>
        /// Načte validované jméno nebo příjmení od uživatele.
        /// </summary>
        private string VratJmenoPrijmeni(Validator.TypUdaje _jmenoPrijmeni)
        {
            string jmenoPrijmeni;
            do
            {
                if (_jmenoPrijmeni == Validator.TypUdaje.jmeno)
                {
                    Console.WriteLine("Zajdejte jméno pojištěnce:");
                }
                else
                {
                    Console.WriteLine("Zajdete přijímení pojištěnce:");
                }
                jmenoPrijmeni = Console.ReadLine()?.Trim() ?? "";
            }
            while (!Validator.OverJmenoPrijmeni(jmenoPrijmeni));
            return jmenoPrijmeni;
        }

        /*
        private string VratJmeno()
        {
            string jmeno;
            do
            {
                Console.WriteLine("Zajdejte jméno pojištěnce:");
                jmeno = Console.ReadLine()?.Trim() ?? "";
            }
            while (!validator.OverJmenoPrijmeni(jmeno));
            return jmeno;
        }
        private string VratPrijmeni()
        {
            string prijmeni;
            do
            {
                Console.WriteLine("Zajdete přijímení pojištěnce:");
                prijmeni = Console.ReadLine()?.Trim() ?? "";
            }
            while (!validator.OverJmenoPrijmeni(prijmeni));
            return prijmeni;
        }
        */

        /// <summary>
        /// Načte validovaný věk od uživatele.
        /// </summary>
        private int VratVek()
        {
            string vek;
            do
            {
                Console.WriteLine("Zajdete věk pojištěnce:");
                vek = Console.ReadLine()?.Trim() ?? "";
            }
            while (!Validator.OverVek(vek));
            return int.Parse(vek);
        }

        /// <summary>
        /// Načte validované telefonní číslo od uživatele.
        /// </summary>
        private string VratTelefon()
        {
            string telefon;
            do
            {
                Console.WriteLine("Zadejte telefonní číslo pojištěnce:");
                telefon = Console.ReadLine()?.Trim() ?? "";
            }
            while (!Validator.OverTelefon(telefon));
            return telefon;
        }

        /// <summary>
        /// Výpis zprávy po přidání pojištěnce.
        /// </summary>
        public void VypisPridanehoPojistence(object? sender, EventArgs e)
        {
            if (sender != null)
                Console.WriteLine($"Pojištěnec {((Pojistenec)sender).CeleJmeno} přidán");
        }

        /// <summary>
        /// Výpis zprávy po odebrání pojištěnce.
        /// </summary>
        public void VypisOdebranehoPojistence(object? sender, EventArgs e)
        {
            if (sender != null)
                Console.WriteLine($"Pojištěnec {((Pojistenec)sender).CeleJmeno} byl odebrán");
        }

        /// <summary>
        /// Výpis zprávy po úpravě pojištěnce.
        /// </summary>
        public void VypisUpravenehoPojistence(object? sender, EventArgs e)
        {
            if (sender != null)
                Console.WriteLine($"Pojištěnec {((Pojistenec)sender).CeleJmeno} byl upraven");
        }

        /// <summary>
        /// Výpis zprávy po každé operaci z důvodu zvolení dalšího vstupu uživatele .
        /// </summary>
        public void VypisPoVypisuAkce()
        {
            Console.WriteLine("\nPokračute stisknutím libovolné klávesy........");
        }

        /// <summary>
        /// Ověří, zda je v evidenci alespoň jeden pojištěnec.
        /// </summary>
        private bool OverPocetUzivatelu() => spravaPojistencu.PocetPojistencu > 0;

        /// <summary>
        /// Upozornění při neexistenci pojištěnců.
        /// </summary>
        private void ZadniPojistenciUpozorneni()
        {
            Console.WriteLine("Nejsou evidování žádní klienti, operace je neplatná !");
        }

        /// <summary>
        /// Zobrazí hlavní nabídku aplikace.
        /// </summary>
        public void VypisObrazovku()
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Evidence pojištěných klientů");
            Console.WriteLine("--------------------------------------------\n");
            Console.WriteLine("Vyberte si akci:\n" +
                "1 - Přidat nového pojištěnce\n" +
                "2 - Vypsat všechny pojištěnce\n" +
                "3 - Vyhledat pojštěnce\n" +
                "4 - Upravit pojištěnce\n" +
                "5 - Odebrat pojištěnce\n" +
                "6 - Ukončit aplikaci");
        }
    }
}
