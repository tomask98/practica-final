using ParcialApp.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluqueriaBack.Fachada.Interfaz
{
    public interface IAplicacion
    {

        List<Servicio> GetServicios();
        bool Save(Turno oTurno);
        bool ExisteTurno(string fecha, string hora);
    }
}
