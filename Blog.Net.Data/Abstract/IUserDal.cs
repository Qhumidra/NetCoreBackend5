using Blog.Net.Core.Data.Abstract;
using Blog.Net.Core.Entities.Concrete;

namespace Blog.Net.Data.Abstract
{
    public interface IUserDal : IRepository<User>
    {
        public User GetByEmail(string email);
    }

}
