using FluentAssertions;
using __NAME__.Domain.Examples;
using __NAME__.IntegrationTests.Infrastructure;

namespace __NAME__.IntegrationTests.Persistence.Examples
{
    public class ExamplePersistenceTester : DomainPersistenceTester
    {
        public void should_save_and_load()
        {
            var entity = new ExampleEntity("test");
            var newEntity = VerifyPersistence(entity);

            newEntity.Should().ShouldBeEquivalentTo(entity);
        }
    }
}
