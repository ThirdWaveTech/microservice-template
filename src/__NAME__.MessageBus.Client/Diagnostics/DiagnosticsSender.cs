using NServiceBus;
using __NAME__.Messages.Diagnostics;

namespace __NAME__.MessageBus.Client.Diagnostics
{
    public class DiagnosticsSender
    {
        private readonly ISendOnlyBus _bus;

        public DiagnosticsSender(ISendOnlyBus bus)
        {
            _bus = bus;
        }

        public void Ping(string sender)
        {
            _bus.Send(new PingCommand { Sender = sender });
        }
    }
}