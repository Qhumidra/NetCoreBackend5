using Blog.Net.Core.Data.Concrete;
using Blog.Net.Core.Extensions;
using Blog.Net.Data.Abstract;
using Blog.Net.Entities.Concrete;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;

namespace Blog.Net.Data.Concrete
{
    public class PostDal : MongoDbRepositoyBase<Post>, IPostDal
    {
        private IMongoCollection<Post> _collection;
        private MongoDbSettings _settings;
        public PostDal(IOptions<MongoDbSettings> options) : base(options)
        {
            _settings = options.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.Database);
            _collection = database.GetCollection<Post>(GetCollectionName(typeof(Post)));
        }
        private static string GetCollectionName(Type documentType)
        {
            return documentType.Name;
        }

        public Post GetByTitle(string title)
        {
            return _collection.Find(p => p.Title == title).FirstOrDefault();
        }
    }
}
