using Crux.Domain.Persistence.NHibernate;
using NHibernate;

namespace __NAME__.Domain.Persistence.Migrations
{
    public class MigrationsRepository
    {
        private readonly INHibernateUnitOfWork _unitOfWork;

        private ISession Session
        {
            get
            {
                return _unitOfWork.CurrentSession;
            }
        }
        public MigrationsRepository(INHibernateUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public MigrationRecord LastMigration
        {
            get
            {
                var lastMigration = Session.QueryOver<MigrationRecord>()
                    .OrderBy(x => x.AppliedOn)
                    .Desc
                    .Take(1)
                    .SingleOrDefault<MigrationRecord>();

                return lastMigration;
            }
        }
    }
}
