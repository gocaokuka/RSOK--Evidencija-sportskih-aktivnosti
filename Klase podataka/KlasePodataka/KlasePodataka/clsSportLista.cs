using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class clsSportLista
    {

        // atributi
        private List<clsSport> pListaSportova; 

        // property
        public List<clsSport> ListaSportova
        {
            get
            {
                return pListaSportova;
            }
            set
            {
                if (this.pListaSportova != value)
                    this.pListaSportova = value;
            }
        }

        // konstruktor
        public clsSportLista()
        {
            pListaSportova = new List<clsSport>(); 

        }

        // privatne metode

        // javne metode
        public void DodajElementListe(clsSport objNoviSport)
        {
            pListaSportova.Add(objNoviSport);
        }

        public void ObrisiElementListe(clsSport objSportZaBrisanje)
        {
            pListaSportova.Remove(objSportZaBrisanje);  
        }

        public void ObrisiElementNaPoziciji(int pozicija)
        {
            pListaSportova.RemoveAt(pozicija);
        }

        public void IzmeniElementListe(clsSport objStariSport, clsSport objNoviSport)
        {
            int indexStarogSporta = 0;
            indexStarogSporta = pListaSportova.IndexOf(objNoviSport);
            pListaSportova.RemoveAt(indexStarogSporta);
            pListaSportova.Insert(indexStarogSporta, objNoviSport);   
        }

           
    }
}
