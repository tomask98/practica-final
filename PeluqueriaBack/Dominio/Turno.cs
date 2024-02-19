using PeluqueriaBack.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialApp.Dominio
{
    public class Turno
    {
        public int Id { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Cliente { get; set; }

        public List<DetalleTurno> LstDetalle { get; set; }

        public Turno()
        {
            LstDetalle = new List<DetalleTurno>();
        }
        public Turno(int id,string fecha,string hora, string cliente)
        {
            Id = id;
            Fecha = fecha;
            Hora = hora;
            Cliente = cliente;
        }

    }
}
