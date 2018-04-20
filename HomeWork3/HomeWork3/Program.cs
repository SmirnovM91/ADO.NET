using System;
using System.Collections.Generic;

using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    class Program
    {
        static void Main(string[] args)
        {

            string connectionStr = @"Data Source=(local);
         Initial Catalog=DB_171;Integrated Security=True;Pooling=False";

            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "CREATE TABLE gruppa ( Id int NOT NULL, Name varchar(255) NULL)";
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
