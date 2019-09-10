using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using KlasePodataka;

namespace PrezentacionaLogika
{
    class clsFormaSportSpisak
    {

        // atributi
        private string pStringKonekcije;

        // property

        // konstruktor
        public clsFormaSportSpisak(string NoviStringKonekcije)
        {
            pStringKonekcije = NoviStringKonekcije;
        }

        // private metode

        // public metode
        public DataSet DajPodatkeZaGrid(string filter)
        {
            DataSet dsPodaci = new DataSet();
            clsSportDB objSportDB = new clsSportDB(pStringKonekcije);
            if (filter.Equals(""))
            {
                dsPodaci = objSportDB.DajSveSportove(); 
            }
            else
            {
                dsPodaci = objSportDB.DajSportPoNazivuSporta(filter);
            }
            return dsPodaci;
        }
    }
}
