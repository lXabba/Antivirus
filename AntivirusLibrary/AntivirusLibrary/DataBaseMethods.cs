using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace AntivirusLibrary
{
    public static class DataBaseMethods
    {
        //соединение
        //передаюю стрингу 4 байта возвращает лист стрингов которые начинаются так
        public static SqliteConnection DataBaseConnection()
        {
            SqliteConnection sqliteConnection = new SqliteConnection("Data Source=D:\\3 семестр\\БазыДанных\\SystemBDTest.db");
            sqliteConnection.Open();
           
            return sqliteConnection;
        }

       public static void DataBaseCloseConnection(SqliteConnection sqliteConnection)
        {
            sqliteConnection.Close();
        }
       public static List<string> DataBaseGetAllNotes(string tableName)
        {
            SqliteConnection sqliteConnection = DataBaseConnection();

            var command = sqliteConnection.CreateCommand();
            command.CommandText = @"SELECT * FROM " + tableName;

            List<string> allNotesList = new List<string>();
            string temp = "";
            using (var reader = command.ExecuteReader())
            {
                for (int i = 0; reader.Read(); i++)
                {
                    for (int j = 0; j < reader.FieldCount; j++)
                    {

                        temp += reader.GetString(j) + '?';
                    }
                    temp.Trim();
                    allNotesList.Add(temp);
                    temp = "";
                }
            }

            DataBaseCloseConnection(sqliteConnection);

            return allNotesList;
        }
        public static List<string> DataBaseGetAllNotesWhere(string tableName, string where)
        {
            SqliteConnection sqliteConnection = DataBaseConnection();

            var command = sqliteConnection.CreateCommand();
            command.CommandText = $"SELECT * FROM {tableName} WHERE {where}";

            List<string> allNotesList = new List<string>();
            string temp = "";
            using (var reader = command.ExecuteReader())
            {
                for (int i = 0; reader.Read(); i++)
                {
                    for (int j = 0; j < reader.FieldCount; j++)
                    {

                        temp += reader.GetString(j) + '?';
                    }
                    temp.Trim();
                    allNotesList.Add(temp);
                    temp = "";
                }
            }

            DataBaseCloseConnection(sqliteConnection);

            return allNotesList;
        }
        public static string DataBaseGetVirusType(string signature)
        {
            SqliteConnection sqliteConnection = DataBaseConnection();

            var command = sqliteConnection.CreateCommand();
            command.CommandText = $"SELECT VIRUSTYPE FROM SIGNATURES WHERE SIGNATURE='{signature}'" ;

            
            string temp = "";
            using (var reader = command.ExecuteReader())
            {
                for (int i = 0; reader.Read(); i++)
                {

                    temp = reader.GetString(0);
                }
            }

            DataBaseCloseConnection(sqliteConnection);

            return temp;
        }
        public static List<string> DataBaseGetOneField(string tableName, int indexField)
        {

            SqliteConnection sqliteConnection = DataBaseConnection();

            var command = sqliteConnection.CreateCommand();
            command.CommandText = @"SELECT * FROM " + tableName;

            List<string> allNotesList = new List<string>();
            string temp = "";
            using (var reader = command.ExecuteReader())
            {
                for (int i = 0; reader.Read(); i++)
                {
                   
                    temp = reader.GetString(indexField);
                   
                    allNotesList.Add(temp);
                }
            }

            DataBaseCloseConnection(sqliteConnection);

            return allNotesList;
        }
        public static string DataBaseGetOneFieldIn(string tableName, int indexField, string where)
        {

            SqliteConnection sqliteConnection = DataBaseConnection();

            var command = sqliteConnection.CreateCommand();
            command.CommandText = $"SELECT * FROM {tableName} WHERE {where}";

            
            string temp = "";
            using (var reader = command.ExecuteReader())
            {
                for (int i = 0; reader.Read(); i++)
                {

                    temp = reader.GetString(indexField);

                   
                }
            }

            DataBaseCloseConnection(sqliteConnection);

            return temp;
        }
        public static List<string> DataBaseFindNotesStartWith(string signature, List<string> allNotesList)
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

       public static void AddNote(string tableName, string columns, string values)
        {
            SqliteConnection sqliteConnection = DataBaseConnection();

            var command = sqliteConnection.CreateCommand();
            string str = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";
            command.CommandText = str;
            command.ExecuteNonQuery();

            DataBaseCloseConnection(sqliteConnection);
            
        }
       public static void DataBaseDeleteNote(string path, string tableName)
        {
            SqliteConnection sqliteConnection = DataBaseConnection();

            var command = sqliteConnection.CreateCommand();
            string str = $"DELETE FROM {tableName} WHERE PATH = ('{path}')";
            command.CommandText = str;
            command.ExecuteNonQuery();

            DataBaseCloseConnection(sqliteConnection);
        }
        public static void DataBaseDeleteNoteWhereAnd(string conditions, string tableName)
        {
            SqliteConnection sqliteConnection = DataBaseConnection();

            var command = sqliteConnection.CreateCommand();
            string str = $"DELETE FROM {tableName} {conditions}";
            command.CommandText = str;
            command.ExecuteNonQuery();

            DataBaseCloseConnection(sqliteConnection);
        }

        public static void DataBaseDeleteAllNotes(string tableName)
        {
            SqliteConnection sqliteConnection = DataBaseConnection();

            var command = sqliteConnection.CreateCommand();
            string str = $"DELETE FROM {tableName}";
            command.CommandText = str;
            command.ExecuteNonQuery();

            DataBaseCloseConnection(sqliteConnection);
        }

        public static void DataBaseUpdate(string tableName, string updateStr)
        {
            SqliteConnection sqliteConnection = DataBaseConnection();

            var command = sqliteConnection.CreateCommand();
            string str = $"UPDATE {tableName} SET {updateStr}";
            command.CommandText = str;
            command.ExecuteNonQuery();

            DataBaseCloseConnection(sqliteConnection);
        }

    }
}
