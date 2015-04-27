using FluentNHibernate.Cfg.Db;
using NHibernate;
using __NAME__.Domain.Persistence;

namespace __NAME__.IntegrationTests.Infrastructure
{
    public class TestSessionFactoryConfig : SessionFactoryConfig
    {
        protected override IPersistenceConfigurer GetDatabaseConfiguration()
        {
            var provider = new TestConnectionProvider("__NAME__");

            return MsSqlConfiguration.MsSql2012
                .ConnectionString(provider.GetConnectionString());
        }

        public override ISessionFactory CreateSessionFactory()
        {
            return CreateSessionFactory(typeof(SessionFactoryConfig).Assembly);
        }
    }
}
