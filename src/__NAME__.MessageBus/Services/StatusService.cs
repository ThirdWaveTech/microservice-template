using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crux.Core.Bootstrapping;
using Crux.Logging;
using __NAME__.Messages.Commands;
using __NAME__.Models.ClientInfo;

namespace __NAME__.MessageBus.Services
{
    internal class StatusService: IRunAtStartup
    {
        private static ILog Log = LogManager.GetLogger(typeof (StatusService));

        public void Init()
        {
            Log.Info("__NAME__ MessageBus status service started");
        }

        public void RegisterClient(RegisterClientCommand message)
        {
            Log.Info("Client has registered {0}. Request ID {1}", message.ClientId, message.RequestId.ToString());
        }
    }
}
