using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace AntivirusLibrary
{
    class DataBaseMethods
    {
        //соединение
        //передаюю стрингу 4 байта возвращает лист стрингов которые начинаются так
        static SqliteConnection DataBaseConnection()
        {
            SqliteConnection sqliteConnection = new SqliteConnection("Data Source=D:\\3 семестр\\БазыДанных\\SystemBDTest.db");
            sqliteConnection.Open();
           
            return sqliteConnection;
        }

        static void DataBaseCloseConnection(SqliteConnection sqliteConnection)
        {
            sqliteConnection.Close();
        }
        static List<string> DataBaseGetAllNotes(string tableName, SqliteConnection sqliteConnection)
        {
            var command = sqliteConnection.CreateCommand();
            command.CommandText = @"SELECT * FROM " + tableName;

            List<string> allNotesList = new List<string>();
            string temp = "";
            using (var reader = command.ExecuteReader())
            {
                for (int i = 0; reader.Read(); i++)
                {
                    temp = reader.GetString(1) + '-' + reader.GetString(2);
                    allNotesList.Add(temp);
                }
            }

            return allNotesList;
        }

        static List<string> DataBaseFindNotesStartWith(string signature, List<string> allNotesList)
        {
            List<string> findedList = new List<string>();

            for (int i=0; i<allNotesList.Count; i++)
            {
                if (allNotesList[i].Split('-')[1].StartsWith(signature))
                {
                    findedList.Add(allNotesList[i]);
                }
            }

            return findedList;
        }

        static void AddNote(string path, SqliteConnection sqliteConnection)
        {
            var command = sqliteConnection.CreateCommand();
            string str = @"INSERT INTO TEST (PATH) VALUES('" + path + "')";
            command.CommandText = str;
            command.ExecuteNonQuery();
            
        }
        static void DeleteNote(string path, SqliteConnection sqliteConnection)
        {
            var command = sqliteConnection.CreateCommand();
            string str = @"DELETE FROM TEST WHERE PATH = ('" + path + "')";
            command.CommandText = str;
            command.ExecuteNonQuery();
           
        }

    }
}
