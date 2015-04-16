using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crux.Core.Bootstrapping;
using __NAME__.Models.ClientInfo;

namespace __NAME__.MessageBus.Services
{
    internal class StatusService: IRunAtStartup
    {
        public RegisterClientModel LastRegisteredClient { get; set; }
        public void Init()
        {
            
        }
    }
}
