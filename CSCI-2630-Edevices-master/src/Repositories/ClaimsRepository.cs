using EDeviceClaims.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDeviceClaims.Repositories
{
    public interface IClaimsRepository : IEfRepository<ClaimEntity, Guid>
    {
        ClaimEntity GetByPolicyId(Guid policyId);
    }

    public class ClaimsRepository : EfRepository<ClaimEntity, Guid>, IClaimsRepository
    {
        public ClaimsRepository() : base(new EDeviceClaimsUnitOfWork())
        {
        }

        public ClaimsRepository(IEfUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public ClaimEntity GetByPolicyId(Guid policyId)
        {
            throw new NotImplementedException();
        }

    }

}
