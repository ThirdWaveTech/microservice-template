using FluentAssertions;
using __NAME__.Domain;
using __NAME__.IntegrationTests.Infrastructure;

namespace __NAME__.IntegrationTests.Persistence
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
