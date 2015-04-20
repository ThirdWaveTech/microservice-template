using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using __NAME__.MessageBus.Client;
using __NAME__.Models.Diagnostics;

namespace __NAME__.Api.Diagnostics
{
    public class CommunicationStatusReporter: IReportStatus
    {
        private readonly IContainer _container;

        public CommunicationStatusReporter(IContainer container)
        {
            _container = container;
        }

        public IList<StatusItem> StatusReport
        {
            get
            {
                
                var statusItem = new StatusItem("__NAME__.MessageBus.Client");
                var client = _container.GetInstance<__NAME__.MessageBus.Client.Sender>();

                //Try sending a messages
                try
                {
                    client.Register(String.Format("__NAME__ Communication Status Reporter"));
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
}