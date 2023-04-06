using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Blog.Net.Core.Entities.Abstract
{
    public abstract class MongoDbEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonId]
        public string Id { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime Date { get; set; } = DateTime.UtcNow;

    }
}
