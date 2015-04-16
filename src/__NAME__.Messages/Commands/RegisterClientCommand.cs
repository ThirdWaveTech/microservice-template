using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __NAME__.Messages.Commands
{
    public class RegisterClientCommand
    {
        public String ClientId { get; set; }

        public RegisterClientCommand()
        {
            
        }

        public RegisterClientCommand(string clientIdentifier)
        {
            ClientId = clientIdentifier;
        }

    }
}
