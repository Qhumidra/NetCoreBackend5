using Blog.Net.Core.Data.Concrete;
using Blog.Net.Core.Entities.Concrete;
using Blog.Net.Core.Extensions;
using Blog.Net.Data.Abstract;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Blog.Net.Data.Concrete
{
    public class OperationClaimsDal : MongoDbRepositoyBase<OperationClaim>, IOperationClaimsDal
    {
        private IMongoCollection<OperationClaim> _collection;
        private MongoDbSettings _settings;
        public OperationClaimsDal(IOptions<MongoDbSettings> options) : base(options)
        {
            _settings = options.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.Database);
            _collection = database.GetCollection<OperationClaim>(GetCollectionName(typeof(OperationClaim)));
        }
        private static string GetCollectionName(Type documentType)
        {
            return documentType.Name;
        }
        public List<OperationClaim> GetByUserId(string userId)
        {
            return _collection.Find(o => o.UserId == userId).ToList();
        }
    }
}
