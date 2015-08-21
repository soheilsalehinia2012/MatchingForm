using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Reflection;

namespace SampleDb
{
    public class DataCollector
    {
        internal static bool Testing;

        public static void CreateDb(bool recreat = false)
        {
            if (File.Exists(DbConfigs.DbLocation) && !recreat)
                return;
            using (var dbConn = GetDbConn(recreate:recreat))
            {
                dbConn.Open();
                var cmd = "CREATE TABLE Users" +
                          "(Id INTEGER PRIMARY KEY AUTOINCREMENT," +
                          "StdNumber NVARCHAR(20)," +
                          "Pass NVARCHAR(20)," +
                          "TestResult NVARCHAR(10)," +
                          "Ratios NVARCHAR(10));";
                SQLiteCommand command = new SQLiteCommand(cmd, dbConn);
                command.ExecuteNonQuery();
            }

            InitDb();
        }

        private static void InitDb()
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
                        "INSERT INTO Users(StdNumber, Pass) VALUES(@num, @pass);", dbConn);
                    ins.Parameters.Add(new SQLiteParameter("@num", u.StdNumber));
                    ins.Parameters.Add(new SQLiteParameter("@pass", u.Pass));
                    ins.ExecuteNonQuery();
                }
            }
        }

        private static SQLiteConnection GetDbConn(bool recreate = false)
        {
            string dbLocation = Testing ? DbConfigs.TestingDbLocation : DbConfigs.DbLocation;
            if (!File.Exists(dbLocation) || recreate)
                SQLiteConnection.CreateFile(dbLocation);
            return new SQLiteConnection(string.Format("Data Source={0};Version=3;", dbLocation));
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
                        TestResult = reader[3] as string,
                        Ratios = reader[4] as string,
                    });
            }

            return users;
        }

        public static void UpdateUser(string stdNum, string result, string ratios)
        {
            using (var dbConn = GetDbConn())
            {
                dbConn.Open();

                SQLiteCommand updateCmd = new SQLiteCommand(
                    "UPDATE Users SET TestResult = @result, Ratios = @ratio WHERE StdNumber=@stdNum", dbConn);
                updateCmd.Parameters.Add(new SQLiteParameter("@result", result));
                updateCmd.Parameters.Add(new SQLiteParameter("@ratio", ratios));
                updateCmd.Parameters.Add(new SQLiteParameter("@stdNum", stdNum));
                updateCmd.ExecuteNonQuery();
            }
        }
    }
}