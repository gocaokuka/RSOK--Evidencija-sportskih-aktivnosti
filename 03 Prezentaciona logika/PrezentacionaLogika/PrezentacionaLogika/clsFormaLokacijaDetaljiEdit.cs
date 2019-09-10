using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using KlasePodataka;

namespace PrezentacionaLogika
{
    public class clsFormaLokacijaDetaljiEdit
    {

         // atributi i property
        private string pStringKonekcije;
        private clsLokacijaDB objLokacijaDB;

        private clsLokacijaDB objPreuzetaLokacija;
        private clsLokacijaDB objIzmenjenaLokacija;

        private string pSifraPreuzeteLokacije;
        private string pNazivPreuzeteLokacije;

        private string pSifraIzmenjeneLokacije;
        private string pNazivIzmenjeneLokacije;
        
// PROPERTY

        public string SifraPreuzeteLokacije
        {
            get { return pSifraPreuzeteLokacije; }
            set { pSifraPreuzeteLokacije = value; }
        }

        public string NazivPreuzeteLokacije
        {
            get { return pNazivPreuzeteLokacije; }
           
        }

        public string SifraIzmenjeneLokacije
        {
             get { return pSifraIzmenjeneLokacije; }
             set { pSifraIzmenjeneLokacije = value; }
        }


        public string NazivIzmenjeneLokacije
        {
            get { return pNazivIzmenjeneLokacije; }
            set { pNazivIzmenjeneLokacije = value; }
        }


    // konstruktor
        public clsFormaLokacijaDetaljiEdit(string NoviStringKonekcije)
        {
            pStringKonekcije = NoviStringKonekcije;
            objLokacijaDB = new clsLokacijaDB(pStringKonekcije);
        }

 

        // javne metode
        public bool ObrisiLokaciju()
        {
            // zvanje koje je trenutno u atributima dato, TJ. preuzeta sifra je bitna
            bool uspehBrisanja = false;
            uspehBrisanja = objLokacijaDB.ObrisiLokaciju(pSifraPreuzeteLokacije);

            return uspehBrisanja;

        }

        public bool IzmeniLokaciju()
        {
            bool uspehIzmene = false;
            objPreuzeteLokacije = new clsLokacija();
            objIzmenjeneLokacije = new clsLokacija();

            objPreuzeteLokacije.Sifra = pSifraPreuzeteLokacije;
            objPreuzeteLokacije.Naziv = pNazivPreuzeteLokacije;

            objIzmenjeneLokacije.Sifra = pSifraIzmenjeneLokacije;
            objIzmenjeneLokacije.Naziv = pNazivIzmenjeneLokacije;

            uspehIzmene = objLokacijaDB.IzmeniLokaciju(objPreuzeteLokacije, objIzmenjeneLokacije);

            return uspehIzmene;
        }



        public clsLokacija objPreuzeteLokacije { get; set; }

        public clsLokacija objIzmenjeneLokacije { get; set; }
    }
}
