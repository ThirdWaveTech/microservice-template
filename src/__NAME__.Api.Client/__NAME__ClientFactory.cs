using System;
using System.Configuration;
using Refit;

/*****
 *  In your appsettings add the following : 
 *   <add key="__NAME__.api.path" value ="***PATHTOAPI***"/>
 ******/
namespace __NAME__.Api.Client
{
    public class __NAME__ClientFactory
    {
        private const string ERROR_STRING = "Configuration section is missing. {0} to your app settings and provide a valid URL";
        private static readonly string ApiConfigKey = "__NAME__.api.path".ToLower();

        public static T GetClient<T>()
        {
            var apiUrl = GetServiceUrlFromConfig();

            AssertValidConfiguration(() => apiUrl != null);

            return RestService.For<T>(apiUrl);
        }

        private static string GetServiceUrlFromConfig()
        {
            var serviceUrl = ConfigurationManager.AppSettings.Get(ApiConfigKey);

            return serviceUrl;
        }

        private static void AssertValidConfiguration(Func<bool> valueIsTrue)
        {
            if (!valueIsTrue())
            {
                throw new Exception(string.Format(ERROR_STRING, ApiConfigKey));
            }
        }
    }
}
