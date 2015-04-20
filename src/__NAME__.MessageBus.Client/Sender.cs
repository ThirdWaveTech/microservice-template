using NServiceBus;
using __NAME__.Messages.Commands;

namespace __NAME__.MessageBus.Client
{
    
    public class Sender
    {
        private readonly ISendOnlyBus _bus;

        public Sender(ISendOnlyBus bus)
        {
            _bus = bus;
        }

        public void Register(string clientIdentifier)
        {
            _bus.Send(new RegisterClientCommand(clientIdentifier));
        }
    }
}
