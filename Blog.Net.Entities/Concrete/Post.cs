using Blog.Net.Core.Entities.Abstract;

namespace Blog.Net.Entities.Concrete
{
    public class Post : MongoDbEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
    }
}
