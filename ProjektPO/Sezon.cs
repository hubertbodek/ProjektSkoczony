using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO
{
    [Serializable]
    public class Sezon
    //    {-odcinki:List<Odcinek>
    //-rokPowstania:int
    //-ocena
    //+DodajOdcinek(Odcinek o) :void
    {
        public int NrSezonu { get; set; } 
        public List<Odcinek> odcinki;
        public int RokPowstania { get; set; }
        public int iloscOcen { get; set; }
        public int sumaOcen { get; set; }
        public double Ocena { get; set; }
        public Sezon()
        {
            NrSezonu = 1;
            odcinki = new List<Odcinek>();
            RokPowstania = 0;
            iloscOcen = 0;
            sumaOcen = 0;
            Ocena = 0;
        }
        public Sezon(int rokp, int nrSezonu)
        {
            NrSezonu = nrSezonu;
            odcinki = new List<Odcinek>();
            RokPowstania = rokp;
            iloscOcen = 0;
            sumaOcen = 0;
            Ocena = 0;
        }
        public void DodajOdcinek(Odcinek o)
        {
            odcinki.Add(o);
        }
        public void DodajOcene(int ocena)
        {
            sumaOcen += ocena;
            iloscOcen++;
            Ocena = sumaOcen / iloscOcen;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Odcinek o in odcinki)
            {
                sb.Append("  " + o);
                sb.AppendLine();
            }
            return NrSezonu + ". Rok powstania: " + RokPowstania + "\nOcena: " + Ocena + " Ilość ocen: " + iloscOcen + "\n Odcinki: \n" + sb;
        }
    }
}
