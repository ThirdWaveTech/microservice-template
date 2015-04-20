using Crux.Domain.Persistence;
using NHibernate;
using NUnit.Framework;

namespace __NAME__.IntegrationTests.Infrastructure

{
    public abstract class BaseStatelessPersistenceTester
    {
        protected BaseStatelessPersistenceTester()
        {
            StatelessSession = GetStatelessSession();
        }

        public IStatelessSession GetStatelessSession()
        {
            var sessionFactory = new TestSessionFactoryConfig().CreateSessionFactory();
            var connectionProvider = new TestConnectionProvider("__NAME__");
            return sessionFactory.OpenStatelessSession(connectionProvider.GetConnection());
        }

        protected IStatelessSession StatelessSession { get; private set; }

        [TearDown]
        public void TearDown()
        {
            StatelessSession.Dispose();
        }
    }
}
