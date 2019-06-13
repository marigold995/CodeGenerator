







using _360.Api.FacadeProxy.CyberDetection;
using _360.Domain.CyberDetection;
using _360Generator.Templates;
using _360.Framework.Api.Repositories;
using _360.Framework.Libs;

namespace _360.Api.Repository.CyberDetection
{
    public class SecurityAndItPolicyRepository : BaseRepository, ISecurityAndItPolicyRepository
    {
        private readonly CyberDetectionFacadeProxy _cyberDetectionFacadeProxy = null;
		protected CyberDetectionFacadeProxy CyberDetectionFacadeProxy => _cyberDetectionFacadeProxy ?? new CyberDetectionFacadeProxy(CurrentUser);

		  
        public PagedCollection<SecurityAndItPolicy> GetSecurityAndItPolicys(string companyContext)
        {
            return SecurityAndItPolicyFacadeProxy.GetSecurityAndItPolicys(companyContext);
        }
			        
			
		
        public SecurityAndItPolicy GetSecurityAndItPolicy(string companyContext, string serviceOrderId)
        {
            return SecurityAndItPolicyFacadeProxy.GetSecurityAndItPolicy(companyContext, serviceOrderId);
        }
			        
			
		
		public SecurityAndItPolicy Add(SecurityAndItPolicy securityAndItPolicy)
        {
            securityAndItPolicy.CreatedBy = CurrentUser.Name;
            return CyberDetectionFacadeProxy.AddSecurityAndItPolicy(cyberDetection);
        }
		
		
        public void Update( SecurityAndItPolicy  securityAndItPolicy)
        {
            securityAndItPolicy.LastModifiedBy = CurrentUser.Name;
            CyberDetectionFacadeProxy.Update SecurityAndItPolicy (securityAndItPolicy);
        }
		 

		
			public void Delete(string companyContext, string securityAndItPolicyId)
        {
            CyberDetectionFacadeProxy.Delete SecurityAndItPolicy(securityAndItPolicyId);
        }
		 
    }
}

