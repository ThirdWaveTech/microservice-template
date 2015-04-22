using NServiceBus;
using __NAME__.Messages.Example;

namespace __NAME__.MessageBus.Client
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
