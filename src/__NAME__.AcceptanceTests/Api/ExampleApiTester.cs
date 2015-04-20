using FluentAssertions;
using NUnit.Framework;
using __NAME__.Api.Client;
using __NAME__.Api.Client.ResourceClients;

namespace __NAME__.AcceptanceTests.Api
{
    [TestFixture]
    public class ExampleApiTester
    {
        private readonly IExampleClient _client;

        public ExampleApiTester()
        {
            _client = __NAME__ClientFactory.GetClient<IExampleClient>();
        }

        [Test]
        public async void should_list_examples()
        {
            var examples = await _client.List();
            examples.Should().NotBeEmpty();
        }
    }
}
