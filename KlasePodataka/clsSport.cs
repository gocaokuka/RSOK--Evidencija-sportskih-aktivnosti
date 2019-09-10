using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class clsSport
    {
        // atributi
        private int pIDSporta;
        private string pNazivSporta;
        private string pDatumTreninga;
        private string IDLokacije;
        private clsLokacija objLokacija;


        // property
        public int IDSporta
        {
            get { return pIDSporta; }
            set { pIDSporta = value; }
        }



        public string NazivSporta
        {
            get { return pNazivSporta; }
            set { pNazivSporta = value; }
        }



        public string DatumTreninga
        {
            get { return pDatumTreninga; }
            set { pDatumTreninga = value; }
        }

        public string IDLokacije1
        {
            get { return IDLokacije; }
            set { IDLokacije = value; }
        }


        public clsLokacija Lokacija
        {
            get { return objLokacija; }
            set { objLokacija = value; }
        }
    }
}
