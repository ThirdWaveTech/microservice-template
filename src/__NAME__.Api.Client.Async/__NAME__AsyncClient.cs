using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using __NAME__.Messages.Commands;

namespace __NAME__.Api.AsyncClient
{
    
    public class __NAME__AsyncClient
    {
        private readonly ISendOnlyBus _bus;

        public __NAME__AsyncClient(ISendOnlyBus bus)
        {
            _bus = bus;
        }

        public void Register(string clientIdentifier)
        {
            _bus.Send(new RegisterClientCommand(clientIdentifier));
        }
    }
}
