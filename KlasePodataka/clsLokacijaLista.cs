using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class clsLokacijaLista
    {
        // atributi
        private List<clsLokacija> pListaLokacija; 

        // property
        public List<clsLokacija> ListaLokacija
        {
            get
            {
                return pListaLokacija;
            }
            set
            {
                if (this.pListaLokacija != value)
                    this.pListaLokacija = value;
            }
        }

        // konstruktor
        public clsLokacijaLista()
        {
            pListaLokacija = new List<clsLokacija>(); 

        }

        // privatne metode

        // javne metode
        public void DodajElementListe(clsLokacija objNovaLokacija)
        {
            pListaLokacija.Add(objNovaLokacija);
        }

        public void ObrisiElementListe(clsLokacija objLokacijaZaBrisanje)
        {
            pListaLokacija.Remove(objLokacijaZaBrisanje);  
        }

        public void ObrisiElementNaPoziciji(int pozicija)
        {
            pListaLokacija.RemoveAt(pozicija);
        }

        public void IzmeniElementListe(clsLokacija objStaraLokacija, clsLokacija objNovaLokacija)
        {
            int indexStareLokacije = 0;
            indexStareLokacije = pListaLokacija.IndexOf(objStaraLokacija);
            pListaLokacija.RemoveAt(indexStareLokacije);
            pListaLokacija.Insert(indexStareLokacije, objNovaLokacija);   
        }

           

     




    }
}
