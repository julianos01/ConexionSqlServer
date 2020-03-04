using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RowDataGateway
{
    public class ConexionBd
    {
        String cadena = "data source=DESKTOP-IU300GU\\SQLEXPRESS;initial catalog=portafolio;integrated security=True";
        public SqlConnection ConectarDb = new SqlConnection();
        public ConexionBd()
        {
            ConectarDb.ConnectionString = cadena;
        }

        public void Opencnx()
        {
            try
            {
                ConectarDb.Open();
                Console.WriteLine("Established");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error de conexion"+e);
                throw;
            }
        }


        public void Closecnx()
        {
            try
            {
                ConectarDb.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error de cierre de conexion" + e);
                throw;
            }
        }
    }
}
