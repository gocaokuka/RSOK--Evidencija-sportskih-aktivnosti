using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using KlasePodataka;

namespace PrezentacionaLogika
{
    public class clsFormaLokacijaStampa
    {

        // atributi
        private string pStringKonekcije;

        // property

        // konstruktor
        public clsFormaLokacijaStampa(string NoviStringKonekcije)
        {
            pStringKonekcije = NoviStringKonekcije;
        }

        // private metode

        // public metode
        public DataSet DajPodatkeZaGrid(string filter)
        {
            DataSet dsPodaci = new DataSet();
            clsLokacijaDB objLokacijaDB = new clsLokacijaDB(pStringKonekcije);            
            if (filter.Equals(""))
            {
                dsPodaci = objLokacijaDB.DajSveLokacije(); 
            }
            else
            {
                dsPodaci = objLokacijaDB.DajLokacijuPoNazivu(filter); 
            }
            return dsPodaci;
        }
    }
}
