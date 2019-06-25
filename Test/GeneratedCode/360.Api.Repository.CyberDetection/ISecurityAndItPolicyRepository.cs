using _360.Domain.CyberDetection;
using _360Generator.Templates;
using _360.Framework.Api.Repositories;
using _360.Framework.Libs;

namespace _360.Api.Repository.CyberDetection
{
    public interface ISecurityAndItPolicyRepository : IBaseRepository
    {  
        PagedCollection<SecurityAndItPolicy> GetSecurityAndItPolicys(string companyContext);

        SecurityAndItPolicy GetSecurityAndItPolicy(string companyContext, string serviceOrderId);

        SecurityAndItPolicy Add(SecurityAndItPolicy securityAndItPolicy);

        void Update(SecurityAndItPolicy securityAndItPolicy); 

		void Delete(string companyContext, string serviceOrderId);    }
}

