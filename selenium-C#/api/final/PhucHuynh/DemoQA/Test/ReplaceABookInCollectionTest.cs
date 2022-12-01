using System.Collections.Generic;
using System.Net;
using NUnit.Framework;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DemoQA.Models.Users;
using DemoQA.Models.Books;
using FluentAssertions;
using NJsonSchema;
using System.IO;
using DemoQA.Services;

namespace DemoQA.Test
{
    public class ReplaceABookInCollectionTest : BaseTest
    {
        [Test, Description("Replace a book in User Collection")]
        [TestCase("user_1", "switchbooks", "")]
        [TestCase("user_1", "switchbooks", "User not authorized!")]
        [TestCase("user_1", "switchbooks", "ISBN supplied is not available in Books Collection!")]
        [TestCase("user_1", "switchbooks", "User Id not correct!")]
        public async Task ReplaceBookInUserCollection(string userKey, string bookKey, string message)
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
            //Clear All Books in Collection to Avoid errors with existing item
            _userService.ClearAllBookInCollection(actualUserInfo.Id, resultGetToken.Token);
            //Add Book
            var bookRequest = new AddBookRequestDto
            {
                UserId = actualUserInfo.Id,
                CollectionOfIsbns = new List<AddBookIsbnDto>()
                {
                    new AddBookIsbnDto{Isbn =actualBookInfo[0].Isbn}
                }
            };
            var repsonsePostBook = await _userService.PostBookToCollection(resultGetToken.Token, bookRequest);
            var resultPostBook = JsonConvert.DeserializeObject<AddBookResponseDto>(repsonsePostBook.Content);

            var bookReplace = new DeleteBookRequestDto //Reuse DeleteBookRequestDto for switch book case
            {
                UserId = actualUserInfo.Id,
                Isbn = actualBookInfo[1].Isbn
            };

            if (message == "")
            {
                var responseReplaceBook = await _userService.PutBookAsync(resultGetToken.Token, bookReplace, actualBookInfo[0].Isbn);
                var resultReplaceBook = JsonConvert.DeserializeObject<GetUserResponseDto>(responseReplaceBook.Content);
                var schema = await JsonSchema.FromJsonAsync(Library.JsonHelper.ReadJsonFile(Path.GetFullPath(APIConstants.BookInfoSchema)));

                responseReplaceBook.StatusCode.Should().Be(HttpStatusCode.OK);
                schema.Validate(responseReplaceBook.Content).Should().BeEmpty();

                resultReplaceBook.UserName.Should().Be(actualUserInfo.Name);
                resultReplaceBook.Books[0].Isbn.Should().Be(actualBookInfo[1].Isbn);
                resultReplaceBook.Books[0].Title.Should().Be(actualBookInfo[1].Title);
                resultReplaceBook.Books[0].SubTitle.Should().Be(actualBookInfo[1].SubTitle);
                resultReplaceBook.Books[0].Author.Should().Be(actualBookInfo[1].Author);
                resultReplaceBook.Books[0].Publish_date.Should().Be(actualBookInfo[1].Publish_date);
                resultReplaceBook.Books[0].Publisher.Should().Be(actualBookInfo[1].Publisher);
                resultReplaceBook.Books[0].Pages.Should().Be(actualBookInfo[1].Pages);
                resultReplaceBook.Books[0].Description.Should().Be(actualBookInfo[1].Description);
                resultReplaceBook.Books[0].Website.Should().Be(actualBookInfo[1].Website);
            }
            else if (message == "User not authorized!")
            {
                var responseReplaceBook = await _userService.PutBookUnsuccessfullyAsync("", bookReplace, actualBookInfo[0].Isbn);
                var resultReplaceBook = JsonConvert.DeserializeObject<UnauthorizedResponseDto>(responseReplaceBook.Content);
                responseReplaceBook.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
                resultReplaceBook.Code.Should().Be("1200");
                resultReplaceBook.Message.Should().Be(message);


            }
            else if (message == "ISBN supplied is not available in User's Collection!")
            {
                var bookReplaceDummy = new DeleteBookRequestDto //Reuse DeleteBookRequestDto for switch book case
                {
                    Isbn = "23aasd",
                    UserId = actualUserInfo.Id
                };
                var responseReplaceBook = await _userService.PutBookUnsuccessfullyAsync(resultGetToken.Token, bookReplaceDummy, actualBookInfo[0].Isbn);
                var resultReplaceBook = JsonConvert.DeserializeObject<UnauthorizedResponseDto>(responseReplaceBook.Content);
                responseReplaceBook.StatusCode.Should().Be(HttpStatusCode.BadRequest);
                resultReplaceBook.Code.Should().Be("1205");
                resultReplaceBook.Message.Should().Be(message);


            }
            else if (message == "User Id not correct!")
            {
                var bookReplaceDummy  = new DeleteBookRequestDto //Reuse DeleteBookRequestDto for switch book case
                {
                    Isbn = actualBookInfo[1].Isbn,
                    UserId = "asdaasd"
                };
                var responseReplaceBook = await _userService.PutBookUnsuccessfullyAsync(resultGetToken.Token, bookReplaceDummy, actualBookInfo[0].Isbn);
                var resultReplaceBook = JsonConvert.DeserializeObject<UnauthorizedResponseDto>(responseReplaceBook.Content);
                responseReplaceBook.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
                resultReplaceBook.Code.Should().Be("1207");
                resultReplaceBook.Message.Should().Be(message);

            }
        }

    }
}