




using _360.Api.FacadeProxy.CyberDetection;
using _360.Domain.CyberDetection;
using _360Generator.Templates;
using _360.Framework.Api.Repositories;
using _360.Framework.Libs;

namespace _360.Api.Repository.CyberDetection
{
    public class ZoneProfileRepository : BaseRepository, IZoneProfileRepository
    {
        private readonly CyberDetectionFacadeProxy _cyberDetectionFacadeProxy = null;
		protected CyberDetectionFacadeProxy CyberDetectionFacadeProxy => _cyberDetectionFacadeProxy ?? new CyberDetectionFacadeProxy(CurrentUser);

		  
        public PagedCollection<ZoneProfile> GetZoneProfiles(string companyContext)
        {
            return ZoneProfileFacadeProxy.GetZoneProfiles(companyContext);
        }
			        
			
		
        public ZoneProfile GetZoneProfile(string companyContext, string serviceOrderId)
        {
            return ZoneProfileFacadeProxy.GetZoneProfile(companyContext, serviceOrderId);
        }
			        
			
		
		public ZoneProfile Add(ZoneProfile zoneProfile)
        {
            zoneProfile.CreatedBy = CurrentUser.Name;
            return CyberDetectionFacadeProxy.AddZoneProfile(cyberDetection);
        }
		

		
        public void Update( ZoneProfile  zoneProfile)
        {
            zoneProfile.LastModifiedBy = CurrentUser.Name;
            CyberDetectionFacadeProxy.Update ZoneProfile (zoneProfile);
        }
		 

		 
    }
}

