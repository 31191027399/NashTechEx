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
        [TestCase("user_1", "books_2")]
        public async Task ReplaceBookInUserCollection(string userKey, string bookKey)
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

            var bookReplace = new DeleteBookRequestDto
            {
                UserId = actualUserInfo.Id,
                Isbn = actualBookInfo[1].Isbn
            };
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

    }
}