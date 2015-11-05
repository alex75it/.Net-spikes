using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Spikes
{
	public class DatabaseManager
	{


		public DatabaseManager()
		{
			var settings = new MongoClientSettings();
			//settings.Servers.
			settings.WriteConcern = WriteConcern.WMajority;
			//settings.Jo

			MongoClient client = new MongoClient(settings);
			//client
		}
	}
}
