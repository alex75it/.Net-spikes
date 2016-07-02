using NUnit.Framework;
using Spikes.Couchbase;
using System;
using System.Collections.Generic;
using System.Linq;

using Couchbase;
using Couchbase.IO;
using Couchbase.Configuration.Client;
using System.ServiceProcess;
using Couchbase.Core;

namespace Tests.Couchbase
{
    [TestFixture, Category("Couchbase")]
    public class CouchbaseSpikeTest
    {
        private CouchbaseSpike spike;
        private string CouchbaseServiceName = "CouchbaseServer";
        private const string BUCKET = "Spike";
        private const string designDoc = "Views";
        private const string allKeysView = "AllKeys";

        [SetUp]
        public void SetUp()
        {
            EnsureServiceIsRunning();            
            spike = new CouchbaseSpike();
        }

        [Test]
        public void Run()
        {
            spike.Run();
        }


        [Test, Category("Integration test")]
        public void DatabaseIsReachable()
        {
            ClientConfiguration configuration = GetConfiguration();
            Cluster cluster = new Cluster(configuration);
            using (var bucket = cluster.OpenBucket(BUCKET))
            {
                var item = bucket.Get<object>("inexistent key");
                Assert.IsTrue(item.Status == ResponseStatus.KeyNotFound);
            }
        }

        [Test]
        public void PopulateDatabase_should_WriteRecords()
        {
            ClearBucket();

            int recordNumber = 10;
            spike.PopulateDatabase(recordNumber);

            var keys = GetAllKeys();

            Assert.AreEqual(recordNumber, keys.Count());
        }

        #region helper methods

        private void ClearBucket()
        {
            var keys = GetAllKeys();
            using (IBucket bucket = GetBucket())
            {                
                foreach (var key in keys)
                {
                    bucket.Remove(key);
                }
            }

            System.Threading.Thread.Sleep(500);            
        }

        private IBucket GetBucket()
        {
            return new Cluster(GetConfiguration()).OpenBucket(BUCKET);
        }

        private IEnumerable<string> GetAllKeys()
        {
            IList<string> keys = new List<string>();
            using (var bucket = GetBucket())
            {
                var view = bucket.CreateQuery(designDoc, allKeysView);
                var result = bucket.Query<Document<dynamic>>(view);
                foreach (var row in result.Rows)
                {
                    keys.Add(row.Id);
                }
            }
            return keys;
        }

        private object GetRecord()
        {
            try
            {
                IOperationResult<object> result;
                string key = "test";

                ClientConfiguration configuration = GetConfiguration();
                Cluster cluster = new Cluster(configuration);
                using (var bucket = cluster.OpenBucket(BUCKET))
                {
                    result = bucket.Get<object>(key);
                }

                if (result.Success)
                    return result.Value;
                else
                    throw result.Exception;
            }
            catch (Exception exc)
            {
                exc = GetCouchbaseInnerException(exc);
                if (exc is System.Net.Sockets.SocketException)
                    throw new Exception("Check if server is started. Run 'net start couchbaseserver' with administrative privileges.", exc);
                else if (exc is System.Security.Authentication.AuthenticationException)
                    throw new Exception(string.Format(@"Check if bucket ""{0}""exists.", BUCKET), exc);
                throw;
            }
        }

        private static Exception GetCouchbaseInnerException(Exception exc)
        {
            var aggregateException = (exc.InnerException ?? null) as AggregateException;
            if (aggregateException != null)
                exc = aggregateException.InnerExceptions[0];
            return exc; 
        }

        private ClientConfiguration GetConfiguration()
        {
            ClientConfiguration configuration = new ClientConfiguration();
            // default values
            return configuration;
        }
        
        private void EnsureServiceIsRunning()
        {
            ServiceController controller = new ServiceController(); // needs reference to System.ServiceProcess.dll
            controller.ServiceName = CouchbaseServiceName;

            if (controller.Status == ServiceControllerStatus.Stopped)
            {
                Console.WriteLine(string.Format(@"Starting the ""{0}"" service...", controller.ServiceName));
                try
                {
                    // Start the service, and wait until its status is "Running".
                    // Require administrator privileges.
                    controller.Start();
                    controller.WaitForStatus(ServiceControllerStatus.Running);
                }
                catch (InvalidOperationException exc)
                {
                    Console.WriteLine(string.Format(@"Could not start the ""{0}"" service.", controller.ServiceName));
                    throw new Exception("Fail to start service", exc);
                }
            }
        }
        private void EnsureBucketExists(Cluster cluster)
        {
            // TODO: I don't know how... yet.
        }

        #endregion
    }
}
