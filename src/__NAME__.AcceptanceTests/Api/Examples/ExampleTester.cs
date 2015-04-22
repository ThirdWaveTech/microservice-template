using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Refit;
using __NAME__.Api.Client;
using __NAME__.Api.Client.Examples;
using __NAME__.Models.Examples;

namespace __NAME__.AcceptanceTests.Api.Examples
{
    [TestFixture]
    public class ExampleTester
    {
        private readonly IExampleClient _client;

        public ExampleTester()
        {
            _client = ApiClientFactory.GetClient<IExampleClient>();
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
        public void should_validate_new_exmaple()
        {
            var model = new NewExampleModel { Name = null };

            Func<Task> task = async () => { await _client.Create(model); };
            task.ShouldThrow<ApiException>().Where(ex => ContainsNameEmptyValidationError(ex));

        }

        private static bool ContainsNameEmptyValidationError(ApiException ex)
        {
            ex.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var validationErrors = ex.GetContentAs<IDictionary<string, IDictionary<string, string[]>>>();
            validationErrors.Should().HaveCount(1);
            validationErrors.First().Key.Should().Be("errors");
            validationErrors.First().Value.Should().HaveCount(1);
            validationErrors.First().Value.Should().ContainKey("name");
            validationErrors.First().Value.First().Value.Should().Contain("'Name' should not be empty.");
            
            return true;
        }

        [Test]
        public async void should_close_created_example()
        {
            var model = new NewExampleModel { Name = "test" };
            var createdModel = await _client.Create(model);
            await _client.Close(new CloseExampleModel { Id = createdModel.Id });
            Thread.Sleep(5000);

            var newModel = await _client.Get(createdModel.Id);
            newModel.Status.Should().Be(20000);
        }
    }
}
