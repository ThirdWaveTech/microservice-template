using Crux.Domain.Persistence.NHibernate.Config;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;

namespace __NAME__.Domain.Persistence
{
    public class SessionFactoryConfig
    {
        private const string CONNECTION_STRING = "__NAME__";

        protected virtual MsSqlConfiguration GetMsSqlConfiguration()
        {
            return MsSqlConfiguration.MsSql2012
                .ConnectionString(b => b.FromConnectionStringWithKey(CONNECTION_STRING));
        }

        public ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(GetMsSqlConfiguration())
                .ExposeConfiguration(config =>
                    config.SetProperty(Environment.SqlExceptionConverter, typeof(SqlExceptionConverter).AssemblyQualifiedName))
                .CurrentSessionContext("thread_static")
                .Mappings(m => m.FluentMappings
                    .AddFromAssembly(GetType().Assembly)
                    .Conventions.Add<TreatStringAsSqlAnsiStringConvention>()
                ).BuildSessionFactory();
        }
    }
}
