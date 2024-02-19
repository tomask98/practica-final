using ParcialApp.Acceso_a_datos;
using ParcialApp.Dominio;
using PeluqueriaBack.Acceso_a_datos.Helper;
using PeluqueriaBack.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluqueriaBack.Acceso_a_datos.Implementacion
{
    public class PeluqueriaDao : IDao
    {
        public bool ExisteTurno(string fecha, string hora)
        {
            throw new NotImplementedException();
        }

        public List<Servicio> GetServicios()
        {
            List<Servicio> lservicio = new List<Servicio>();
            DataTable tabla = HelperDao.ObtenerInstancia().Consultar("SP_CONSULTAR_SERVICIOS");

            foreach (DataRow fila in tabla.Rows)
            {
                int id = Convert.ToInt32(fila["id"].ToString());
                string nombre = fila["nombre"].ToString();
                int costo = Convert.ToInt32(fila["costo"].ToString());
                string promo =fila["enPromocion"].ToString();

                Servicio S = new Servicio(id, nombre, costo, promo);

                lservicio.Add(S);
            }
            return lservicio;
        }

        public bool Save(Turno oTurno)
        {
            bool AUX = true;
            
            SqlConnection cnn = HelperDao.ObtenerInstancia().ObtenerConexion();
            SqlTransaction t= null;

            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();

                SqlCommand comando = new SqlCommand("SP_INSERTAR_Turno", cnn, t);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@fecha", oTurno.Fecha);
                comando.Parameters.AddWithValue("@hora", oTurno.Hora);
                comando.Parameters.AddWithValue("@Cliente", oTurno.Cliente);

                SqlParameter parametro = new SqlParameter("@id", SqlDbType.Int);

                parametro.Direction = ParameterDirection.Output;

                comando.Parameters.Add(parametro);
                comando.ExecuteNonQuery();

                int ultId = Convert.ToInt32(parametro.Value);

                int cantDetalle = 1;

                foreach (DetalleTurno detalle in oTurno.LstDetalle)
                {
                    SqlCommand comandoD = new SqlCommand("SP_INSERTAR_DETALLES", cnn, t);
                    comandoD.Parameters.AddWithValue("@id_turno", detalle.Id_turno);
                    comandoD.Parameters.AddWithValue("@id_servicio", ultId);
                    comandoD.Parameters.AddWithValue("@observaciones", detalle.Observaciones);


                    comandoD.ExecuteNonQuery();
                    cantDetalle++;

                }
                t.Commit();

            }
            catch (Exception)
            {
                t.Rollback();
                AUX = false;
               
            }
            finally
            {
                if(cnn != null && cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }

            return AUX;

        }
    }
}
