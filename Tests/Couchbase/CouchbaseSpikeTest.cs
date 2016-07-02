using NUnit.Framework;
using Spikes.Couchbase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tests.Couchbase
{
    [TestFixture]
    public class CouchbaseSpikeTest
    {
        private CouchbaseSpike spike;

        [SetUp]
        public void SetUp()
        {
            spike = new CouchbaseSpike();
        }

        [Test]
        public void Run()
        {
            spike.Run();
        }

        [Test]
        public void PopulateDatabase_should_WriteRecords()
        {
            int recordNumber = 1;
            spike.PopulateDatabase(recordNumber);

            object items = GetRecords();
        }

        #region helper methods
        private object GetRecords()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
