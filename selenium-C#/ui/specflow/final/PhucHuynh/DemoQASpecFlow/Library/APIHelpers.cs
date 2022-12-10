using System;
using RestSharp;
using Newtonsoft.Json;
using DemoQASpecFlow.Constants;
using DemoQASpecFlow.Models;
using System.Collections.Generic;

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
        public static dynamic GetAllBookInBookPageByAPI()
        {
            var restClient = new RestClient(ConfigurationHelper.GetConfigurationByKey("ApiURL"));
            var request = new RestRequest(ConfigurationHelper.GetConfigurationByKey("ApiURL") + APIConstants.getAllBooksEnPath, Method.Get);
            var response = restClient.Execute(request);
            var result = JsonConvert.DeserializeObject<AllBooksInfoObject>(response.Content);
            return result;
        }
        public static dynamic PostBookToCollectionByAPI(string userName, string password, string Isbn)
        {
            var loginResult = LoginByApi(userName, password);
            var restClient = new RestClient(ConfigurationHelper.GetConfigurationByKey("ApiURL"));
            var request = new RestRequest(ConfigurationHelper.GetConfigurationByKey("ApiURL") + APIConstants.addBookToCollectionEndPath, Method.Post);
            request.AddHeader("Authorization", $"Bearer {loginResult.token}");
            var bookRequest = new AddBookRequestDto
            {
                UserId = loginResult.userId,
                CollectionOfIsbns = new List<AddBookIsbnDto>()
                {
                    new AddBookIsbnDto{Isbn = Isbn }
                }
            };
            request.AddJsonBody(bookRequest);
            var response = restClient.Execute(request);
            var result = JsonConvert.DeserializeObject<dynamic>(response.Content);
            return result;
        }

    }
}