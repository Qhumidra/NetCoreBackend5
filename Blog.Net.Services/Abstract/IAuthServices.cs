using Blog.Net.Core.Entities.Concrete;
using Blog.Net.Core.Utilities.Result.Abstract;
using Blog.Net.Core.Utilities.Security.JWT;
using Blog.Net.Entities.DTOs;

namespace Blog.Net.Services.Abstract
{
    public interface IAuthServices
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
