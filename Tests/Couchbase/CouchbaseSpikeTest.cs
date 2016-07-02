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
        [Test]
        public void Run()
        {
            CouchbaseSpike spike = new CouchbaseSpike();
            spike.Run();
        }

    }
}
