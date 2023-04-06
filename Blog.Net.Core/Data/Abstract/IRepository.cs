using Blog.Net.Core.Entities.Abstract;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Blog.Net.Core.Data.Abstract
{
    public interface IRepository<T> where T : MongoDbEntity
    {
        List<T> GetAll();
        T GetById(string id);
        T Create(T entity);
        ReplaceOneResult Update(string id, T entity);
        DeleteResult Delete(string id);
    }
}
