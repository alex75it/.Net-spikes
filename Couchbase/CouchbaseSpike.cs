using Couchbase;
using Couchbase.Configuration.Client;
using Spikes.Common;
using Spikes.Common.Entities;
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
            //PopulateDatabase(recordNumber);  
            AddUsers();           
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

        public void AddUsers()
        {
            IEnumerable<User> users = new User[] {
                new User("Alessandro", "Piccione") { Email = "alex@email.com" },
                new User("Firstname", "Lastname") { Email = "user1@email.com" },
                new User("Firstname", "Lastname") { Email = "user2@email.com" },
            };

            using (var bucket = new Cluster(GetConfiguration()).OpenBucket(BUCKET))
            {
                foreach (var user in users)
                {
                    Document<User> document = CreateDocumentFromUser(user);
                    bucket.Upsert(document);
                }
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

        private static Document<User> CreateDocumentFromUser(User user)
        {
            Document<User> document = new Document<User>() {
                Id = user.Id,
                Content = user
            };
            return document;
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
