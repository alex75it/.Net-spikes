using monei.Core.Entities;
using NHibernate;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Spikes.Tests.NHibernate
{
    [TestFixture]
    public class NHibernateMappingsTests
    {
        [TestCase(typeof(Category))]
        public void MappingIsOk(Type entityType)
        {
            var mappingTest = GetType().GetMethod("RunSimpleMappingTest");
            var mappingTestForType = mappingTest.MakeGenericMethod(entityType);
            mappingTestForType.Invoke(this, new object[0]);
            
            //new PersistenceSpecification<Employee>(session)
            //    .CheckProperty(c => c.Id, 1)
            //    .CheckProperty(c => c.FirstName, "John")
            //    .CheckProperty(c => c.LastName, "Doe")
            //    .VerifyTheMappings();

        }
        public void RunSimpleMappingTest<TEntity>() where TEntity : EntityBase<int>, new() // class, new()
        {
            var id = 0;

            InSession(session =>
            {
                var entity = new TEntity();

                session.Save(entity);
                //id = (int)entity.GetPrimaryKey().Value;
                id = entity.Id;
            });

            InSession(session => session.Get<TEntity>(id));
        }

        protected void InSession(Action<ISession> action)
        {
            var configuration = new global::NHibernate.Cfg.Configuration();
            configuration.Configure();
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();

            //using (var session = InMemoryDatabaseManager.OpenSession())
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                action(session);
                transaction.Commit();
            }
        }
    }
}
