using Blog.Net.Core.Data.Abstract;
using Blog.Net.Entities.Concrete;

namespace Blog.Net.Data.Abstract
{
    public interface IPostDal : IRepository<Post>
    {
        public Post GetByTitle(string title);
    }

}
