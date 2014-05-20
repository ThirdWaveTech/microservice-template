namespace __NAME__.WebApi.Endpoint
{
    public class Ping : BaseEndpoint
    {
        public dynamic Get()
        {
            return Ok("status=active");
        }
    }
}