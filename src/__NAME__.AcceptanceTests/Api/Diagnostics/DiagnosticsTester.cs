using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using __NAME__.Api.Client;
using __NAME__.Api.Client.Diagnostics;

namespace __NAME__.AcceptanceTests.Api.Diagnostics
{
    [TestFixture]
    public class DiagnosticsTester
    {
        private readonly IDiagnosticsClient _client;

        public DiagnosticsTester()
        {
            _client = ApiClientFactory.GetClient<IDiagnosticsClient>();
        }

        [Test]
        public async void should_list_examples()
        {
            var models = await _client.ListStatus();

            models.Select(m => m.Status).All(s => s == "OK")
                .Should().BeTrue("The api should report all statuses as 'OK'");
        }
    }
}
