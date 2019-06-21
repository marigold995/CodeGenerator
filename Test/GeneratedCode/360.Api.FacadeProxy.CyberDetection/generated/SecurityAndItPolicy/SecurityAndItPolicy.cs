using _360.Api.Facade.Document;
using _360.Api.Facade.FileSystem;
using _360.Api.Facade.GBM.Contracting;
using _360.Api.Facade.GBM.CyberDetection;
using _360.Api.Facade.Order;
using _360.Api.Facade.ServiceBus;
using _360.Api.FacadeProxy.Base;
using _360.Api.FacadeProxy.Core;
using _360.Framework.Libs.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace _360.Api.FacadeProxy.CyberDetection
{
    public partial class SecurityAndItPolicyFacadeProxy : BaseFacadeProxy
    {
		  
			  
				public PagedCollection<SecurityAndItPolicy> GetSecurityAndItPolicys(string companyContext)
				{
					return CyberDetectionFacade.GetSecurityAndItPolicys(companyContext);
				}
			
			  
				public SecurityAndItPolicy GetSecurityAndItPolicy(string companyContext, string id)
				{
					return CyberDetectionFacade.GetSecurityAndItPolicy(companyContext, id);
				}
			
			  
				public SecurityAndItPolicy AddSecurityAndItPolicy(SecurityAndItPolicy securityAndItPolicy)
				{
					securityAndItPolicy.LegalContractId = ContractingFacade.GetLegalContractByBuyerAndPcsVersion(securityAndItPolicy.CompanyContext, "VAS-CD-2019")?.LegalContractId;
					return securityAndItPolicy;
				}
			
			  
				public SecurityAndItPolicy UpdateSecurityAndItPolicy(SecurityAndItPolicy securityAndItPolicy)
				{
					securityAndItPolicy.LegalContractId = ContractingFacade.GetLegalContractByBuyerAndPcsVersion(securityAndItPolicy.CompanyContext, "VAS-CD-2019")?.LegalContractId;
					return securityAndItPolicy;
				}
			
			
		
	}
}


