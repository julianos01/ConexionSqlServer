using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RowDataGateway.Finders
{
    
     public class MediaFinder
    {
        private readonly string _connectionString;
        SqlConnection Connection = new SqlConnection();

        

        public MediaFinder(string connectionString)
        {
            _connectionString = connectionString;
           
        }

        public MediaGateway Find(int id)
        {
            using (SqlConnection Connection = new SqlConnection(_connectionString))
            {
                Connection.Open();
                SqlCommand command = Connection.CreateCommand();
                command.CommandText = "Select * from  portafolio.dbo.Media where Id=@id";
                command.Parameters.AddWithValue("id", id);
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
               
                if(table.Rows.Count>0)
                { 
                    DataRow RawMedia = table.Rows[0];
               
                
                return new MediaGateway(_connectionString)
                {

                    Id = id,
                    Name = RawMedia.Field<string>("Name"),
                    Type = RawMedia.Field<MediaType>("Type")

                };
            }
                else
                {
                    return new MediaGateway(_connectionString)
                    {

                        Id = id,
                        Name = "No Encontrado",
                        Type =0 

                    };
                }
                }
        }


    }
}
