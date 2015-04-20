using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using __NAME__.Models.Example;

namespace __NAME__.Api.Client.ResourceClients
{
    [Headers("Accept: application/json")]
    public interface IExampleClient
    {
        [Get("/examples")]
        Task<IEnumerable<ExampleModel>> List();

        [Get("/examples/{id}")]
        Task<IEnumerable<ExampleModel>> Get(int id);

        [Post("/examples")]
        Task Create(NewExampleModel model);

        [Post("/examples/close")]
        Task Close(CloseExampleModel model);

        [Delete("/examples/{id}")]
        Task Delete(int id);
    }
}
