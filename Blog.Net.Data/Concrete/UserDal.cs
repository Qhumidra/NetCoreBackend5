using Blog.Net.Core.Data.Concrete;
using Blog.Net.Core.Entities.Concrete;
using Blog.Net.Core.Extensions;
using Blog.Net.Data.Abstract;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;

namespace Blog.Net.Data.Concrete
{
    public class UserDal : MongoDbRepositoyBase<User>, IUserDal
    {
        private IMongoCollection<User> _collection;
        private MongoDbSettings _settings;
        public UserDal(IOptions<MongoDbSettings> options) : base(options)
        {
            _settings = options.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.Database);
            _collection = database.GetCollection<User>(GetCollectionName(typeof(User)));
        }
        private static string GetCollectionName(Type documentType)
        {
            return documentType.Name;
        }
        public User GetByEmail(string email)
        {
            return _collection.Find(u => u.Email == email).FirstOrDefault();
        }

    }
}
