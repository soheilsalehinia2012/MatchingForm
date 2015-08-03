using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace SampleDb
{
    public static class DataCollector
    {
        public static void CreateDb(bool recreat = false)
        {
            using (var dbConn = GetDbConn(recreate:recreat))
            {
                dbConn.Open();
                var cmd = "CREATE TABLE Users" +
                          "(Id INTEGER PRIMARY KEY AUTOINCREMENT," +
                          "StdNumber NVARCHAR(20)," +
                          "Pass NVARCHAR(20)," +
                          "TestResult NVARCHAR(10));";
                SQLiteCommand command = new SQLiteCommand(cmd, dbConn);
                command.ExecuteNonQuery();
            }
        }

        public static void InitDb()
        {
            using (var dbConn = GetDbConn())
            {
                dbConn.Open();
                List<User> users = new List<User>
                {
                    new User {StdNumber = "1", Pass = "1"},
                    new User {StdNumber = "2", Pass = "2"},
                };

                foreach (var u in users)
                {
                    SQLiteCommand ins = new SQLiteCommand(
                        "INSERT INTO Users(StdNumber, Pass, TestResult) VALUES(@num, @pass, @result);", dbConn);
                    ins.Parameters.Add(new SQLiteParameter("@num", u.StdNumber));
                    ins.Parameters.Add(new SQLiteParameter("@pass", u.Pass));
                    ins.Parameters.Add(new SQLiteParameter("@result", "-"));
                    ins.ExecuteNonQuery();
                }
            }
        }

        private static SQLiteConnection GetDbConn(string dbFileName = @"MyDatabase.sqlite", bool recreate = false)
        {
            if (!File.Exists(dbFileName) || recreate)
                SQLiteConnection.CreateFile(dbFileName);
            return new SQLiteConnection(string.Format("Data Source={0};Version=3;", dbFileName));
        }

        public static List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            using (var dbConn = GetDbConn())
            {
                dbConn.Open();

                var allUsersCms = new SQLiteCommand("SELECT * FROM Users;", dbConn);
                var reader = allUsersCms.ExecuteReader();

                while (reader.Read())
                    users.Add(new User
                    {
                        Id = (long) reader[0],
                        StdNumber = (string) reader[1],
                        Pass = (string) reader[2],
                        TestResult = (string) reader[3],
                    });
            }

            return users;
        }

        public static void UpdateUser(User user)
        {
            using (var dbConn = GetDbConn())
            {
                dbConn.Open();

                SQLiteCommand updateCmd = new SQLiteCommand(
                    "UPDATE Users SET TestResult = @result WHERE Id=@id", dbConn);
                updateCmd.Parameters.Add(new SQLiteParameter("@result", user.TestResult));
                updateCmd.Parameters.Add(new SQLiteParameter("@id", user.Id));
                updateCmd.ExecuteNonQuery();
            }
        }
    }
}