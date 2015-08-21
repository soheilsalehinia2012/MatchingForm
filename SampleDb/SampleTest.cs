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
        [SetUp]
        public void Setup()
        {
            DataCollector.Testing = true;
        }

        [TearDown]
        public void TearDown()
        {
            DataCollector.Testing = false;
        }

        [Test]
        public void CreateAndUpdateDbTest()
        {
            DataCollector.CreateDb(true);

            var allUsers = DataCollector.GetAllUsers();
            Assert.AreEqual(new []
            {
                new {Id = 1L, StdNumber = "1", Pass = "1"},
                new {Id = 2L, StdNumber = "2", Pass = "2"},
            }, allUsers.Select(u => new {u.Id, u.StdNumber, u.Pass}).ToArray());

            var first = allUsers.First();
            var result = "12345";
            var ratios = "11223";
            DataCollector.UpdateUser(first.StdNumber, result, ratios);

            var updatedUsers = DataCollector.GetAllUsers();
            Assert.AreEqual(result, updatedUsers.First().TestResult);
            Assert.AreEqual(ratios, updatedUsers.First().Ratios);
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
            Assert.AreEqual(new List<string> {"1", "3"}, groups.First());
            Assert.AreEqual(new List<string> {"2", "5"}, groups.Skip(1).First());
            Assert.AreEqual(new List<string> {"4"}, groups.Last());
        }

        [Test, Explicit]
        public void AllUsers()
        {
            // Checking entrance of entries in DB
            DataCollector.Testing = false;
            var allUsers = DataCollector.GetAllUsers();
            foreach (var user in allUsers)
                Console.WriteLine($"User {user.StdNumber} : {user.TestResult} , {user.Ratios}");
        }
    }
}