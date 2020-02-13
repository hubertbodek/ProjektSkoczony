using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO
{
    public enum Gatunek : byte
    {
        horror,
        komedia,
        thriller,
        biograficzny,
        akcji,
        fantasy,
        sciencefiction,
    }
    [Serializable]
    public class FilmSerial
    {
        public string Nazwa { get; set; }
        public double sredniaOcen { get; set; }
        public Gatunek Gatunek { get; set; }
        public int rokPowstania;
        public double sumaPunktów { get; set; }
        public int iloscOcen { get; set; }
        public List<string> Komentarze { get; set; }

        public FilmSerial()
        {
            Nazwa = "";
            rokPowstania = 0;
            Komentarze = new List<string>();
            sumaPunktów = 0;
            sredniaOcen = 0;
            iloscOcen = 0;
        }
        public FilmSerial(string nazwa, Gatunek g, int rokPowstania)
        {
            Nazwa = nazwa;
            Gatunek = g;
            this.rokPowstania = rokPowstania;
            Komentarze = new List<string>();
            sumaPunktów = 0;
            sredniaOcen = 0;
            iloscOcen = 0;
        }

        public void DodajOcene(int ocena)
        {
            sumaPunktów += ocena;
            iloscOcen++;
            sredniaOcen = sumaPunktów / iloscOcen;
        }
        
        public void DodajKomentarz(string kom)
        {
            Komentarze.Add(kom);
        }
    }
    
}
