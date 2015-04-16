using System.Threading.Tasks;
using Refit;
using __NAME__.Models.ClientInfo;

namespace __NAME__.Api.Client.ResourceClients
{
    /****
     * Group functionality in the API via interfaces. All maintenance and info related 
     * api's should be added to this file.
     * 
     * 
     ****/
    [Headers("User-Agent: __NAME__ Web Client")]
    public interface IApiInfoClient
    {
        [Get("/ping")]
        Task<string> Get();

        [Post("/clientinfo/register")]
        Task Post([Body] RegisterClientModel registerClientModel, [Header("Authorization")] string token);
    }
}
