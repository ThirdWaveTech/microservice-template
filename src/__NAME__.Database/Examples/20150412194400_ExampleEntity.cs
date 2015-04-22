using FluentMigrator;

namespace __NAME__.Database.Examples
{
    [Migration(20150412194400, "Create ExampleEntities table")]
    public class ExampleEntity : Migration
    {
        /// <summary>
        /// The migration for our example domain entity.
        /// 
        /// We are creating a ExampleEntity table and a ExampleStatuses lookup table.
        /// </summary>
        public override void Up()
        {
            Create.Table("ExampleStatuses")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("Description").AsString(1000).NotNullable()
                ;

            Insert.IntoTable("ExampleStatuses")
                .Row(new { Id = 10000, Name = "Open", Description = "Open Status" })
                .Row(new { Id = 20000, Name = "Closed", Description = "Closed Status" })
                ;

            Create.Table("ExampleEntities")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("ExampleStatusID").AsInt32().NotNullable()
                .WithColumn("DateCreated").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime)
                .WithColumn("DateUpdated").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime)
                ;

            Create.ForeignKey("FK_ExampleStatuses_ExampleEntities")
                .FromTable("ExampleEntities").ForeignColumn("ExampleStatusID")
                .ToTable("ExampleStatuses").PrimaryColumn("Id")
                ;
        }

        public override void Down()
        {
            Delete.Table("ExampleEntities");
            Delete.Table("ExampleStatuses");
        }
    }
}
