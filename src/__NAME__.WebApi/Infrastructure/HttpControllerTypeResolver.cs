using System;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace __NAME__.WebApi.Infrastructure
{
    public class HttpControllerTypeResolver : DefaultHttpControllerTypeResolver
    {
        public HttpControllerTypeResolver()
            : base(IsHttpEndpoint)
        { }

        internal static bool IsHttpEndpoint(Type t)
        {
            if (t == null) throw new ArgumentNullException("t");

            return t.IsClass
                && t.IsVisible
                && !t.IsAbstract
                && typeof(BaseEndpoint).IsAssignableFrom(t)
                && typeof(IHttpController).IsAssignableFrom(t);
        }
    }
}