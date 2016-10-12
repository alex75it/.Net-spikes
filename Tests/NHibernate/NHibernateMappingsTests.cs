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
    [TestFixture, Category("NHibernate")]
    public class NHibernateMappingsTests
    {
        [TestCase(typeof(Category))]
        [TestCase(typeof(Subcategory))]
        public void MappingIsOk(Type entityType)
        {
            if (entityType == typeof(Subcategory))
                Assert.Ignore("CategoryId must be set");

            var mappingTest = GetType().GetMethod("RunSimpleMappingTest");
            var mappingTestForType = mappingTest.MakeGenericMethod(entityType);
            mappingTestForType.Invoke(this, new object[0]);

            //new PersistenceSpecification<Employee>(session)
            //    .CheckProperty(c => c.Id, 1)
            //    .CheckProperty(c => c.FirstName, "John")
            //    .CheckProperty(c => c.LastName, "Doe")
            //    .VerifyTheMappings();
        }

        //public void SubcategoryMapping_should_BeCorrect(Type entityType)
        //{
        //    Subcategory subcategory = new Subcategory();
        //}

        public void RunSimpleMappingTest<TEntity>() where TEntity : EntityBase<int>, new() // class, new()
        {
            var id = 0;

            InSession(session =>
            {
                TEntity entity = CreateValidInstance<TEntity>();
                session.Save(entity);
                id = entity.Id;
            });

            InSession(session => session.Get<TEntity>(id));
        }

        protected void InSession(Action<ISession> action)
        {
            var configuration = new global::NHibernate.Cfg.Configuration();
            configuration.Configure();
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();

            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                action(session);
                transaction.Commit();
            }
        }

        private static TEntity CreateValidInstance<TEntity>() where TEntity : EntityBase<int>, new()
        {
            var entity = new TEntity();

            foreach (var p in typeof(TEntity).GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                if (p.PropertyType == typeof(string))
                    p.SetValue(entity, "");
            }


            return entity;
        }
    }
}
