using System;
using System.Collections.Specialized;
using System.Configuration;
using Refit;

/*****
 *  In order to use this client add the following to your appconfig or webconfig
 *  <__NAME__Settings file="App_Data\Config\__NAME__Settings.config" />
 *  In your file you should add the following : 
 *   </__NAME__Settings>
 *   <add key="__NAME__.api.path" value ="***PATHTOAPI***"/>
 *   </__NAME__Settings>
 *  
 * 
 ******/
namespace __NAME__.Api.Client
{
    public class __NAME__ClientFactory
    {
        private const string ERROR_STRING = "Configuration section is missing. Please add __NAME___Settings and provide a value for {0}";
        private static readonly string ApiConfigKey = "__NAME__.api.path".ToLower();

        public static T GetClient<T>()
        {
            var apiUrl = GetServiceUrlFromConfig();

            AssertValidConfiguration(() => apiUrl != null);

            return RestService.For<T>(apiUrl);
        }

        private static string GetServiceUrlFromConfig()
        {
            var configSection = ConfigurationManager.GetSection("SFV_Settings") as NameValueCollection;

            AssertValidConfiguration(() => configSection != null);

            // ReSharper disable once PossibleNullReferenceException
            return configSection.Get(ApiConfigKey);
        }

        private static void AssertValidConfiguration(Func<bool> valueIsTrue)
        {
            if (valueIsTrue())
            {
                throw new Exception(string.Format(ERROR_STRING, ApiConfigKey));
            }
        }
    }
}
