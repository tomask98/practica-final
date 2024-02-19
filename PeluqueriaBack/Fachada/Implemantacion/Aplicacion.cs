using ParcialApp.Acceso_a_datos;
using ParcialApp.Dominio;
using PeluqueriaBack.Acceso_a_datos.Implementacion;
using PeluqueriaBack.Fachada.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluqueriaBack.Fachada.Implemantacion
{
    public class Aplicacion:IAplicacion
    {
        private IDao dao;

        public Aplicacion()
        {
            dao = new PeluqueriaDao();
        }

        public bool ExisteTurno(string fecha, string hora)
        {
            return dao.ExisteTurno(fecha,hora);
        }

        public List<Servicio> GetServicios()
        {
            return dao.GetServicios();
        }

        public bool Save(Turno oTurno)
        {
            return dao.Save(oTurno);
        }
    }
}
