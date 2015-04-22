using System;
using Crux.Domain.Persistence.NHibernate;
using Crux.Domain.UoW;
using NServiceBus.UnitOfWork;

namespace __NAME__.MessageBus.Infrastructure
{
    public class UnitOfWorkManager : IManageUnitsOfWork
    {
        private readonly INHibernateUnitOfWork _unitOfWork;
        private IUnitOfWorkScope _scope;

        public UnitOfWorkManager(INHibernateUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Begin()
        {
            _scope = _unitOfWork.CreateTransactionalScope(UnitOfWorkTransactionOptions.Default());
        }

        public void End(Exception ex = null)
        {
            using (_scope) {
                if (ex == null) {
                    _scope.Complete();
                }
            }
        }
    }
}
