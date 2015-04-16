using NServiceBus;
using __NAME__.Messages.Commands;

namespace __NAME__.MessageBus.Client
{
    
    public class __NAME__Client
    {
        private readonly ISendOnlyBus _bus;

        public __NAME__Client(ISendOnlyBus bus)
        {
            _bus = bus;
        }

        public void Register(string clientIdentifier)
        {
            _bus.Send(new RegisterClientCommand(clientIdentifier));
        }
    }
}
