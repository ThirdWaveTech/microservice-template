using NHibernate;
using NUnit.Framework;

namespace __NAME__.IntegrationTests.Infrastructure

{
    public abstract class BaseStatelessPersistenceTester
    {
        private readonly string _connectionString;

        protected BaseStatelessPersistenceTester(string connectionString)
        {
            _connectionString = connectionString;
            StatelessSession = GetStatelessSession();
        }

        public IStatelessSession GetStatelessSession()
        {
            var sessionFactory = new TestSessionFactoryConfig(_connectionString).CreateSessionFactory();
            return sessionFactory.OpenStatelessSession();
        }

        protected IStatelessSession StatelessSession { get; private set; }

        [TearDown]
        public void TearDown()
        {
            StatelessSession.Dispose();
        }
    }
}
