using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO
{
    class Program
    {
        static void Main(string[] args)
        {
            Film film = new Film("film", Gatunek.horror, 2020, "1h 40min");
            Film film2 = new Film("film2", Gatunek.fantasy, 2019, "1h 40min");
            Serial serial1 = new Serial("serial1", Gatunek.akcji, 2020);
            Serial serial2 = new Serial("serial2", Gatunek.horror, 2020);
            Sezon sezon1 = new Sezon(2020, 1);
            Sezon sezon2 = new Sezon(2020, 1);
            BazaFilmow baza = new BazaFilmow();
            BazaSeriali bazaSeriali = new BazaSeriali();

            Console.WriteLine(baza.ToString());
            
            baza.DodajFilm(film);
            baza.DodajFilm(film2);
            bazaSeriali.DodajSerial(serial1);
            bazaSeriali.DodajSerial(serial2);
            serial1.DodajSezon(sezon1);
            serial2.DodajSezon(sezon2);

            serial1.DodajOcene(2);
            serial1.DodajOcene(2);
            serial1.DodajOcene(2);

            serial2.DodajOcene(2);
            serial2.DodajOcene(4);
            serial2.DodajOcene(5);

            film.DodajOcene(2);
            film.DodajOcene(2);
            film.DodajOcene(3);

            film2.DodajOcene(3);
            film2.DodajOcene(4);
            film2.DodajOcene(5);

            bazaSeriali.ZapiszXML("bazaseriali.xml");
            baza.ZapiszXML("baza.xml");

            Console.WriteLine(bazaSeriali.ToString());
            Console.WriteLine(baza.ToString());


            BazaFilmow baza2 = (BazaFilmow)BazaFilmow.OdczytajXML("baza.xml");
            BazaSeriali bazaSeriali2 = (BazaSeriali)BazaSeriali.OdczytajXML("bazaSeriali.xml");

            Console.WriteLine("=====xml=====");
            Console.WriteLine(baza2.ToString());
            Console.WriteLine(bazaSeriali2.ToString());

            Console.ReadKey();

           
            //Console.WriteLine(BazaFilmow.OdczytajXML("baza.xml").ToString());


        }
    }
    public class Ranking : IComparer<FilmSerial>
    {
        public int Compare(FilmSerial x, FilmSerial y)
        {
            return y.sredniaOcen.CompareTo(x.sredniaOcen);
        }
    }
    public class SortujNazwa : IComparer<FilmSerial>
    {
        public int Compare(FilmSerial x, FilmSerial y)
        {
            return x.Nazwa.CompareTo(y.Nazwa);
        }
    }
    public class SortujRokPowstania : IComparer<FilmSerial>
    {
        public int Compare(FilmSerial x, FilmSerial y)
        {
            return x.rokPowstania.CompareTo(y.rokPowstania);
        }
    }
}
