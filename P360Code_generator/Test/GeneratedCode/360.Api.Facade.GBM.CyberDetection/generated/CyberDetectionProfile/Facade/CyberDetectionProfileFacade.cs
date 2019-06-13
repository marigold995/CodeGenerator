

using _360.Api.Facade.GBM.CyberDetection.Service;
using _360.Domain.CyberDetection;
using _360.Framework.Libs;
using System.Linq;

namespace _360.Api.Facade.GBM.CyberDetection
{
    public partial class CyberDetectionFacade : ICyberDetectionFacade
    {
        private CyberDetectionProfileService _cyberDetectionProfileService;

        private CyberDetectionProfileService CyberDetectionProfileService => _cyberDetectionProfile ?? (_cyberDetectionProfileService = new CyberDetectionProfileService());

        public PagedCollection<CyberDetectionProfile> GetCyberDetectionProfiles(string companyContext)
        {
           return new PagedCollection<CyberDetectionProfile>(entities);
        }

        public CyberDetectionProfile GetCyberDetectionProfile(string companyContext, string id) =>CyberDetectionProfileService.GetById(id).Convert();
    }
}

