using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjektPO
{
    [Serializable]
    public class Serial : FilmSerial
    {
       public int IloscSezonow { get; set; }
        [XmlArray("Sezony")]
       public List<Sezon> sezony;


        public Serial() : base()
        {
            sezony = new List<Sezon>();
            IloscSezonow = sezony.Count;
            
        }
        public Serial(string nazwa, Gatunek g, int rokPowstania) : base(nazwa, g, rokPowstania)
        {
            sezony = new List<Sezon>();
            IloscSezonow = sezony.Count;
        }
        public void DodajSezon(Sezon s)
        {
            sezony.Add(s);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(Sezon s in sezony)
            {
                sb.Append(s);
                sb.AppendLine();
            }
            return Nazwa + "\n Rok powstania: " + rokPowstania + "\n Gatunek: " + Gatunek + "\n Ocena: " + sredniaOcen;
        }
    }
}
