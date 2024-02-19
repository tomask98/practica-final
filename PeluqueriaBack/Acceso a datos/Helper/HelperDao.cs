using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluqueriaBack.Acceso_a_datos.Helper
{
    public class HelperDao
    {
        private static HelperDao Instancia;
        private SqlConnection Cnn;

        private HelperDao()
        {
            Cnn = new SqlConnection("Data Source=Tomas;Initial Catalog=db_turnos;Integrated Security=True");

        }

        public static HelperDao ObtenerInstancia()
        {
            if(Instancia== null)
            {
                Instancia= new HelperDao();
            }
                return Instancia;
        }

        public SqlConnection ObtenerConexion()
        {
            return this.Cnn;
        }

        public DataTable Consultar(string NombreSP)
        {
            Cnn.Open(); //abro la coneccion
            SqlCommand comando = new SqlCommand(); // creo un nuevo comando 
            comando.Connection = Cnn; //lo conecto
            comando.CommandType = CommandType.StoredProcedure; //indico qu tipo va a ser el comando
            comando.CommandText = NombreSP; // su nombre
            DataTable tabla = new DataTable(); //creo una nueva datatable para cargar mi comando
            tabla.Load(comando.ExecuteReader()); //lleno la datatable
            Cnn.Close();
            return tabla; //cierro la conexion y retorno la tablka

        }

        public DataTable ConsultarSql(string nombreSP, List<Parametros> p)
        {
            DataTable tabla = new DataTable();
            Cnn.Open();

            SqlCommand comando = new SqlCommand(nombreSP,Cnn);
            comando.CommandType = CommandType.StoredProcedure;
            if(p != null)
            {
                foreach (Parametros par in p)
                {
                    comando.Parameters.AddWithValue(par.Clave, par.Valor);
                }

            }
            
            tabla.Load(comando.ExecuteReader());
            Cnn.Close();

            return tabla;
            

        }

        public int EjecutarSql(string nombreSP, List<Parametros> p)
        {
            int filasAfectadas = 0;
            SqlTransaction t = null;

            try
            {
                SqlCommand comando = new SqlCommand(nombreSP,Cnn,t);
                Cnn.Open();
                comando.CommandType = CommandType.StoredProcedure;

                if(p != null) 
                {
                    foreach (Parametros par in p)
                    {
                        comando.Parameters.AddWithValue(par.Clave, par.Valor);
                    }
                }
                filasAfectadas = comando.ExecuteNonQuery();
                t.Commit();
                
            }
            catch (SqlException)
            {
                if (t!=null)
                {
                    t.Rollback();
                }
            }
            finally
            {
                if (Cnn != null && Cnn.State == ConnectionState.Open)
                {
                    Cnn.Close();
                }
                
            }
            return filasAfectadas;


        }
        


    }
}
