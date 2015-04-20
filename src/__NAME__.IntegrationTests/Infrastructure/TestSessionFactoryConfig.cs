using NHibernate;
using __NAME__.Domain.Persistence;

namespace __NAME__.IntegrationTests.Infrastructure
{
    public class TestSessionFactoryConfig : SessionFactoryConfig
    {
        public override ISessionFactory CreateSessionFactory()
        {
            return CreateSessionFactory(typeof(SessionFactoryConfig).Assembly);
        }
    }
}
