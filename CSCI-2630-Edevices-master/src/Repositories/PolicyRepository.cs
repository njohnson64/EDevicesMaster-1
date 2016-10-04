using System;
using System.Collections.Generic;
using System.Linq;
using EDeviceClaims.Entities;

namespace EDeviceClaims.Repositories
{
  public interface IPolicyRepository : IEfRepository<Policy, Guid>
  {
    Policy GetByPolicyNumber(string number);
    ICollection<Policy> GetByUserId(string userId);
  }

  public class PolicyRepository : EfRepository<Policy, Guid>, IPolicyRepository
  {
    public PolicyRepository() : base(new EDeviceClaimsUnitOfWork())
    {
    }

    public PolicyRepository(IEfUnitOfWork unitOfWork) : base(unitOfWork) { }

    public Policy GetByPolicyNumber(string number)
    {
      return ObjectSet
        .FirstOrDefault(p => p.Number.ToLower() == number.ToLower());
    }

    public ICollection<Policy> GetByUserId(string userId)
    {
      return ObjectSet.Where(p => p.UserId == userId).ToList();
    }
  }
}