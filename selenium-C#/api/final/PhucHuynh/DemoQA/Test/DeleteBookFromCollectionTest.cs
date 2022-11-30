
using System.Collections.Generic;
using System.Net;
using NUnit.Framework;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DemoQA.Models.Users;
using DemoQA.Models.Books;
using FluentAssertions;


namespace DemoQA.Test
{
    [TestFixture, Category("API On Books")]
    public class DeleteBookFromCollectionTest : BaseTest
    {
        [Test, Description("Delete book from collection")]
        [TestCase("user_1", "9781593277574", "")]
        [TestCase("user_1", "9781593277574", "User not authorized!")]
        [TestCase("user_1", "", "ISBN supplied is not available in User's Collection!")]
        [TestCase("user_1", "9781593277574", "User Id not correct!")]
        public async Task DeleteBookFromCollection(string userKey, string bookId, string message)
        {
            UserInfoInputDto actualUserInfo = _userInfoInput[userKey];
            var user = new UserInfoAddToGetTokenDto
            {
                UserName = actualUserInfo.Name,
                Password = actualUserInfo.Password
            };
            //Get Token Of User
            var responGetToken = await _userService.PostUserInfoAndGetToken(user);
            var resultGetToken = JsonConvert.DeserializeObject<GetUserTokenDto>(responGetToken.Content);

            //Add Book
            var bookRequest = new AddBookRequestDto
            {
                UserId = actualUserInfo.Id,
                CollectionOfIsbns = new List<AddBookIsbnDto>()
                {
                    new AddBookIsbnDto{Isbn = bookId}
                }
            };
            var repsonsePostBook = await _userService.PostBookToCollection(resultGetToken.Token, bookRequest);
            var resultPostBook = JsonConvert.DeserializeObject<AddBookResponseDto>(repsonsePostBook.Content);

            // DeleteBook
            var deleteRequest = new DeleteBookRequestDto
            {
                Isbn = bookId,
                UserId = actualUserInfo.Id
            };
            if (message == "")
            {
                var responseDelete = await _userService.DeleteBookAsync(deleteRequest, resultGetToken.Token);
                responseDelete.StatusCode.Should().Be(HttpStatusCode.NoContent);
            }
            else if (message == "User not authorized!")
            {
                var responseDelete = await _userService.DeleteBookAsync(deleteRequest, "");
                var resultDelete = JsonConvert.DeserializeObject<UnauthorizedResponseDto>(responseDelete.Content);
                responseDelete.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
                resultDelete.Code.Should().Be("1200");
                resultDelete.Message.Should().Be(message);

                //METHOD DELETE BELOW IS USED TO CLEAN UP 
                var responseDeleteCleanUp = await _userService.DeleteBookAsync(deleteRequest, resultGetToken.Token);
            }
            else if (message == "ISBN supplied is not available in User's Collection!")
            {
                var responseDelete = await _userService.DeleteBookAsync(deleteRequest, resultGetToken.Token);
                var resultDelete = JsonConvert.DeserializeObject<UnauthorizedResponseDto>(responseDelete.Content);
                responseDelete.StatusCode.Should().Be(HttpStatusCode.BadRequest);
                resultDelete.Code.Should().Be("1206");
                resultDelete.Message.Should().Be(message);

                //METHOD DELETE BELOW IS USED TO CLEAN UP 
                var responseDeleteCleanUp = await _userService.DeleteBookAsync(deleteRequest, resultGetToken.Token);
            }
            else if (message == "User Id not correct!")
            {
                var deleteRequestDummy = new DeleteBookRequestDto
                {
                    Isbn = bookId,
                    UserId = "asdaasd"
                };
                var responseDelete = await _userService.DeleteBookAsync(deleteRequestDummy, resultGetToken.Token);
                var resultDelete = JsonConvert.DeserializeObject<UnauthorizedResponseDto>(responseDelete.Content);
                responseDelete.StatusCode.Should().Be(HttpStatusCode.BadRequest);
                resultDelete.Code.Should().Be("1207");
                resultDelete.Message.Should().Be(message);

                //METHOD DELETE BELOW IS USED TO CLEAN UP 
                var responseDeleteCleanUp = await _userService.DeleteBookAsync(deleteRequest, resultGetToken.Token);

            }
        }
    }
}