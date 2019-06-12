







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
    public partial class ZoneProfileFacadeProxy : BaseFacadeProxy
    {
		  
			  
				public PagedCollection<ZoneProfile> GetZoneProfiles(string companyContext)
				{
					return CyberDetectionFacade.GetZoneProfiles(companyContext);
				}
			
			  
				public ZoneProfile GetZoneProfile(string companyContext, string id)
				{
					return CyberDetectionFacade.GetZoneProfile(companyContext, id);
				}
			
			  
				public ZoneProfile AddZoneProfile(ZoneProfile zoneProfile)
				{
					zoneProfile.LegalContractId = ContractingFacade.GetLegalContractByBuyerAndPcsVersion(zoneProfile.CompanyContext, "VAS-CD-2019")?.LegalContractId;
					return zoneProfile;
				}
			
			  
				public ZoneProfile UpdateZoneProfile(ZoneProfile zoneProfile)
				{
					zoneProfile.LegalContractId = ContractingFacade.GetLegalContractByBuyerAndPcsVersion(zoneProfile.CompanyContext, "VAS-CD-2019")?.LegalContractId;
					return zoneProfile;
				}
			
			  
				public void DeleteZoneProfile(string id)
				{
					// placeholder
				}
			
		
	}
}


