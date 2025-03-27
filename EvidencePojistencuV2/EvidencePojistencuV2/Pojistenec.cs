using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencePojistencuV2
{
    /// <summary>
    /// Reprezentuje pojištěnce s údaji.
    /// </summary>
    class Pojistenec
    {

        /// <summary>
        /// Křestní jméno pojištěnce.
        /// </summary>
        public string Jmeno { get; set; }

        /// <summary>
        /// Příjmení pojištěnce.
        /// </summary>
        public string Prijmeni { get; set; }

        /// <summary>
        /// Vrací celé jméno pojištěnce.
        /// </summary>
        public string CeleJmeno => Jmeno + " " + Prijmeni;

        /// <summary>
        /// Věk pojištěnce.
        /// </summary>
        public int Vek { get; set; }

        /// <summary>
        /// Telefonní číslo pojištěnce.
        /// </summary>
        public string TelefoniCislo { get; set; }

        /// <summary>
        /// Konstruktor pro vytvoření instance pojištěnce.
        /// </summary>
        /// <param name="jmeno">Křestní jméno pojištěnce.</param>
        /// <param name="prijmeni">Příjmení pojištěnce.</param>
        /// <param name="telCislo">Telefonní číslo pojištěnce.</param>
        /// <param name="vek">Věk pojištěnce.</param>
        public Pojistenec(string jmeno, string prijmeni, string telCislo, int vek)
        {
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            Vek = vek;
            TelefoniCislo = telCislo;
        }

        /// <summary>
        ///Vrací textovou reprezentaci pojištěnce.
        /// </summary>
        /// <returns>Řetězec obsahující celé jméno, věk a telefonní číslo.</returns>
        public override string ToString()
        {
            return $"{CeleJmeno} {Vek} {TelefoniCislo}";
        }
    }
}
