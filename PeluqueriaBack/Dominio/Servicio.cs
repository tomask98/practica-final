using PeluqueriaBack.Dominio;
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
        private string   promo;

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Costo { get; set; }
        //public bool EnPromocion { get; set; }

        

        public Servicio(int id, string nombre, int costo, string promo)
        {
            Id = id;
            Nombre = nombre;
            Costo = costo;
            this.promo = promo;
        }

        public override string ToString()
        {
            return Nombre + "| $" + Costo.ToString();
        }

    }
}
