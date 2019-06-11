







using _360.Api.FacadeProxy.CyberDetection;
using _360.Domain.CyberDetection;
using _360Generator.Templates;
using _360.Framework.Api.Repositories;
using _360.Framework.Libs;

namespace _360.Api.Repository.CyberDetection
{
    public class CyberDetectionProfileRepository : BaseRepository, ICyberDetectionProfileRepository
    {
        private readonly CyberDetectionProfileFacadeProxy _cyberDetectionProfileFacadeProxy = null;
		protected CyberDetectionFacadeProxy CyberDetectionFacadeProxy => _cyberDetectionFacadeProxy ?? new CyberDetectionFacadeProxy(CurrentUser);

		  
         public PagedCollection<CyberDetectionProfile> GetCyberDetectionProfiles(string companyContext)
        {
            return CyberDetectionProfileFacadeProxy.GetCyberDetectionProfiles(companyContext);
        }
			        
			
		
       public CyberDetectionProfile Add(CyberDetectionProfile cyberDetectionProfile)
        {
            cyberDetectionProfile.CreatedBy = CurrentUser.Name;
            return CyberDetectionFacadeProxy.AddCyberDetectionProfile(cyberDetection);
        }
			        
			
		
       
		
		
        
		 
		 
    }
}

