using System;
using System.Collections.Generic;
using StructureMap;
using __NAME__.MessageBus.Client.Diagnostics;
using __NAME__.Models.Diagnostics;

namespace __NAME__.Api.Infrastructure.Diagnostics
{
    public class MessageBusPingReporter : IReportStatus
    {
        private readonly IContainer _container;

        public MessageBusPingReporter(IContainer container)
        {
            _container = container;
        }

        public IList<StatusItem> ReportStatus()
        {
            var statusItem = new StatusItem("__NAME__.MessageBus.Client");
            var client = _container.GetInstance<DiagnosticsSender>();

            // Try sending a message
            try
            {
                client.Ping("__NAME__.Api");
                statusItem.Status = StatusItem.OK;
            }
            catch (Exception e)
            {
                statusItem.Status = StatusItem.Error;
                statusItem.Comment = e.Message;
            }
                
            return new []{statusItem};
        }
    }
}