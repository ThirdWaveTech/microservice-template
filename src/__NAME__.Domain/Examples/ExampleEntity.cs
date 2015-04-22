using Crux.Domain.Component;

namespace __NAME__.Domain.Examples
{
    public enum ExampleStatus
    {
        Open = 10000,
        Closed = 20000
    }

    public class ExampleEntity : DomainEntity
    {
        public virtual string Name { get; protected set; }
        public virtual ExampleStatus Status { get; protected set; }
        public virtual Timestamp Timestamp { get; protected set; }

        protected ExampleEntity() { }

        public ExampleEntity(string name)
        {
            Name = name;
            Status = ExampleStatus.Open;
            Timestamp = Timestamp.Now();
        }

        public virtual void Close()
        {
            Status = ExampleStatus.Closed;
            Timestamp = Timestamp.Touch();
        }
    }
}