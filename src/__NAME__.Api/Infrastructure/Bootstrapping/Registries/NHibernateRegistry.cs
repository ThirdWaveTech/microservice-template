using System;
using Crux.Domain.Entities;
using Crux.Domain.Persistence.NHibernate;
using Crux.Domain.UoW;
using NHibernate;
using StructureMap.Configuration.DSL;
using StructureMap.Web;
using __NAME__.Domain;
using __NAME__.Domain.Persistence;

namespace __NAME__.Api.Infrastructure.Bootstrapping.Registries
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
                .HybridHttpOrThreadLocalScoped()
                .Use<NHibernateUnitOfWork>();

            For<INHibernateUnitOfWork>()
                .HybridHttpOrThreadLocalScoped()
                .Use<NHibernateUnitOfWork>();

            ForSingletonOf<ISessionFactory>()
                .Use(c => new SessionFactoryConfig("__NAME__").CreateSessionFactory());

            For<IStatelessSession>()
                .Use(c => c.GetInstance<ISessionFactory>().OpenStatelessSession());
        }
    }
}