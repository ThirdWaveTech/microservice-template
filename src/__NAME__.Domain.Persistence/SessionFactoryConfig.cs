using System.Reflection;
using Crux.Domain.Persistence.NHibernate.Config;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;

namespace __NAME__.Domain.Persistence
{
    public class SessionFactoryConfig
    {
        protected virtual IPersistenceConfigurer GetDatabaseConfiguration()
        {
            return MsSqlConfiguration.MsSql2012
                .ConnectionString(b => b.FromConnectionStringWithKey("__NAME__"));
        }

        public virtual ISessionFactory CreateSessionFactory()
        {
            return CreateSessionFactory(GetType().Assembly);
        }

        protected ISessionFactory CreateSessionFactory(Assembly classMapAssembly)
        {
            return Fluently.Configure()
                .Database(GetDatabaseConfiguration())
                .ExposeConfiguration(config => config.SetProperty(Environment.SqlExceptionConverter, typeof(SqlExceptionConverter).AssemblyQualifiedName))
                .Mappings(m => 
                    m.FluentMappings
                        .AddFromAssembly(classMapAssembly)
                        .Conventions.Add<TreatStringAsSqlAnsiStringConvention>()
                ).BuildSessionFactory();
        }
    }
}
