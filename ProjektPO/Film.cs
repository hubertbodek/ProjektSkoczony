using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjektPO
{
    [Serializable]
    public class Film : FilmSerial
    {

        public string CzasTrwania { get; set; }

        public Film() : base()
        {
            CzasTrwania = "0";
        }
        public Film(string nazwa, Gatunek g, int rokPowstania, string ct) : base(nazwa, g, rokPowstania)
        {
            CzasTrwania = ct;
        }
        public override string ToString()
        {
            return Nazwa + "\n     Gatunek: " + Gatunek  + "\n     Rok powstania: " + rokPowstania + "\n     Czas trwania: " + CzasTrwania + "\n     Średnia ocena: " + sredniaOcen + " Ilość ocen: " + iloscOcen;
        }
    }
}
