using ParcialApp.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialApp.Acceso_a_datos
{
    interface IDao
    {

        List<Servicio> GetServicios();
        bool Save(Turno oTurno);
        bool ExisteTurno(string fecha, string hora);
    }
}
