using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth2;

namespace DemoQA.API
{
    public class APIClients
    {
        private readonly RestClient _client;
        public RestRequest Request;
        public APIClients(RestClient client)
        {
            _client = client;
            Request = new RestRequest();
        }
        public APIClients(string url)
        {
            _client = new RestClient(url);
            Request = new RestRequest();
        }
        public APIClients SetBasicAuthentication(string username, string password)
        {
            _client.Authenticator = new HttpBasicAuthenticator(username, password);
            return this;
        }
        public APIClients SetRequestTokenAuthentication(string consumerKey, string consumerSecret)
        {
            _client.Authenticator = OAuth1Authenticator.ForRequestToken(consumerKey, consumerSecret);
            return this;
        }
        public APIClients SetAccessTokenAuthentication(string consumerKey, string consumerSecret, string oauthToken, string oauthTokenSecret)
        {
            _client.Authenticator = OAuth1Authenticator.ForAccessToken(consumerKey, consumerSecret, oauthToken, oauthTokenSecret);
            return this;
        }
        public APIClients SetRequestHeaderAuthentication(string token, string authType = "Bearer")
        {
            _client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(token, authType);
            return this;
        }
        public APIClients SetJwtAuthenticator(string token)
        {
            _client.Authenticator = new JwtAuthenticator(token);
            return this;
        }
        public APIClients ClearAuthenticator()
        {
            _client.Authenticator = null;
            return this;
        }
        public APIClients AddDetailHeader(Dictionary<string, string> headers)
        {
            _client.AddDefaultHeaders(headers);
            return this;
        }
        public APIClients CreateRequests(string source = "")
        {
            Request = new RestRequest(source);
            return this;
        }
        public APIClients AddHeader(string name, string value)
        {
            Request.AddHeader(name, value);
            return this;
        }
        public APIClients AddAuthorizationHeader(string value)
        {
            return AddHeader("Authoriztion", value);

        }
        public APIClients AddParameter(string name, string value)
        {
            Request.AddParameter(name, value);
            return this;
        }
        public APIClients AddBody(object obj, string contentType = RestSharp.Serializers.ContentType.Json)
        {
            string json = JsonConvert.SerializeObject(obj);
            Request.AddStringBody(json, contentType);
            return this;
        }

        public APIClients AddJsonBody(object obj)
        {
            Request.AddJsonBody(obj);
            return this;
        }
        public APIClients AddStringBody(string obj, string contentType = RestSharp.Serializers.ContentType.Json)
        {
            Request.AddStringBody(obj, contentType);
            return this;
        }
        public async Task<RestResponse> ExecuteGetAsync()
        {
            return await _client.ExecuteGetAsync(Request);

        }
        public async Task<RestResponse<T>> ExecuteGetAsync<T>()
        {
            return await _client.ExecuteGetAsync<T>(Request);
        }
        public async Task<RestResponse> ExecutePostAsync()
        {
            return await _client.ExecutePostAsync(Request);
        }
        public async Task<RestResponse<T>> ExecutePostAsync<T>()
        {
            return await _client.ExecutePostAsync<T>(Request);
        }
        public async Task<RestResponse> ExecuteDeleteAsync()
        {
            Request.Method = Method.Delete;
            return await _client.ExecuteAsync(Request);
        }
        public async Task<RestResponse> ExecutePutAsync()
        {
            return await _client.ExecutePutAsync(Request);
        }
        public async Task<RestResponse<T>> ExecutePutAsync<T>()
        {
            return await _client.ExecutePutAsync<T>(Request);
        }

    }
}