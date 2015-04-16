using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using __NAME__.Models.ClientInfo;

namespace __NAME__.Messages.Commands
{
    public class RegisterClientCommand: RegisterClientModel
    {
        public RegisterClientCommand(string clientIdentifier):base(clientIdentifier)
        {
            
        }
    }
}
