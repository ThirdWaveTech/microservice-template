using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Crux.Domain.Persistence.NHibernate;
using StructureMap;
using __NAME__.Domain.Persistence.Migrations;
using __NAME__.Models.Diagnostics;

namespace __NAME__.Api.Diagnostics
{
    public class PersistanceStatusReporter : IReportStatus
    {
        private readonly IContainer _container;
        private readonly INHibernateUnitOfWork _unitOfWork;

        public PersistanceStatusReporter(IContainer container, INHibernateUnitOfWork unitOfWork)
        {
            _container = container;
            _unitOfWork = unitOfWork;
        }

        public IList<StatusItem> StatusReport
        {
            get
            {
                var statusItem = new StatusItem("__NAME__.Domain.Persistance");
                var repo = new MigrationsRepository(_unitOfWork);

                //Try sending a messages
                try
                {
                    var lastMigration = repo.LastMigration;
                    statusItem.Comment = String.Format("Last migration {0}", lastMigration);
                    statusItem.Status = StatusItem.OK;
                }
                catch (Exception e)
                {
                    statusItem.Status = StatusItem.Error;
                    statusItem.Comment = e.Message;
                }

                return new[] { statusItem };
            }
        }
    }
}