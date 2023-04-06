using Blog.Net.Core.Entities.Abstract;

namespace Blog.Net.Core.Entities.Concrete
{
    public class OperationClaim : MongoDbEntity
    {
        public string Name { get; set; }
        public string UserId { get; set; }
    }
}
