using PeluqueriaBack.Fachada.Implemantacion;
using PeluqueriaBack.Fachada.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluqueriaBack.Fachada
{
    public class FabricaAplicacionImp : FabricaAplicacion
    {
        public override IAplicacion Aplicacion()
        {
            return new Aplicacion();
        }
    }
}
