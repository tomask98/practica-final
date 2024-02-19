using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ParcialApp.Dominio
{
    public class Servicio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int costo { get; set; }
        public bool enPromocion { get; set; }

        override
        public string ToString()
        {
            return Nombre + "| $" + costo.ToString();
        }

    }
}
