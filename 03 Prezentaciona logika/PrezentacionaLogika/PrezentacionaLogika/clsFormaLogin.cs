using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using KlasePodataka;
using System.Data;

namespace PrezentacionaLogika
{
    public class clsFormaLogin
    {

        private string pStringKonekcije;

        private string pKorisnickoIme;

        public string KorisnickoIme
        {
            get { return pKorisnickoIme; }
            set { pKorisnickoIme = value; }
        }
        private string pSifra;

        public string Sifra
        {
            get { return pSifra; }
            set { pSifra = value; }
        }

        // konstruktor
        public clsFormaLogin(string NoviStringKonekcije)
        {
            pStringKonekcije = NoviStringKonekcije;
        }


        // javne metode
        public bool VazeciKorisnik()
        {
            bool vazeci = false;

            clsKorisnikDB objKorisnikDB = new clsKorisnikDB(pStringKonekcije);
            DataSet dsPodaci = objKorisnikDB.DajKorisnikaPoKorisnickomImenuISifri(pKorisnickoIme, pSifra);

            if (dsPodaci.Tables[0].Rows.Count > 0)
            // pronasao ga je u bazi
            {
                vazeci = true;
            }
            else
            {
                vazeci = false;
            }

            return vazeci;

        }

        public string DajImePrezimeKorisnika()
        {
            string ImePrezime = "";

            clsKorisnikDB objKorisnikDB = new clsKorisnikDB(pStringKonekcije);
            DataSet dsPodaci = objKorisnikDB.DajKorisnikaPoKorisnickomImenuISifri(pKorisnickoIme, pSifra);

            if (dsPodaci.Tables[0].Rows.Count > 0)
            // pronasao ga je u bazi
            {
                ImePrezime = dsPodaci.Tables[0].Rows[0].ItemArray[2].ToString() + " " + dsPodaci.Tables[0].Rows[0].ItemArray[1].ToString();
            }
            return ImePrezime;

        }



    }
}
