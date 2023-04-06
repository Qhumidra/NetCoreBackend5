using Blog.Net.Core.Entities.Concrete;
using Blog.Net.Core.Utilities.Result.Abstract;
using Blog.Net.Core.Utilities.Result.Concrete;
using Blog.Net.Core.Utilities.Security.Hashing;
using Blog.Net.Core.Utilities.Security.JWT;
using Blog.Net.Entities.DTOs;
using Blog.Net.Services.Abstract;

namespace Blog.Net.Services.Concrete
{
    public class AuthServices : IAuthServices
    {
        private IUserServices _userService;
        private ITokenHelper _tokenHelper;
        private readonly IOperationClaimServices _operationClaimServices;

        public AuthServices(IUserServices userService, ITokenHelper tokenHelper, IOperationClaimServices operationClaimServices)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _operationClaimServices = operationClaimServices;
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>("Kullanici mevcut degil!!");
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>("Parola hatasi!!");
            }

            return new SuccessDataResult<User>(userToCheck);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                Name = userForRegisterDto.FirstName,
                Surname = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            _operationClaimServices.Add(new OperationClaim { Name = "Member", UserId = user.Id });
            return new SuccessDataResult<User>(user);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult("Kulanici mevcut!!");
            }

            return new SuccessResult();
        }
    }
}
