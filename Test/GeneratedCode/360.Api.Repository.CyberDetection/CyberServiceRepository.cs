




using _360.Api.FacadeProxy.CyberDetection;
using _360.Domain.CyberDetection;
using _360Generator.Templates;
using _360.Framework.Api.Repositories;
using _360.Framework.Libs;

namespace _360.Api.Repository.CyberDetection
{
    public class CyberServiceRepository : BaseRepository, ICyberServiceRepository
    {
        private readonly CyberDetectionFacadeProxy _cyberDetectionFacadeProxy = null;
		protected CyberDetectionFacadeProxy CyberDetectionFacadeProxy => _cyberDetectionFacadeProxy ?? new CyberDetectionFacadeProxy(CurrentUser);

		  
        public PagedCollection<CyberService> GetCyberServices(string companyContext)
        {
            return CyberServiceFacadeProxy.GetCyberServices(companyContext);
        }
			        
			
			        
			
		

		 

		 
    }
}

