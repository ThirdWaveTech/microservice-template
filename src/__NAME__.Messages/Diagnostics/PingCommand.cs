using System;

namespace __NAME__.Messages.Diagnostics
{
    public class PingCommand
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Sender { get; set; }

        public PingCommand()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.UtcNow;
        }
    }
}
