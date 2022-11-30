
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
    public class AddBookToCollectionTest : BaseTest
    {

        [Test, Description("Add Book to Collection")]
        [TestCase("user_1", "9781449325862","")]
        [TestCase("user_1", "9781449325862", "User not authorized!")]
        [TestCase("user_1", "9781449362", "ISBN supplied is not available in Books Collection!")]
        [TestCase("user_1", "9781449325862", "ISBN already present in the User's Collection!")]
        public async Task AddBookToCollection(string userKey, string bookId, string message)
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
            //Verify status
            responGetToken.StatusCode.Should().Be(HttpStatusCode.OK);

            //Add Book
            var bookRequest = new AddBookRequestDto
            {
                UserId = actualUserInfo.Id,
                CollectionOfIsbns = new List<AddBookIsbnDto>()
                {
                    new AddBookIsbnDto{Isbn = bookId}
                }
            };
            if (message == "")
            {
                var repsonsePostBook = await _userService.PostBookToCollection(resultGetToken.Token, bookRequest);
                var resultPostBook = JsonConvert.DeserializeObject<AddBookResponseDto>(repsonsePostBook.Content);
                //Verify status
                repsonsePostBook.StatusCode.Should().Be(HttpStatusCode.Created);
                resultPostBook.Books[0].Isbn.Should().Be(bookId);
            }
            else if (message == "User not authorized!")
            {
                var repsonsePostBook = await _userService.PostBookToCollection2ndTime( "", bookRequest);
                var resultPostBook = JsonConvert.DeserializeObject<UnauthorizedResponseDto>(repsonsePostBook.Content);
                //Verify status
                repsonsePostBook.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
                resultPostBook.Code.Should().Be("1200");
                resultPostBook.Message.Should().Be(message);
            }
            else if (message == "ISBN supplied is not available in Books Collection!")
            {
                var repsonsePostBook = await _userService.PostBookToCollection2ndTime( resultGetToken.Token, bookRequest);
                var resultPostBook = JsonConvert.DeserializeObject<UnauthorizedResponseDto>(repsonsePostBook.Content);
                //Verify status
                repsonsePostBook.StatusCode.Should().Be(HttpStatusCode.BadRequest);
                resultPostBook.Code.Should().Be("1205");
                resultPostBook.Message.Should().Be(message);
            }
            else if (message == "ISBN already present in the User's Collection!")
            {
                var repsonsePostBook = await _userService.PostBookToCollection( resultGetToken.Token, bookRequest);
                var resultPostBook = JsonConvert.DeserializeObject<AddBookResponseDto>(repsonsePostBook.Content);

                var repsonsePostBook2nd = await _userService.PostBookToCollection2ndTime( resultGetToken.Token, bookRequest);
                var resultPostBook2nd = JsonConvert.DeserializeObject<UnauthorizedResponseDto>(repsonsePostBook2nd.Content);
                //Verify Status
                repsonsePostBook2nd.StatusCode.Should().Be(HttpStatusCode.BadRequest);
                resultPostBook2nd.Code.Should().Be("1210");
                resultPostBook2nd.Message.Should().Be(message);
            }

        }
    }
}