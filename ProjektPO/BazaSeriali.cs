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
    [XmlRoot("BazaSeriali")]
    public class BazaSeriali :  IBaza
    {
        [XmlArray("Seriale")]
        public List<Serial> bazaSeriali;

        public BazaSeriali()
        {
            bazaSeriali = new List<Serial>();
        }

        public void DodajSerial(Serial s)
        {
            bazaSeriali.Add(s);
        }
        public void ZapiszXML(string nazwaPliku)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BazaSeriali));
            if (File.Exists(nazwaPliku)) File.Delete(nazwaPliku);
            TextWriter writer = new StreamWriter(nazwaPliku);
            xmlSerializer.Serialize(writer, this);
            writer.Close();
        }
        public static object OdczytajXML(string nazwaPliku)
        {
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(BazaSeriali));
                TextReader textReader = new StreamReader(nazwaPliku);
                BazaSeriali b = (BazaSeriali)deserializer.Deserialize(textReader);
                textReader.Close();
                return b;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Plik nie istnieje!");
            }
            return null;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Serial s in bazaSeriali)
            {
                sb.Append(s);
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public void Ranking()
        {
            bazaSeriali.Sort(new Ranking());
        }

        public void SortujNazwa()
        {
            bazaSeriali.Sort(new SortujNazwa());
        }

        public void SortujRokPowstania()
        {
            bazaSeriali.Sort(new SortujRokPowstania());
        }

        
    }
}
