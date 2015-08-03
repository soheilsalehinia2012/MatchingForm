using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace SampleDb
{
    [TestFixture]
    public class SampleTest
    {
        [Test]
        public void CreateDbTest()
        {
            var dbFileName = "MyDatabase.sqlite";
            if (File.Exists(dbFileName))
                return;
            DataCollector.CreateDb(dbFileName);
        }

        [Test]
        public void AnalysingData()
        {
            var users = new List<User>
            {
                new User {StdNumber = "1", TestResult = "11111"},
                new User {StdNumber = "2", TestResult = "33335"},
                new User {StdNumber = "3", TestResult = "33332"},
                new User {StdNumber = "4", TestResult = "55555"},
                new User {StdNumber = "5", TestResult = "44444"},
            };
            List<List<string>> groups = DataAnalayser.CreateGroups(users, 2)
                .Select(r => r.Select(u => u.StdNumber).ToList()).ToList();

            Assert.AreEqual(3, groups.Count);
            Assert.AreEqual(new List<string> { "1", "3" }, groups.First());
            Assert.AreEqual(new List<string> {"2", "5"}, groups.Skip(1).First());
            Assert.AreEqual(new List<string> {"4"}, groups.Last());
        }
    }

    public abstract class DataAnalayser
    {
        public static List<List<User>> CreateGroups(List<User> users, int groupSize)
        {
            var orderedUsers = users.Zip(users.Select(user => user.TestResult.Sum(c => Char.GetNumericValue(c))),
                (user, d) => new {User = user, Score = d})
                .OrderBy(tuple => tuple.Score);
            var result = new List<List<User>>();
            var room = new List<User>();
            foreach (var user in orderedUsers)
            {
                room.Add(user.User);
                if (room.Count == groupSize)
                {
                    result.Add(room);
                    room = new List<User>();
                }
            }

            if (room.Count != 0)
                result.Add(room);

            return result;
        }
    }
}