using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using StructureMap;
using __NAME__.Api.Diagnostics;
using __NAME__.Models.Diagnostics;

namespace __NAME__.Api.Modules
{
    public class DiagnosticsModule: NancyModule
    {

        private static IList<StatusItem> CollectStatuses(IContainer container)
        {
            var statusCollection = new List<StatusItem>();

            var reporters = container.GetAllInstances<IReportStatus>().ToList();

            foreach (var reporter in reporters)
            {
                statusCollection.AddRange(reporter.StatusReport);
            }

            return statusCollection;
        }

        public DiagnosticsModule(IContainer container)
        {
            Get["status"] = _ =>
            {
                var statuses = CollectStatuses(container);
                return statuses;
            };
        }
    }
}