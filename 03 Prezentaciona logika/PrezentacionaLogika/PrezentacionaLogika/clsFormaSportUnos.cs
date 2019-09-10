using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using KlasePodataka;

//using PoslovnaLogika;

namespace PrezentacionaLogika
{
    public class clsFormaSportUnos
    {
        // atributi
        private string pStringKonekcije;
        private string pIDSporta;
        private string pNazivSporta;
        private string pDatumTreninga;
        private string pNazivLokacije;
        private string pIDLokacije;

    

        // property

        public string IDSporta
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
        
        public string NazivLokacije
        {
            get { return pNazivLokacije; }
            set { pNazivLokacije = value; }
        }

        public string IDLokacije
        {
            get { return pIDLokacije; }
            set { pIDLokacije = value; }
        }
        
        // konstruktor
        public clsFormaSportUnos(string NoviStringKonekcije)
        {
            pStringKonekcije = NoviStringKonekcije;
        }

        // private metode

        // public metode
        public DataSet DajPodatkeZaCombo()
        {
            DataSet dsPodaci = new DataSet();
            clsLokacijaDB objLokacijaDB = new clsLokacijaDB(pStringKonekcije);

            dsPodaci = objLokacijaDB.DajSveLokacije(); 
            
            return dsPodaci;
        }

        public bool DaLiJeSvePopunjeno()
        {
            bool SvePopunjeno = false;


            if ((pIDSporta.Length > 0) && (pNazivSporta.Length > 0) && (pDatumTreninga.Length > 0) && (pNazivLokacije.Length > 0) && (!pNazivLokacije.Equals("Izaberite...")))
            {
                SvePopunjeno = true;
            }
            else
            {
                SvePopunjeno = false;
            }

            return SvePopunjeno;
        }


        public bool DaLiJeJedinstvenZapis()
        {
            bool JedinstvenZapis = false;
            DataSet dsPodaci = new DataSet();
            clsSportDB objSportDB = new clsSportDB(pStringKonekcije);
            dsPodaci = objSportDB.DajSportPoIDSporta(int.Parse(pIDSporta));
            
            if (dsPodaci.Tables[0].Rows.Count == 0)
            {
                JedinstvenZapis = true;
            }
            else
            {
                JedinstvenZapis = false;
            }

            return JedinstvenZapis;

        }

        public bool SnimiPodatke()
        {
            bool uspehSnimanja = false;

            clsSportDB objSportDB = new clsSportDB(pStringKonekcije);

            clsSport objNoviSport = new clsSport();
            objNoviSport.IDSporta = int.Parse(pIDSporta);
            objNoviSport.NazivSporta = pNazivSporta;
            objNoviSport.DatumTreninga = pDatumTreninga;


            clsLokacija objLokacija = new clsLokacija();

            clsLokacijaDB objLokacijaDB = new clsLokacijaDB(pStringKonekcije);
            objLokacija.Sifra = pIDLokacije;
            objLokacija.Naziv = pNazivLokacije;

            objNoviSport.Lokacija = objLokacija;

            uspehSnimanja = objSportDB.SnimiNoviSport(objNoviSport);


            return uspehSnimanja;
        }

        public bool DaLiSuPodaciUskladjeniSaPoslovnimPravilima()
        {
            
            bool UskladjeniPodaci = false;

            clsPoslovnaPravila objPoslovnaPravila = new clsPoslovnaPravila(pStringKonekcije);


            clsLokacijaDB objLokacijaDB = new clsLokacijaDB(pStringKonekcije);


            UskladjeniPodaci = objPoslovnaPravila.DaLiImaMestaZaDodavanjeSporta(IDLokacije);

            return UskladjeniPodaci;
        }

        
    }
}
