using Crux.Domain.Persistence;
using NHibernate;
using NUnit.Framework;

namespace __NAME__.IntegrationTests.Infrastructure
{
    [TestFixture]
    public abstract class DomainPersistenceTester : Crux.Domain.Testing.Persistence.DomainPersistenceTester<int>
    {
        public override ISessionFactory SessionFactory
        {
            get { return new TestSessionFactoryConfig().CreateSessionFactory(); }
        }

        public override IDbConnectionProvider ConnectionProvider
        {
            get { return new TestConnectionProvider("__NAME__"); }
        }
    }
}
