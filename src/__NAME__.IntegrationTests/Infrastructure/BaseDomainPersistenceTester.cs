using NHibernate;

namespace __NAME__.IntegrationTests.Infrastructure
{
    public abstract class DomainPersistenceTester : Crux.Domain.Testing.Persistence.DomainPersistenceTester<int>
    {
        public override ISessionFactory SessionFactory
        {
            get { return new TestSessionFactoryConfig("__NAME__").CreateSessionFactory(); }
        }
    }
}
