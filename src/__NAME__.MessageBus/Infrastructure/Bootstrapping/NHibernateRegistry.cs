using System;
using Crux.Domain.Entities;
using Crux.Domain.Persistence;
using Crux.Domain.Persistence.NHibernate;
using Crux.Domain.UoW;
using NHibernate;
using NServiceBus.UnitOfWork;
using StructureMap.Configuration.DSL;
using __NAME__.Domain;
using __NAME__.Domain.Persistence;

namespace __NAME__.MessageBus.Infrastructure.Bootstrapping
{
    public class NHibernateRegistry : Registry
    {
        public NHibernateRegistry()
        {
            // Configure session factory
            ForSingletonOf<ISessionFactory>()
                .Use(c => new SessionFactoryConfig().CreateSessionFactory());

            // Configure connection provider
            ForSingletonOf<IDbConnectionProvider>()
                .Use(c => SqlConnectionProvider.FromConnectionStringKey("__NAME__"));

            For<INHibernateUnitOfWork>().Use<NHibernateUnitOfWork>();

            // Persistence Infrastructure
            For<IRepositoryOfId<int>>().Use<NHibernateRepositoryOfId<int>>();
            For<IRepositoryOfId<Guid>>().Use<NHibernateRepositoryOfId<Guid>>();
            For<IRepository>().Use<NHibernateRepository>();

            For<IStatelessSession>()
                .Use(c => c.GetInstance<ISessionFactory>().OpenStatelessSession());
        }
    }
}