using ParcialApp.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluqueriaBack.Dominio
{
    public class DetalleTurno
    {
        public Servicio Servicio { get; set; }
        public int Id_turno { get; set; }
        public string Observaciones { get; set; }

        public DetalleTurno(Servicio servicio, int id_t,string obs )
        {
            Servicio = servicio;
            Id_turno = id_t;
            Observaciones = obs;
        }

       
    }
}
