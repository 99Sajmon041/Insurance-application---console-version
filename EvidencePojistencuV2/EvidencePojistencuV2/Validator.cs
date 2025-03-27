using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencePojistencuV2
{

    /// <summary>
    /// Třída pro validaci vstupních údajů pojištěnce.
    /// </summary>
    public static class Validator
    {

        /// <summary>
        /// Výčet typů údajů, které lze validovat (jméno, příjmení).
        /// </summary>
        public enum TypUdaje { jmeno, prijmeni };

        /// <summary>
        /// Uchovává zvolený typ údaje pro validaci.
        /// </summary>
        public static TypUdaje _TypUdaje { get; set; }

        /// <summary>
        /// Ověřuje, zda jméno nebo příjmení není prázdné a obsahuje alespoň dva znaky.
        /// </summary>
        /// <param name="jmenoPrijmeni">Text představující jméno nebo příjmení.</param>
        /// <returns>Vrací true, pokud je vstup validní, jinak false.</returns>
        public static bool OverJmenoPrijmeni(string jmenoPrijmeni)
        {
            if (string.IsNullOrWhiteSpace(jmenoPrijmeni) || jmenoPrijmeni.Length < 2)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Ověřuje, zda zadaný věk je číslo v rozmezí 0 až 110 let.
        /// </summary>
        /// <param name="vek">Text představující věk.</param>
        /// <returns>Vrací true, pokud je vstup validní, jinak false.</returns>
        public static bool OverVek(string vek)
        {
            int vyslednyVek;
            if (!int.TryParse(vek, out vyslednyVek) || vyslednyVek < 0 || vyslednyVek > 110)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Ověřuje, zda telefonní číslo obsahuje přesně 9 číslic a obsahuje jiné znaky, nežli číslo.
        /// </summary>
        /// <param name="telefoniCislo">Text představující telefonní číslo.</param>
        /// <returns>Vrací true, pokud je telefonní číslo validní, jinak false.</returns>
        public static bool OverTelefon(string telefoniCislo)
        {
            if (telefoniCislo.Length == 9 && telefoniCislo.All(char.IsDigit))
            {
                return true;
            }
            return false;
        }
    }
}
