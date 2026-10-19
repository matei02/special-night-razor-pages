using System.Collections.Generic;
using System.Diagnostics;
using ElasticEmail.Api;
using ElasticEmail.Client;
using ElasticEmail.Model;
using Microsoft.Extensions.Configuration;
using Octokit;

namespace Example
{
    public class EmailsTransactionalPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.elasticemail.com/v4";
            // Configure API key authorization: apikey
            config.AddApiKey("X-ElasticEmail-ApiKey", "change-me-to-a-long-random-secret-of-at-least-32-bytes");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("X-ElasticEmail-ApiKey", "Bearer");

            var apiInstance = new EmailsApi(config);
            var emailTransactionalMessageData = new EmailTransactionalMessageData(); // EmailTransactionalMessageData | Email data

            try
            {
                // Send Transactional Email
                EmailSend result = apiInstance.EmailsTransactionalPost(emailTransactionalMessageData);
                Debug.WriteLine(result);
            }
            catch (ElasticEmail.Client.ApiException e)
            {
                Debug.Print("Exception when calling EmailsApi.EmailsTransactionalPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}