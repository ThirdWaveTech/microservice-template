using System;

namespace __NAME__.Models.ClientInfo
{
    public class RegisterClientModel
    {
        public string ClientId { get; set; }
        public Guid RequestId { get; set; }

        public RegisterClientModel()
        {
            
        }

        public RegisterClientModel(string clientIdentifier)
        {
            ClientId = clientIdentifier;
            RequestId = Guid.NewGuid();
        }
    }
}
