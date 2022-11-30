using System.Collections.Generic;
using System.Net;
using NUnit.Framework;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DemoQA.Models.Users;
using FluentAssertions;


namespace DemoQA.Test
{
    [TestFixture, Category("API On User account")]
    public class GetUserTest : BaseTest
    {

        [Test, Description("Get and Varify User Info")]
        [TestCase("user_1", "books_1")]
        public async Task GetAndVarifyUserInfo(string userKey, string bookKey)
        {
            IList<BookInfoInUserProfileInputDto> actualBookInfo = _bookInfo[bookKey];
            UserInfoInputDto actualUserInfo = _userInfoInput[userKey];
            var user = new UserInfoAddToGetTokenDto
            {
                UserName = actualUserInfo.Name,
                Password = actualUserInfo.Password
            };
            //Get Token Of User
            var responGetToken = await _userService.PostUserInfoAndGetToken(user);
            var resultGetToken = JsonConvert.DeserializeObject<GetUserTokenDto>(responGetToken.Content);
            //Verify status
            responGetToken.StatusCode.Should().Be(HttpStatusCode.OK);

            //Get User Info
            var response = await _userService.GetUserInfoAsync(actualUserInfo.Id, resultGetToken.Token);
            var result = JsonConvert.DeserializeObject<GetUserResponseDto>(response.Content);
            //Verify status code
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            //Verify UserId and UserName
            result.UserId.Should().Be(actualUserInfo.Id);
            result.UserName.Should().Be(actualUserInfo.Name);
            if (result.Books.Count >0 )
            {
            for (int i = 0; i < result.Books.Count; i++)
            {
                result.Books[i].Isbn.Should().Be(actualBookInfo[i].Isbn);
                result.Books[i].Title.Should().Be(actualBookInfo[i].Title);
                result.Books[i].SubTitle.Should().Be(actualBookInfo[i].SubTitle);
                result.Books[i].Author.Should().Be(actualBookInfo[i].Author);
                result.Books[i].Publish_date.Should().Be(actualBookInfo[i].Publish_date);
                result.Books[i].Publisher.Should().Be(actualBookInfo[i].Publisher);
                result.Books[i].Pages.Should().Be(actualBookInfo[i].Pages);
                result.Books[i].Description.Should().Be(actualBookInfo[i].Description);
                result.Books[i].Website.Should().Be(actualBookInfo[i].Website);
            }
            }
        }

        [Test, Description("Unauthorized when validation token is incorrect")]
        [TestCase("user_1", "books_1")]
        public async Task GenerateUnauthorizedErrorWhenGetUser(string userKey, string bookKey)
        {
            IList<BookInfoInUserProfileInputDto> actualBookInfo = _bookInfo[bookKey];
            UserInfoInputDto actualUserInfo = _userInfoInput[userKey];
            //Get User Info
            var response = await _userService.GetUserInfoAsyncWithThoutToken(actualUserInfo.Id); //token is empty to create Error
            var result = JsonConvert.DeserializeObject<UnauthorizedResponseDto>(response.Content);
            //Verify status code
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
            //Verify UserId and UserName
            result.Code.Should().Be("1200");
            result.Message.Should().Be("User not authorized!");
        }
    }
}