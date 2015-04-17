use $(DATABASE_NAME)

set nocount on

print 'Inserting some Example records...'
set identity_insert dbo.ExampleEntities on
insert dbo.ExampleEntities (Id, Name, ExampleStatusID, DateCreated, DateUpdated)
values (10000, 'Test Open', 10000, GETDATE(), GETDATE())
insert dbo.ExampleEntities (Id, Name, ExampleStatusID, DateCreated, DateUpdated)
values (10001, 'Test Closed', 20000, GETDATE(), GETDATE())
set identity_insert ExampleEntities off

set nocount off
