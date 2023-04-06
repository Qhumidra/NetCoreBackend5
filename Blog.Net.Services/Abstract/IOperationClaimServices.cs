using Blog.Net.Core.Entities.Concrete;
using System.Collections.Generic;

namespace Blog.Net.Services.Abstract
{
    public interface IOperationClaimServices
    {
        public OperationClaim Add(OperationClaim operationClaim);
        public List<OperationClaim> GetByUserId(string userId);
    }
}
