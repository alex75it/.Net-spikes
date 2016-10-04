using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spikes.Tests.NHibernate
{
    [TestFixture]
    public class NHibernateSpikeTest
    {
        [Test]
        public void RunQuery_should_ExecuteOnlyOneSqlQuery()
        {
            Assert.Fail("not already implemented");

            int numberOfExecutedSelect = GetSqlQueryes();
        }

        private int GetSqlQueryes()
        {
            obtain the SQL commands executed
            throw new NotImplementedException();            
        }
    }
}
