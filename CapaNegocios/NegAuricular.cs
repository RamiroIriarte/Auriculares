using Back;
using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    internal class NegAuricular
    {
        AdministAuriculares DatosobjAuricular = new AdministAuriculares();

        public int abmAuriculares(string accion, Auricular objAuricular)
        {
            return DatosobjAuricular.abmAuriculares(accion, objAuricular);
        }

        public DataSet listadoAuriculares(string cual)
        {
            return DatosobjAuricular.listadoAuriculares(cual);
        }
    }
}
