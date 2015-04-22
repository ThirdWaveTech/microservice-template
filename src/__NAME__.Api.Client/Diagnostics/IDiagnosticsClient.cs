using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using __NAME__.Models.Diagnostics;

namespace __NAME__.Api.Client.Diagnostics
{
    /****
     * Group functionality in the API via interfaces. All maintenance and info related 
     * api's should be added to this file.
     ****/
    [Headers(
        "Accept: application/json",
        "User-Agent: __NAME__ Web Client")]
    public interface IDiagnosticsClient
    {
        [Get("/ping")]
        Task<string> Ping();

        [Get("/status")]
        Task<IList<StatusItem>> ListStatus();
    }
}
