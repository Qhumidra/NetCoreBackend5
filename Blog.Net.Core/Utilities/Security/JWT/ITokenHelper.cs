using Blog.Net.Core.Entities.Concrete;
using System.Collections.Generic;

namespace Blog.Net.Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
