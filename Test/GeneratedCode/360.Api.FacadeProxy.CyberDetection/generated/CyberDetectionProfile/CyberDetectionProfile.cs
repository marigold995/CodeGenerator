







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
    public partial class CyberDetectionProfileFacadeProxy : BaseFacadeProxy
    {
		  
			  
				public PagedCollection<CyberDetectionProfile> GetCyberDetectionProfiles(string companyContext)
				{
					return CyberDetectionFacade.GetCyberDetectionProfiles(companyContext);
				}
			
			  
				public CyberDetectionProfile GetCyberDetectionProfile(string companyContext, string id)
				{
					return CyberDetectionFacade.GetCyberDetectionProfile(companyContext, id);
				}
			
			  
				public CyberDetectionProfile AddCyberDetectionProfile(CyberDetectionProfile cyberDetectionProfile)
				{
					cyberDetectionProfile.LegalContractId = ContractingFacade.GetLegalContractByBuyerAndPcsVersion(cyberDetectionProfile.CompanyContext, "VAS-CD-2019")?.LegalContractId;
					return cyberDetectionProfile;
				}
			
			  
				public CyberDetectionProfile UpdateCyberDetectionProfile(CyberDetectionProfile cyberDetectionProfile)
				{
					cyberDetectionProfile.LegalContractId = ContractingFacade.GetLegalContractByBuyerAndPcsVersion(cyberDetectionProfile.CompanyContext, "VAS-CD-2019")?.LegalContractId;
					return cyberDetectionProfile;
				}
			
			
		
	}
}


