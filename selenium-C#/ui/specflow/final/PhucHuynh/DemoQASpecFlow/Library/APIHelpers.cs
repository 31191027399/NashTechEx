using System;
using RestSharp;
using Newtonsoft.Json;
using DemoQASpecFlow.Constants;
using Faker.Resources;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace DemoQASpecFlow.Library
{
    public class APIHelpers
    {
        public static dynamic LoginByApi(string userName, string password)
        {
            var restClient = new RestClient(ConfigurationHelper.GetConfigurationByKey("ApiURL"));
            var request = new RestRequest(ConfigurationHelper.GetConfigurationByKey("ApiURL") + APIConstants.loginEndPath, Method.Post);
            var param = new
            {
                UserName = userName,
                Password = password
            };
            request.AddJsonBody(param);
            var response = restClient.Execute(request);
            var result = JsonConvert.DeserializeObject<dynamic>(response.Content);
            return result;
        }
        public static void ClearAllBookInCollectionByAPI(string userName, string password)
        {
            var loginResult = LoginByApi(userName, password);
            var restClient = new RestClient(ConfigurationHelper.GetConfigurationByKey("ApiURL"));
            var request = new RestRequest(ConfigurationHelper.GetConfigurationByKey("ApiURL") + APIConstants.deleteAllBooksEndPath + loginResult.userId, Method.Delete);
            request.AddHeader("Authorization", $"Bearer {loginResult.token}");
            var response = restClient.Execute(request);
            var result = JsonConvert.DeserializeObject<dynamic>(response.Content);
        }

    }
}