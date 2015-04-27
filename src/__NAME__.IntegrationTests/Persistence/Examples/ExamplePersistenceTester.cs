using FluentAssertions;
using NUnit.Framework;
using __NAME__.Domain.Examples;
using __NAME__.IntegrationTests.Infrastructure;

namespace __NAME__.IntegrationTests.Persistence.Examples
{
    public class ExamplePersistenceTester : DomainPersistenceTester
    {
        [Test]
        public void should_save_and_load()
        {
            var entity = new ExampleEntity("test");
            var newEntity = VerifyPersistence(entity);

            newEntity.ShouldBeEquivalentTo(entity, DefaultCompareConfig.Compare);
        }
    }
}
