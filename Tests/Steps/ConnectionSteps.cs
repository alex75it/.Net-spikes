using System;
using MongoDB.Driver;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Tests.Steps
{
    [Binding]
    public class ConnectionSteps
    {
		private MongoClientSettings settings;
		private MongoClient client;
		private Exception exception;

		public ConnectionSteps()		{


		}

        [Given(@"connection server is ""(.*)"" and port is (.*)")]
        public void GivenConnectionServerIsAndPortIs(string server, int port)
        {
            settings = new MongoClientSettings() {
				Server = new MongoServerAddress(server, port)
			};
        }
        
        [Given(@"I use the user ""(.*)"" with the password ""(.*)"" on the database ""(.*)""")]
        public void GivenIHaveEnteredTheUserWithThePassword(string user, string password, string database)
        {
			settings.Credentials = new MongoCredential[] { MongoCredential.CreateCredential(database, user, password) };
        }
        
        [When(@"I try to connect to ""(.*)"" database")]
        public void WhenITryToConnect(string database)
        {
			client = new MongoClient(settings);
			try {
				client.GetDatabase(database);
			}
			catch(Exception exc)
			{
				//ScenarioContext.Current
				this.exception = exc;
			}
        }
        
        [Then(@"there are no errors")]
        public void ThenThereIsNoErrors()
        {
			Assert.True(exception == null); 
        }

		[Then(@"return an error")]
		public void ThenReturnAnError()
		{
			Assert.True(exception != null); 
		}

    }
}
