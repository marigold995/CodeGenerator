

using _360.Api.Facade.GBM.CyberDetection.Service;
using _360.Domain.CyberDetection;
using _360.Framework.Libs;
using System.Linq;

namespace _360.Api.Facade.GBM.CyberDetection
{
    public partial class CyberDetectionFacade : ICyberDetectionFacade
    {
        private SecurityAndItPolicyService _securityAndItPolicyService;

        private SecurityAndItPolicyService SecurityAndItPolicyService => _securityAndItPolicy ?? (_securityAndItPolicyService = new SecurityAndItPolicyService());

        public PagedCollection<SecurityAndItPolicy> GetSecurityAndItPolicys(string companyContext)
        {
           return new PagedCollection<SecurityAndItPolicy>(entities);
        }

        public SecurityAndItPolicy GetSecurityAndItPolicy(string companyContext, string id) =>SecurityAndItPolicyService.GetById(id).Convert();
    }
}

