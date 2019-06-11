







using _360.Api.FacadeProxy.CyberDetection;
using _360.Domain.CyberDetection;
using _360Generator.Templates;
using _360.Framework.Api.Repositories;
using _360.Framework.Libs;

namespace _360.Api.Repository.CyberDetection
{
    public class SecurityAndItPolicyRepository : BaseRepository, ISecurityAndItPolicyRepository
    {
        private readonly SecurityAndItPolicyFacadeProxy _securityAndItPolicyFacadeProxy = null;
		protected CyberDetectionFacadeProxy CyberDetectionFacadeProxy => _cyberDetectionFacadeProxy ?? new CyberDetectionFacadeProxy(CurrentUser);

		  
         public PagedCollection<SecurityAndItPolicy> GetSecurityAndItPolicys(string companyContext)
        {
            return SecurityAndItPolicyFacadeProxy.GetSecurityAndItPolicys(companyContext);
        }
			        
			
		
       public SecurityAndItPolicy Add(SecurityAndItPolicy securityAndItPolicy)
        {
            securityAndItPolicy.CreatedBy = CurrentUser.Name;
            return CyberDetectionFacadeProxy.AddSecurityAndItPolicy(cyberDetection);
        }
			        
			
		
       
		
		
        
		 
		
		
		 
    }
}

