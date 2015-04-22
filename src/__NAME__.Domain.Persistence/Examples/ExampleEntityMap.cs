using FluentNHibernate.Mapping;
using __NAME__.Domain.Examples;

namespace __NAME__.Domain.Persistence.Examples
{
    public class ExampleEntityMap : ClassMap<ExampleEntity>
    {
        public ExampleEntityMap()
        {
            Table("ExampleEntities");

            Id(x => x.ID).GeneratedBy.Identity();

            Map(x => x.Name).Not.Nullable();
            Map(x => x.Status).Column("ExampleStatusId")
                .CustomType<ExampleStatus>().Not.Nullable();

            Component(x => x.Timestamp, c => {
                c.Map(x => x.DateCreated).Not.Nullable();
                c.Map(x => x.DateUpdated).Not.Nullable();
            });
        }
    }
}
