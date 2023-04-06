using Blog.Net.Core.Data.Abstract;
using Blog.Net.Core.Entities.Abstract;
using Blog.Net.Core.Extensions;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Net.Core.Data.Concrete
{
    public class MongoDbRepositoyBase<T> : IRepository<T> where T : MongoDbEntity
    {
        private IMongoCollection<T> _collection;
        private MongoDbSettings _settings;

        public MongoDbRepositoyBase(IOptions<MongoDbSettings> options)
        {
            _settings = options.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.Database);
            _collection = database.GetCollection<T>(GetCollectionName(typeof(T)));
        }
        private static string GetCollectionName(Type documentType)
        {
            return documentType.Name;
        }
        public List<T> GetAll()
        {
            return _collection.Find(t => true).ToList();
        }

        public T GetById(string id)
        {
            return _collection.Find(t => t.Id == id).FirstOrDefault();
        }

        public T Create(T entity)
        {
            _collection.InsertOne(entity);
            return entity;
        }

        public DeleteResult Delete(string id)
        {


            return _collection.DeleteOne(t => t.Id == id);
        }

        public ReplaceOneResult Update(string id, T entity)
        {


            return _collection.ReplaceOne(t => t.Id == id, entity);
        }
    }
}
