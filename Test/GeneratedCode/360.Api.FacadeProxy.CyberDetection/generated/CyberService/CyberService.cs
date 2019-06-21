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
    public partial class CyberServiceFacadeProxy : BaseFacadeProxy
    {  
		public PagedCollection<CyberService> GetCyberServices(string companyContext)
		{
			return CyberDetectionFacade.GetCyberServices(companyContext);
		}	
	}
}


