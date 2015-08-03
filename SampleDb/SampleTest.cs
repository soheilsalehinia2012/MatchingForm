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
        public void CreateAndUpdateDbTest()
        {
            DataCollector.CreateDb(true);
            DataCollector.InitDb();

            var allUsers = DataCollector.GetAllUsers();
            Assert.AreEqual(new List<User>
            {
                new User {Id = 1, StdNumber = "1", Pass = "1", TestResult = "-"},
                new User {Id = 2, StdNumber = "2", Pass = "2", TestResult = "-"},
            }, allUsers);

            var first = allUsers.First();
            first.TestResult = "12345";
            DataCollector.UpdateUser(first);

            var updatedUsers = DataCollector.GetAllUsers();
            Assert.AreEqual("12345", updatedUsers.First().TestResult);
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
}