using System;
using System.IO;
using System.Threading.Tasks;
using RestSharp;
using DemoQA.Models.Users;
using DemoQA.Models.Books;
using Newtonsoft.Json;

using RestSharp.Serializers;
using DemoQA.API;

namespace DemoQA.Services
{
    public class UserServices
    {
        private readonly APIClients _client;
        public UserServices(APIClients apiClient)
        {
            _client = apiClient;
        }

        public async Task<RestResponse<GetUserTokenDto>> PostUserInfoAndGetToken(object user)
        {
            return await _client.CreateRequests(APIConstants.getTokenEndpoint)
             .AddHeader("Content-Type", ContentType.Json)
             .AddHeader("Accept", ContentType.Json)
             .AddJsonBody(user)
             .ExecutePostAsync<GetUserTokenDto>();
        }
        public async Task<RestResponse<GetUserResponseDto>> GetUserInfoAsync(string userId, string userToken)
        {
            return await _client.CreateRequests(APIConstants.userEndPoint + userId)
            .AddHeader("Content-Type", ContentType.Json)
            .AddHeader("Accept", ContentType.Json)
            .SetRequestHeaderAuthentication(userToken)
            .ExecuteGetAsync<GetUserResponseDto>();
        }
        public async Task<RestResponse<GetUserResponseDto>> GetUserInfoAsyncWithThoutToken(string userId)
        {
            return await _client.CreateRequests(APIConstants.userEndPoint + userId)
            .AddHeader("Content-Type", ContentType.Json)
            .AddHeader("Accept", ContentType.Json)
            .ExecuteGetAsync<GetUserResponseDto>();
        }
        public async Task<RestResponse<AddBookResponseDto>> PostBookToCollection( string userToken, object addBookRequest)
        {
            return await _client.CreateRequests(APIConstants.bookEndPoint)
            .AddHeader("Content-Type", ContentType.Json)
            .AddHeader("Accept", ContentType.Json)
            .SetRequestHeaderAuthentication(userToken)
            .AddJsonBody(addBookRequest)
            .ExecutePostAsync<AddBookResponseDto>();
        }
        public async Task<RestResponse<UnauthorizedResponseDto>> PostBookToCollection2ndTime(string userToken, object addBookRequest)
        {
            return await _client.CreateRequests(APIConstants.bookEndPoint)
            .AddHeader("Content-Type", ContentType.Json)
            .AddHeader("Accept", ContentType.Json)
            .SetRequestHeaderAuthentication(userToken)
            .AddJsonBody(addBookRequest)
            .ExecutePostAsync<UnauthorizedResponseDto>();
        }

        public async Task<RestResponse<GetUserResponseDto>> PutBookAsync(string userToken, object replaceBookRequest, string bookID)
        {
            //Dto for Get User Response and Replacebook response are the same
            string endPointToReplaceBook = APIConstants.bookEndPoint + "/" + bookID;
            return await _client.CreateRequests(endPointToReplaceBook)
             .AddHeader("Content-Type", ContentType.Json)
             .AddHeader("Accept", ContentType.Json)
             .AddJsonBody(replaceBookRequest)
             .SetRequestHeaderAuthentication(userToken)
             .ExecutePutAsync<GetUserResponseDto>();
        }
        public async Task<RestResponse> DeleteBookAsync(object deleteRequest,string token )
        {;
            return await _client.CreateRequests(APIConstants.deleteBookEndPoint)
             .AddHeader("Content-Type", ContentType.Json)
             .AddHeader("Accept", ContentType.Json)
             .SetRequestHeaderAuthentication(token)
             .ExecuteDeleteAsync();
        }
    }
}