using System;
using Crux.Domain.Entities;
using Crux.Domain.Persistence.NHibernate;
using Crux.Domain.UoW;
using NHibernate;
using StructureMap.Configuration.DSL;
using __NAME__.Domain;
using __NAME__.Domain.Persistence;

namespace __NAME__.MessageBus.Infrastructure.Bootstrapping
{
    public class NHibernateRegistry : Registry
    {
        public NHibernateRegistry()
        {
            // Handle Setter Injection
            Policies.SetAllProperties(s => s.OfType<IUnitOfWork>());

            // Persistence Infrastructure
            For<IRepositoryOfId<int>>().Use<NHibernateRepositoryOfId<int>>();
            For<IRepositoryOfId<Guid>>().Use<NHibernateRepositoryOfId<Guid>>();
            For<IRepository>().Use<NHibernateRepository>();

            For<IUnitOfWork>()
                .Use<NHibernateUnitOfWork>();

            ForSingletonOf<ISessionFactory>()
                .Use(c => new SessionFactoryConfig().CreateSessionFactory());

            For<IStatelessSession>()
                .Use(c => c.GetInstance<ISessionFactory>().OpenStatelessSession());
        }
    }
}