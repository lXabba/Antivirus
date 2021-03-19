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
            DeleteNote("C:/NewPath");
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
        static void AddNote(string path)
        {
            SqliteConnection sqliteConnection = new SqliteConnection("Data Source=D:\\3 семестр\\БазыДанных\\SystemBDTest.db");
            sqliteConnection.Open();
            var command = sqliteConnection.CreateCommand();
            string str = @"INSERT INTO TEST (PATH) VALUES('" + path + "')";
            command.CommandText = str;
            command.ExecuteNonQuery();
            sqliteConnection.Close();
        }
        static void DeleteNote(string path)
        {
            SqliteConnection sqliteConnection = new SqliteConnection("Data Source=D:\\3 семестр\\БазыДанных\\SystemBDTest.db");
            sqliteConnection.Open();
            var command = sqliteConnection.CreateCommand();
            string str = @"DELETE FROM TEST WHERE PATH = ('"+path+"')";
            command.CommandText = str;
            command.ExecuteNonQuery();
            sqliteConnection.Close();
        }
    }
}
