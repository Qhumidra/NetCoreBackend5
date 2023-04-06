using Blog.Net.Core.Data.Abstract;
using Blog.Net.Core.Entities.Concrete;
using System.Collections.Generic;

namespace Blog.Net.Data.Abstract
{
    public interface IOperationClaimsDal : IRepository<OperationClaim>
    {
        public List<OperationClaim> GetByUserId(string userId);
    }
}
