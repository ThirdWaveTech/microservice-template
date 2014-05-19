using Crux.Domain.Entities;

namespace __NAME__.Domain
{
    public class DomainEntity : DomainEntityOfId<int> { }

    public interface IRepository : IRepositoryOfId<int> { }

    public interface IDomainQuery : IDomainQueryOfId<DomainEntity, int> { }
}
