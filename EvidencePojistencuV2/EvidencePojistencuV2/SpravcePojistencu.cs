using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EvidencePojistencuV2
{
    /// <summary>
    /// Třída spravující seznam pojištěnců a operace s nimi.
    /// </summary>
    class SpravcePojistencu
    {
        /// <summary>
        /// Seznam pojištěnců
        /// </summary>
        readonly List<Pojistenec> pojistenci = new List<Pojistenec>();
        private Pojistenec? pojistenec;
        /// <summary>
        /// Událost vypisující přídaní pojištěnce
        /// </summary>
        public EventHandler? PridejPojistenceHandler;
        /// <summary>
        /// Událost vypisující odebrání pojištěnce
        /// </summary>
        public EventHandler? OdeberPojistenceHandler;
        /// <summary>
        /// Událost vypisující úpravu pojištěnce
        /// </summary>
        public EventHandler? UpravPojistenceHandler;
        /// <summary>
        /// Událost vypisující, že neexistují žádní pojištěnci
        /// </summary>
        public event Action? NeexistujiciPojistenecInfo;

        /// <summary>
        /// Vlastnost vracející počet pojištěnců.
        /// </summary>
        public int PocetPojistencu
        {
            get
            {
                return pojistenci.Count;
            }
        }

        /// <summary>
        /// Vrátí seznam všech pojištěnců.
        /// </summary>
        public List<Pojistenec> VypisVsechnyPojistence()
        {
            return pojistenci;
        }

        /// <summary>
        /// Přidá nového pojištěnce do seznamu.
        /// </summary>
        public void PridejNovehoPojistnece(string jmeno, string prijmeni, string telefoniCislo, int vek)
        {
            var novyPojistenec = new Pojistenec(jmeno, prijmeni, telefoniCislo, vek);
            pojistenci.Add(novyPojistenec);
            PridejPojistenceHandler?.Invoke(novyPojistenec, EventArgs.Empty);
        }

        /// <summary>
        /// Vyhledá pojištěnce podle jména a příjmení.
        /// </summary>
        public Pojistenec? VypisHledanehoPojistence(string jmeno, string prijmeni)
        {
            pojistenec = null;
            pojistenec = pojistenci.FirstOrDefault(x => x.Jmeno == jmeno && x.Prijmeni == prijmeni);
            if (pojistenec == null)
            {
                NeexistujiciPojistenecInfo?.Invoke();
            }
            return pojistenec;
        }

        /// <summary>
        /// Odebere pojištěnce ze seznamu.
        /// </summary>
        public void OdeberExistujicihoPojistence(string jmeno, string prijmeni)
        {
            Pojistenec? pojistenec = VypisHledanehoPojistence(jmeno, prijmeni);
            if (pojistenec != null)
            {
                pojistenci.Remove(pojistenec);
                OdeberPojistenceHandler?.Invoke(pojistenec, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Upraví informace o existujícím pojištěnci.
        /// </summary>
        public void UpravExistujicihoPojistence(Pojistenec upravovanyPojistenec, string jmeno, string prijmeni, string telefoniCislo, int vek)
        {
            upravovanyPojistenec.Jmeno = jmeno;
            upravovanyPojistenec.Prijmeni = prijmeni;
            upravovanyPojistenec.TelefoniCislo = telefoniCislo;
            upravovanyPojistenec.Vek = vek;
            UpravPojistenceHandler?.Invoke(upravovanyPojistenec, EventArgs.Empty);
        }
    }
}
