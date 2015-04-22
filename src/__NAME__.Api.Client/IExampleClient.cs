using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using __NAME__.Models.Example;

namespace __NAME__.Api.Client
{
    /// <summary>
    /// This is a sample interface to the Api built using Restfit.  This file 
    /// is provided for illustrative purposes only.
    /// </summary>
    [Headers(
        "Accept: application/json", 
        "User-Agent: __NAME__ Web Client")]
    public interface IExampleClient
    {
        [Get("/examples")]
        Task<IEnumerable<ExampleModel>> List();

        [Get("/example/{id}")]
        Task<ExampleModel> Get(int id);

        [Post("/examples")]
        Task<NewExampleCreatedModel> Create([Body] NewExampleModel model);

        [Post("/examples/close")]
        Task Close([Body] CloseExampleModel model);

        [Delete("/example/{id}")]
        Task Delete(int id);
    }
}
