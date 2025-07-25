using System;
using System.Data.SqlClient;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace TestRepo
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = "unsafe_input'; DROP TABLE Users; --";

            // Unsafe SQL command concatenation - SQL Injection target
            string query = "SELECT * FROM Users WHERE Name = '" + userInput + "'";
            using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=TestDb;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                Console.WriteLine("Query: " + query);
            }

            // Unsafe deserialization - known vulnerability pattern
            byte[] serializedData = new byte[] { /* some bytes */ };
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(serializedData))
            {
                var obj = formatter.Deserialize(ms);
                Console.WriteLine("Deserialized object: " + obj);
            }
        }
    }
}
