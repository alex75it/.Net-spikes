using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Spikes.MongoDB
{

    public class InsertTest
    {

		/// <summary>
		/// How many animals will be inserted into the "animals" collection?
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
        public static async Task MainAsync(string[] args)
        {
            var client = new MongoClient();
            var db = client.GetDatabase("test");

            var animals = db.GetCollection<BsonDocument>("animals");

            var animal = new BsonDocument
                            {
								{"animal", "monkey"}
                            };

            await animals.InsertOneAsync(animal);

			//Console.WriteLine("new id: " + animal.O);

            animal.Remove("animal");
            animal.Add("animal", "cat");
            await animals.InsertOneAsync(animal);
            animal.Remove("animal");
            animal.Add("animal", "lion");
            await animals.InsertOneAsync(animal);
        }

    }
}
