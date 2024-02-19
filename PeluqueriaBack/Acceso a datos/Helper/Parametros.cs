using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluqueriaBack.Acceso_a_datos.Helper
{
    public class Parametros
    {
        public string Clave { get; set; }
        public object Valor { get; set; }

        public Parametros(string clave, object valor)
        {
            Clave = clave;
            Valor = valor;
        }
    }
}
