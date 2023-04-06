using Blog.Net.Core.Entities.Concrete;
using Blog.Net.Data.Abstract;
using Blog.Net.Services.Abstract;
using System.Collections.Generic;

namespace Blog.Net.Services.Concrete
{
    public class UserService : IUserServices
    {
        IUserDal _userDal;
        IOperationClaimServices _operationClaimServices;
        public UserService(IUserDal userDal, IOperationClaimServices operationClaimServices)
        {
            _userDal = userDal;
            _operationClaimServices = operationClaimServices;
        }
        public void Add(User user)
        {
            _userDal.Create(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.GetByEmail(email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            var result = GetClaimQuery(user.Id);
            return result;
        }
        private List<OperationClaim> GetClaimQuery(string userId)
        {
            var result = _operationClaimServices.GetByUserId(userId);
            return result;
        }
    }
}
