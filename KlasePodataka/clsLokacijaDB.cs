using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using System.Data.SqlClient;
//OVO SE KORISTI KOD WEB APP using System.Configuration; 

namespace KlasePodataka
{
    public class clsLokacijaDB
    {
        // atributi
        private string pStringKonekcije;

        // property
        // 1. nacin
        public string StringKonekcije
        {
            get
            {
                return pStringKonekcije;
            }
            set // OVO NIJE DOBRO, MOZE SE STRING KONEKCIJE STAVITI NA PRAZAN STRING
            {
                if (this.pStringKonekcije != value)
                    this.pStringKonekcije = value;
            }
        }
        // konstruktor
        // 2. nacin prijema vrednosti stringa konekcije spolja i dodele atributu
        public clsLokacijaDB(string NoviStringKonekcije)
        // OVO JE DOBRO JER OBAVEZUJE DA SE PRILIKOM INSTANCIRANJA OVE KLASE
        // MORA OBEZBEDITI STRING KONEKCIJE
        {
            pStringKonekcije = NoviStringKonekcije; 
        }

        // privatne metode

        // javne metode
        public DataSet DajSveLokacije()
        {
            // MOGU biti jos neke procedure, mogu SE VRATITI VREDNOSTI I U LISTU, DATA TABLE...
            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajSveLokacije", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();
            
            return dsPodaci;
        }


        public DataSet DajLokacijuPoNazivu(string Naziv)
        {
            // MOGU biti jos neke procedure, mogu SE VRATITI VREDNOSTI I U LISTU, DATA TABLE...
            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajLokacijuPoNazivu", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@Naziv", SqlDbType.NVarChar).Value = Naziv;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();

            return dsPodaci;
        }

        // overloading metoda - isto se zove, ima drugaciji parametar
        public DataSet DajLokacijuPoNazivu(clsLokacija objLokacijaZaFilter)
        {
            // MOGU biti jos neke procedure, mogu SE VRATITI VREDNOSTI I U LISTU, DATA TABLE...
            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajLokacijuPoNazivu", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@Naziv", SqlDbType.NVarChar).Value = objLokacijaZaFilter.Naziv;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();

            return dsPodaci;
        }

        public bool SnimiNovuLokaciju(clsLokacija objNovaLokacija)
        {
            // LOKALNE PROMENLJIVE UVEK NA VRHU
            int brojSlogova =0;
            // 1. varijanta - skolska 
            //bool uspehSnimanja= false;

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("DodajNovuLokaciju", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@Sifra", SqlDbType.Char).Value = objNovaLokacija.Sifra;
            Komanda.Parameters.Add("@Naziv", SqlDbType.NVarChar).Value = objNovaLokacija.Naziv;
           
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();

            // NEGATIVNO PITANJE - NIJE DOBRO if (brojSlogova ==0)
            /* 1. VARIJANTA - SKOLSKA
             * if (brojSlogova>0)
            {
                uspehSnimanja=true;
            }
            else
            {
                uspehSnimanja=false;
            }

            return uspehSnimanja;
             */
            
            // 2. varijanta
            return (brojSlogova > 0);

            //3. varijanta
            // NEMA SMISLA, ISTO KAO 2. VARIJANTA
            //return (brojSlogova > 0) ? true : false;
            
            //4. varijanta - NEGACIJA NEGACIJE, NIJE RAZUMLJIVO 
            //return (brojSlogova == 0) ? false : true;
            
        }

        public bool ObrisiLokaciju(clsLokacija objLokacijaZaBrisanje)
        {
            // LOKALNE PROMENLJIVE UVEK NA VRHU
            int brojSlogova = 0;
            // 1. varijanta - skolska 
            //bool uspehSnimanja= false;

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("ObrisiLokaciju", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@Sifra", SqlDbType.Char).Value = objLokacijaZaBrisanje.Sifra;
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();

            return (brojSlogova > 0);

         }

        // method overloading - ista procedura sa razlicitim parametrom
        public bool ObrisiLokaciju(string SifraLokacijeZaBrisanje)
        {
            // LOKALNE PROMENLJIVE UVEK NA VRHU
            int brojSlogova = 0;
            // 1. varijanta - skolska 
            //bool uspehSnimanja= false;

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("ObrisiLokaciju", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@Sifra", SqlDbType.Char).Value = SifraLokacijeZaBrisanje;
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();

            return (brojSlogova > 0);

        }

        public bool IzmeniLokaciju(clsLokacija objStaraLokacija, clsLokacija objNovaLokacija)
        {
            // LOKALNE PROMENLJIVE UVEK NA VRHU
            int brojSlogova = 0;
            // 1. varijanta - skolska 
            //bool uspehSnimanja= false;

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("IzmeniLokaciju", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@StaraSifra", SqlDbType.Char).Value = objStaraLokacija.Sifra;
            Komanda.Parameters.Add("@Sifra", SqlDbType.Char).Value = objNovaLokacija.Sifra;
            Komanda.Parameters.Add("@Naziv", SqlDbType.NVarChar).Value = objNovaLokacija.Naziv;
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();

            return (brojSlogova > 0);

        }

        // method overloading - ista metoda, samo drugaciji parametri
        public bool IzmeniLokaciju(string SifraStareLokacije, clsLokacija objNovaLokacija)
        {
            // LOKALNE PROMENLJIVE UVEK NA VRHU
            int brojSlogova = 0;
            // 1. varijanta - skolska 
            //bool uspehSnimanja= false;

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("IzmeniLokaciju", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@StaraSifra", SqlDbType.Char).Value = SifraStareLokacije;
            Komanda.Parameters.Add("@Sifra", SqlDbType.Char).Value = objNovaLokacija.Sifra;
            Komanda.Parameters.Add("@Naziv", SqlDbType.NVarChar).Value = objNovaLokacija.Naziv;
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();

            return (brojSlogova > 0);

        }


    }
}
