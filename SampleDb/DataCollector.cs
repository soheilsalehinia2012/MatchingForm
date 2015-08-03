using System.Collections.Generic;
using System.Data.SQLite;

namespace SampleDb
{
    public static class DataCollector
    {
        public static void CreateDb(string dbFileName, bool initDb = true)
        {
            SQLiteConnection.CreateFile(dbFileName);
            using (var dbConn = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;"))
            {
                dbConn.Open();
                var cmd = "CREATE TABLE USERS" +
                          "(Id INTEGER PRIMARY KEY AUTOINCREMENT," +
                          "StdNumber NVARCHAR(20)," +
                          "Pass NVARCHAR(20));";
                SQLiteCommand command = new SQLiteCommand(cmd, dbConn);
                command.ExecuteNonQuery();

                if (!initDb)
                    return;

                List<User> users = new List<User>
                {
                    new User{StdNumber = "1", Pass = "1"},
                    new User{StdNumber = "2", Pass = "2"},
                };

                foreach (var u in users)
                {
                    SQLiteCommand ins = new SQLiteCommand(
                        "INSERT INTO Users(StdNumber, Pass) VALUES(@num, @pass);", dbConn);
                    ins.Parameters.Add(new SQLiteParameter("@num", u.StdNumber));
                    ins.Parameters.Add(new SQLiteParameter("@pass", u.Pass));
                    ins.ExecuteNonQuery();
                }
            }
        }
    }
}