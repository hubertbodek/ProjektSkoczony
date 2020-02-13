using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO
{
    [Serializable]
    public class Odcinek
    {
        public int NrOdcinka { get; set; }
        public string CzasTrwania { get; set; }

        public Odcinek()
        {
            NrOdcinka = 1;
            CzasTrwania = "0";
        }
        public Odcinek(int nrOdcinka, string czas)
        {
            NrOdcinka = nrOdcinka;
            CzasTrwania = czas;

        }

        public override string ToString()
        {
            return NrOdcinka + ". " + "\n Czas trwania: " + CzasTrwania;
        }
    }
}
//-czasTrwania
//-ocena: int
//-iloscOcen: int
//-sumaOcen: int
//+DodajOcene(int ocena) :void