using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using System.Data.SqlClient;

namespace KlasePodataka
{
    public class clsSportDB
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
        }
        // konstruktor
        
        public clsSportDB(string NoviStringKonekcije)
       
        {
            pStringKonekcije = NoviStringKonekcije; 
        }

        // privatne metode

        // javne metode
        public DataSet DajSveSportove()
        {
            // MOGU biti jos neke procedure, mogu SE VRATITI VREDNOSTI I U LISTU, DATA TABLE...
            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajSveSportoveSaJoin", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();
            
            return dsPodaci;
        }

        public DataSet DajSportPoNazivuSporta(string NazivSporta)
        {
            // MOGU biti jos neke procedure, mogu SE VRATITI VREDNOSTI I U LISTU, DATA TABLE...
            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajSportPoNazivuSporta", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@SportNazivSporta", SqlDbType.NVarChar).Value = NazivSporta;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();

            return dsPodaci;
        }


        public DataSet DajSportPoIDSporta(int IDSporta)
        {
            // MOGU biti jos neke procedure, mogu SE VRATITI VREDNOSTI I U LISTU, DATA TABLE...
            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajSportPoIDSporta", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@SportIDSporta", SqlDbType.Int).Value = IDSporta;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();

            return dsPodaci;
        }



        private clsSportLista DajListuSvihSportova()
        {
            // PRIPREMA PROMENLJIVIH
            clsSportLista objSportLista = new clsSportLista();
            DataSet dsPodaciSporta = new DataSet();
            clsSport objSport;
            clsLokacija objLokacija;

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajSveSportoveSaJoinSifromLokacije", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaciSporta);
            Veza.Close();
            Veza.Dispose();

            // FORMIRANJE OBJEKATA I UBACIVANJE U LISTU
            for (int brojac = 0; brojac < dsPodaciSporta.Tables[0].Rows.Count; brojac++)
            {
                objLokacija = new clsLokacija();
                objLokacija.Sifra = dsPodaciSporta.Tables[0].Rows[brojac].ItemArray[4].ToString();
                objLokacija.Naziv = dsPodaciSporta.Tables[0].Rows[brojac].ItemArray[3].ToString();

                objSport = new clsSport();
                objSport.IDSporta = int.Parse(dsPodaciSporta.Tables[0].Rows[brojac].ItemArray[0].ToString());
                objSport.NazivSporta = dsPodaciSporta.Tables[0].Rows[brojac].ItemArray[0].ToString();
                objSport.DatumTreninga = dsPodaciSporta.Tables[0].Rows[brojac].ItemArray[0].ToString();
                objSport.Lokacija = objLokacija;
                objSportLista.DodajElementListe (objSport);
            }

            return objSportLista;
        }
        

        public bool SnimiNoviSport(clsSport objNoviSport)
        {
            // LOKALNE PROMENLJIVE UVEK NA VRHU
            int brojSlogova =0;

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("DodajNoviSport", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@IDSporta", SqlDbType.Char).Value = objNoviSport.IDSporta;
            Komanda.Parameters.Add("@NazivSporta", SqlDbType.NVarChar).Value = objNoviSport.NazivSporta;
            Komanda.Parameters.Add("@DatumTreninga", SqlDbType.Date).Value = objNoviSport.DatumTreninga;
            Komanda.Parameters.Add("@IDLokacija", SqlDbType.Char).Value = objNoviSport.Lokacija.Sifra;
            
           
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();
     
            // 2. varijanta
            return (brojSlogova > 0);

        }

        public bool ObrisiSport(string IDSportaSportaZaBrisanje)
        {
            // LOKALNE PROMENLJIVE UVEK NA VRHU
            int brojSlogova = 0;
            // 1. varijanta - skolska 
            //bool uspehSnimanja= false;

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("ObrisiSport", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@IDSporta", SqlDbType.Int).Value = IDSportaSportaZaBrisanje;
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();

            return (brojSlogova > 0);

        }

        public bool IzmeniSport(clsSport objStariSport, clsSport objNoviSport)
        {
            // LOKALNE PROMENLJIVE UVEK NA VRHU
            int brojSlogova = 0;
            // 1. varijanta - skolska 
            //bool uspehSnimanja= false;

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("IzmeniSport", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@StariIDSporta", SqlDbType.Char).Value = objStariSport.IDSporta;
            Komanda.Parameters.Add("@IDSporta", SqlDbType.Char).Value = objNoviSport.IDSporta;
            Komanda.Parameters.Add("@NazivSporta", SqlDbType.NVarChar).Value = objNoviSport.NazivSporta;
            Komanda.Parameters.Add("@DatumTreninga", SqlDbType.NVarChar).Value = objNoviSport.DatumTreninga;
            Komanda.Parameters.Add("@IDLokacija", SqlDbType.Char).Value = objNoviSport.Lokacija.Sifra;
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();

            return (brojSlogova > 0);

        }

        


    }
}
