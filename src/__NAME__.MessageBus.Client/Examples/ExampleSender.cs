using NServiceBus;
using __NAME__.Messages.Examples;

namespace __NAME__.MessageBus.Client.Examples
{
    public class ExampleSender
    {
        private readonly ISendOnlyBus _bus;

        public ExampleSender(ISendOnlyBus bus)
        {
            _bus = bus;
        }

        public void CloseExample(int id)
        {
            _bus.Send(new CloseExampleCommand {Id = id});
        }
    }
}
