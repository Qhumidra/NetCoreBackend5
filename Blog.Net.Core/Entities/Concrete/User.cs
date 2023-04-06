using Blog.Net.Core.Entities.Abstract;

namespace Blog.Net.Core.Entities.Concrete
{
    public class User : MongoDbEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool Status { get; set; }
    }
}
