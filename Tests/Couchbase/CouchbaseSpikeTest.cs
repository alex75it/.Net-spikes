using NUnit.Framework;
using Spikes.Couchbase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Couchbase;
using Couchbase.Configuration.Client;
using System.ServiceProcess;

namespace Tests.Couchbase
{
    [TestFixture, Category("Couchbase")]
    public class CouchbaseSpikeTest
    {
        private CouchbaseSpike spike;
        private string CouchbaseServiceName = "CouchbaseServer";

        [SetUp]
        public void SetUp()
        {
            StartCouchbaseServer();
            spike = new CouchbaseSpike();
        }

        private void StartCouchbaseServer()
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
            try
            {
                object item;
                string key = "test";

                ClientConfiguration configuration = GetConfiguration();
                Cluster cluster = new Cluster(configuration);
                using (var bucket = cluster.OpenBucket("Spike"))
                {
                    item = bucket.Get<object>(key);
                }
                return item;
            }
            catch (Exception exc)
            {
                var aggregateException = (exc.InnerException ?? null) as AggregateException;
                if (aggregateException != null)
                {
                    var sockectException = aggregateException.InnerExceptions[0] as System.Net.Sockets.SocketException;
                    if (sockectException != null)
                        throw new Exception("Check if server is started. Run net start couchbase.", sockectException);
                }
                throw;
            }
        }

        private ClientConfiguration GetConfiguration()
        {
            ClientConfiguration configuration = new ClientConfiguration();
            //configuration.
            return configuration;
        }

        #endregion
    }
}
