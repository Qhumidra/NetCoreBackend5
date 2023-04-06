using Blog.Net.Core.Aspects.Autofac.Validation;
using Blog.Net.Core.Utilities.Result.Abstract;
using Blog.Net.Core.Utilities.Result.Concrete;
using Blog.Net.Data.Abstract;
using Blog.Net.Entities.Concrete;
using Blog.Net.Services.Abstract;
using Blog.Net.Services.BusinessAspects.Autofac;
using Blog.Net.Services.Validation.FluentValidation;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Net.Services.Concrete
{
    public class PostServices : IPostServices
    {
        IPostDal _postDal;

        public PostServices(IPostDal postDal)
        {
            _postDal = postDal;

        }

        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(PostValidator))]
        public IDataResult<Post> Add(Post post)
        {
            var result = _postDal.Create(post);

            return new SuccessDataResult<Post>(result, "Basariyla eklendi.");
        }

        [SecuredOperation("Admin,Member")]
        public IDataResult<Post> GetByTitle(string title)
        {
            var result = _postDal.GetByTitle(title);

            return new SuccessDataResult<Post>(result, "Veri basariyla getirildi.");
        }

        [SecuredOperation("Admin")]
        public IDataResult<Post> GetById(string id)
        {
            var result = _postDal.GetById(id);

            return new SuccessDataResult<Post>(result, "Veri basariyla getirildi.");
        }

        [SecuredOperation("Admin,Member")]
        public IDataResult<List<Post>> GetAll()
        {
            var data = _postDal.GetAll().ToList();

            return new SuccessDataResult<List<Post>>(data, "Veriler basariyla getirildi.");
        }

    }
}
