using System.Threading.Tasks;
using Refit;
using __NAME__.Messages.Models;

namespace __NAME__.Api.Client.ResourceClients
{
    [Headers("User-Agent: __NAME__ Web Client")]
    public interface IApiInfoClient
    {
        [Get("/ping")]
        Task<string> Get();

        [Post("/clientinfo/register")]
        Task Post([Body] RegisterClientModel registerClientModel, [Header("Authorization")] string token);
    }
}
