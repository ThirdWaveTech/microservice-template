﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using __NAME__.Messages.Commands;

namespace __NAME__.MessageBus.Handlers.ForMessages
{
    class RegisterClientCommandHandler:IHandleMessages<RegisterClientCommand>
    {
        public void Handle(RegisterClientCommand message)
        {
            
        }
    }
}
