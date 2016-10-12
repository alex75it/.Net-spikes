using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Should;
using Spikes.NHibernate;

namespace Spikes.Tests.NHibernate
{
    [TestFixture, Category("NHibernate")]
    public class NHibernateSpikeTest
    {
        [Test]
        public void RunQuery_should_ExecuteOnlyOneSqlQuery()
        {            
            string textToSearch = "Category";
            DateTime fromTime = DateTime.Now;
            var queriesBefore = GetSqlQueries(textToSearch, fromTime);

            //queriesBefore.Count.ShouldEqual(0, "Initial number of queries should be zero.");

            // Act
            var categories = new CategoryRepository().List();

            var queriesAfter = GetSqlQueries(textToSearch, fromTime);
            var newQueries = queriesAfter.Select(q => queriesBefore.Any(qb => qb.Item1 == q.Item1)).ToList();

            PrintQueries(queriesAfter);

            newQueries.Count.ShouldEqual(1);
        }

        private IList<Tuple<string, DateTime, string>> GetSqlQueries(string textToSearch, DateTime fromTime)
        {
            IList<Tuple<string, DateTime, string>> queries = new List<Tuple<string, DateTime, string>>();
            
            string comandText = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "NHibernate\\Select last queries.sql"))
                .Replace("{search}", textToSearch).Replace("{time}", fromTime/*.ToUniversalTime*/.ToString("s")); // "o" is ISO format but not accepted by SQL (too long), "s" means sortable and does not set offset time

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["spikes"].ConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = comandText;

                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string handle = reader.GetString(0);
                    DateTime time = reader.GetDateTime(1);
                    string text = reader.GetString(2);
                    int count = (int)reader.GetInt64(3);
                    queries.Add(Tuple.Create(handle, time, text));
                }
            }

            return queries;
        }

        private void PrintQueries(IList<Tuple<string, DateTime, string>> queriesAfter)
        {
            foreach (var query in queriesAfter)
            {
                Console.WriteLine(string.Format("Query {0}: {1} at {2}.", query.Item1, query.Item2, query.Item3));
            }
        }
    }
}
