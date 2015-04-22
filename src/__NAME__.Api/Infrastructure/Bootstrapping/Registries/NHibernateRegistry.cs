using System;
using Crux.Domain.Entities;
using Crux.Domain.Persistence;
using Crux.Domain.Persistence.NHibernate;
using NHibernate;
using StructureMap.Configuration.DSL;
using __NAME__.Domain;
using __NAME__.Domain.Persistence;

namespace __NAME__.Api.Infrastructure.Bootstrapping.Registries
{
    public class NHibernateRegistry : Registry
    {
        public NHibernateRegistry()
        {
            // Session factory
            ForSingletonOf<ISessionFactory>()
                .Use(c => new SessionFactoryConfig().CreateSessionFactory());

            // Session factory
            ForSingletonOf<IDbConnectionProvider>()
                .Use(c => SqlConnectionProvider.FromConnectionStringKey("__NAME__"));

            // Unit of Work
            For<INHibernateUnitOfWork>().Use<NHibernateUnitOfWork>();

            // Repositories
            For<IRepositoryOfId<int>>().Use<NHibernateRepositoryOfId<int>>();
            For<IRepositoryOfId<Guid>>().Use<NHibernateRepositoryOfId<Guid>>();
            For<IRepository>().Use<NHibernateRepository>();

            // Stateless session
            For<IStatelessSession>()
                .Use(c => c.GetInstance<ISessionFactory>().OpenStatelessSession());
        }
    }
}