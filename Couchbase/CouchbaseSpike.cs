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
        public new void Run()
        {
            int recordNumber = 1000;
            PopulateDatabase(recordNumber);               
        }

        public void PopulateDatabase(int recordNumber)
        {
            // 
        }
    }
}
