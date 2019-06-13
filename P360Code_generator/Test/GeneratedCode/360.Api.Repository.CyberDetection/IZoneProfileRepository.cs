







using _360.Domain.CyberDetection;
using _360Generator.Templates;
using _360.Framework.Api.Repositories;
using _360.Framework.Libs;

namespace _360.Api.Repository.CyberDetection
{
    public interface IZoneProfileRepository : IBaseRepository
    {
		  
        PagedCollection<ZoneProfile> GetZoneProfiles(string companyContext);
			        
			
		
        ZoneProfile GetZoneProfile(string companyContext, string serviceOrderId);
			        
			
		
        ZoneProfile Add(ZoneProfile ZoneProfile);
		
		
        void Update(ZoneProfile ZoneProfile); 
		 
		
		void Delete(string companyContext, string serviceOrderId);
		 
    }
}

