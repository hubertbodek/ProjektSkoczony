using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjektPO
{
    [Serializable]
    [XmlRoot("BazaFilmow")]
    public class BazaFilmow :  IBaza//, IZapisz
    {
        [XmlArray("Filmy")]
        public List<Film> bazaFilmow;
        public BazaFilmow()
        {
            bazaFilmow = new List<Film>();
        }

        public void DodajFilm(Film f)
        {
            bazaFilmow.Add(f);
        }

        public void ZapiszXML(string nazwaPliku)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BazaFilmow));
            if (File.Exists(nazwaPliku)) File.Delete(nazwaPliku);
            TextWriter writer = new StreamWriter(nazwaPliku);
            xmlSerializer.Serialize(writer, this);
            writer.Close();
        }
        public static object OdczytajXML(string nazwaPliku)
        {
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(BazaFilmow));
                TextReader textReader = new StreamReader(nazwaPliku);
                BazaFilmow baza = (BazaFilmow)deserializer.Deserialize(textReader);
                textReader.Close();
                return baza;
            }
            catch (FileNotFoundException)
            {
                //SystemSounds.Excamation.Play();
                Console.WriteLine("Plik nie istnieje!");
                //return 0;
            }
            return null;
        }

        public void Ranking()
        {
            bazaFilmow.Sort(new Ranking());
        }

        public void SortujNazwa()
        {
            bazaFilmow.Sort(new SortujNazwa());
        }

        public void SortujRokPowstania()
        {
            bazaFilmow.Sort(new SortujRokPowstania());
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(Film f in bazaFilmow)
            {
                sb.Append(f);
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
    
}
