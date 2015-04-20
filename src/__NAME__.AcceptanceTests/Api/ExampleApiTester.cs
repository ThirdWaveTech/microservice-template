using System.Threading;
using FluentAssertions;
using NUnit.Framework;
using __NAME__.Api.Client;
using __NAME__.Api.Client.ResourceClients;
using __NAME__.Models.Example;

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
            var models = await _client.List();
            models.Should().NotBeEmpty();
        }

        [Test]
        public async void should_create_example()
        {
            var model = new NewExampleModel {Name = "test"};
            var createdModel = await _client.Create(model);

            createdModel.Id.Should().BePositive();
        }

        [Test]
        public async void should_close_created_example()
        {
            var model = new NewExampleModel { Name = "test" };
            var createdModel = await _client.Create(model);
            await _client.Close(new CloseExampleModel { Id = createdModel.Id });
            Thread.Sleep(10000);

            var newModel = await _client.Get(createdModel.Id);
            newModel.Status.Should().Be(20000);
        }
    }
}
