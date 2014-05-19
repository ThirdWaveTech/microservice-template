using Crux.Domain.Persistence.NHibernate;

namespace __NAME__.Domain.Persistence
{
    public class NHibernateRepository : NHibernateRepositoryOfId<int>, IRepository
    {
        public NHibernateRepository(INHibernateUnitOfWork unitOfWork) : base(unitOfWork) {}
    }
}
