using Blog.Net.Core.Entities.Concrete;
using System.Collections.Generic;

namespace Blog.Net.Services.Abstract
{
    public interface IUserServices
    {
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
        void Add(User user);
    }
}
