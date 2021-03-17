using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
namespace Part3_Antivirus
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
            Console.Read();
            
        }
        static void Test()
        {
            SqliteConnection sqliteConnection = new SqliteConnection("Data Source=D:\\3 семестр\\БазыДанных\\SystemBDTest.db");
            sqliteConnection.Open();
            var command = sqliteConnection.CreateCommand();
            command.CommandText =
                                @"
                SELECT *
                FROM Test
            ";


            using (var reader = command.ExecuteReader())
            {
                for (int i = 0; reader.Read(); i++)
                {
                    Console.WriteLine(reader.GetString(1));
                }
            }
            sqliteConnection.Close();
          
        }
    }
}
