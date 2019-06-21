using _360.Framework.Api.CyberDetection;
using BusinessMap.Client.Rest.Models;
using System.Collections.Generic;

namespace _360.Api.Facade.GBM.CyberDetection.Service
{
    internal class SecurityAndItPolicyService : BusinessMapBaseClient, ISecurityAndITPolicyService
    {
        public SecurityAndItPolicyService() : base()
        {

        }

        public IEnumerable<SecurityAndItPolicyDto> GetAll() => Execute(() => BusinessMap.Api.SecurityAndItPolicy.GetAll());

        public IEnumerable<SecurityAndItPolicyDto> GetSecurityAndItPolicys(string companyContext) => Execute(() => BusinessMap.Api.SecurityAndItPolicy.GetAllSecurityAndItPolicysByBuyer(companyContext, null, null));

        public SecurityAndItPolicyDto GetById(string id) => Execute(() => BusinessMap.Api.SecurityAndItPolicy.GetById(id));
    }
}
using _360.Framework.Api.CyberDetection;
using BusinessMap.Client.Rest.Models;
using System.Collections.Generic;

namespace _360.Api.Facade.GBM.CyberDetection.Service
{
    internal class SecurityAndItPolicyService : BusinessMapBaseClient, ISecurityAndITPolicyService
    {
        public SecurityAndItPolicyService() : base()
        {

        }

        public IEnumerable<SecurityAndItPolicyDto> GetAll() => Execute(() => BusinessMap.Api.SecurityAndItPolicy.GetAll());

        public IEnumerable<SecurityAndItPolicyDto> GetSecurityAndItPolicys(string companyContext) => Execute(() => BusinessMap.Api.SecurityAndItPolicy.GetAllSecurityAndItPolicysByBuyer(companyContext, null, null));

        public SecurityAndItPolicyDto GetById(string id) => Execute(() => BusinessMap.Api.SecurityAndItPolicy.GetById(id));
    }
}
