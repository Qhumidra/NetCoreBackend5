using Blog.Net.Core.Utilities.Result.Abstract;
using Blog.Net.Entities.Concrete;
using System.Collections.Generic;

namespace Blog.Net.Services.Abstract
{
    public interface IPostServices
    {
        public IDataResult<List<Post>> GetAll();
        public IDataResult<Post> GetByTitle(string title);
        public IDataResult<Post> GetById(string id);
        public IDataResult<Post> Add(Post post);
    }
}
