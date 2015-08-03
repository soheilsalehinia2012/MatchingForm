using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
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
    }
}