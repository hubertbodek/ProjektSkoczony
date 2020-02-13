using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO
{
    interface IZapisz
    {
        void ZapiszXML(string nazwa);
        Object OdczytajXML(string nazwa);
    }
}
