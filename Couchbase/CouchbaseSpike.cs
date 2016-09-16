using Couchbase;
using Couchbase.Configuration.Client;
using Spikes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spikes.Couchbase
{
    public class CouchbaseSpike : SpikeBase
    {
        private const string BUCKET = "Spike";

        public override void Run()
        {
            int recordNumber = 1000;
            PopulateDatabase(recordNumber);               
        }

        public void PopulateDatabase(int recordNumber)
        {
            List<Document<dynamic>> documents = CreateDocuments(recordNumber);

            using (var bucket = new Cluster(GetConfiguration()).OpenBucket(BUCKET))
            {
                foreach(var doc in documents)
                    bucket.Upsert(doc);
            }
        }

        #region private methods

        private static List<Document<dynamic>> CreateDocuments(int recordNumber)
        {
            List<Document<dynamic>> documents = new List<Document<dynamic>>(recordNumber);
            while (recordNumber-- > 0)
            {
                var document = new Document<dynamic>
                {
                    Id = "test." + recordNumber,
                    Content = new
                    {
                        recordNumber = recordNumber
                    }
                };
                documents.Add(document);
            }

            return documents;
        }

        private ClientConfiguration GetConfiguration()
        {
            ClientConfiguration configuration = new ClientConfiguration();
            // default values
            return configuration;
        }

        #endregion
    }
}
