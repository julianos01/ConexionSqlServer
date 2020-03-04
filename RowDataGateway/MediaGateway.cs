using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RowDataGateway
{
   
    public enum MediaType
    {
        Book,
        Magazine, 
        Movie
    }

     public class MediaGateway
    {
        private readonly string _connectionString;
        SqlConnection Connection = new SqlConnection();



        public MediaGateway(string connectionString)
        {
            _connectionString = connectionString;
        }
        public int Id { get; set; }
        public String Name { get; set; }
        public MediaType Type { get; set; }

      

        public void Insert()
        {
            using(SqlConnection Connection=new SqlConnection(_connectionString))
            {
                Connection.Open();
                SqlCommand command = Connection.CreateCommand();
                command.CommandText = "Insert Into portafolio.dbo.Media (Name,Type) OUTPUT INSERTED.Id values(@name,@type)";
                command.Parameters.AddWithValue("name", Name);
                command.Parameters.AddWithValue("type", (int)Type);
                Id = (int)command.ExecuteScalar();

            }
           

        }
        public void Update()
        {
            using (SqlConnection Connection = new SqlConnection(_connectionString))
            {
                Connection.Open();
                SqlCommand command = Connection.CreateCommand();
                command.CommandText = "Update portafolio.dbo.Media set Name=@name,Type=@type where Id=@id ";
                command.Parameters.AddWithValue("name", Name);
                command.Parameters.AddWithValue("type", (int)Type);
                command.Parameters.AddWithValue("id", (int)Id);
                bool update= command.ExecuteNonQuery() >0 ;
                if(update)
                {
                    Console.WriteLine("Registro Actualizado");
                }
                else
                {
                    Console.WriteLine("Error en la actualización");
                }
            }
        }
        public bool Delete()
        {
            using (SqlConnection Connection = new SqlConnection(_connectionString))
            {
                Connection.Open();
                SqlCommand command = Connection.CreateCommand();
                command.CommandText = "Delete from portafolio.dbo.Media where Id=@id ";

                command.Parameters.AddWithValue("id", (int)Id);
                command.ExecuteNonQuery();
                return command.ExecuteNonQuery() > 0;
            }
        }

    }

   
}
