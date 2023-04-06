using Blog.Net.Core.Entities.Concrete;
using Blog.Net.Data.Abstract;
using Blog.Net.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Net.Services.Concrete
{
    public class OperationClaimServices : IOperationClaimServices
    {
        IOperationClaimsDal _operationClaimsDal;
        public OperationClaimServices(IOperationClaimsDal operationClaimsDal)
        {
            _operationClaimsDal = operationClaimsDal;
        }
        public OperationClaim Add(OperationClaim operationClaim)
        {
            var result = _operationClaimsDal.Create(operationClaim);

            return result;
        }

        public List<OperationClaim> GetByUserId(string userId)
        {
            var result = _operationClaimsDal.GetByUserId(userId);
            return result;
        }
    }
}
