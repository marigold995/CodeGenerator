




using _360.Api.Facade.GBM.CyberDetection.Service;
using _360.Domain.CyberDetection;
using _360.Framework.Libs;
using System.Linq;

namespace _360.Api.Facade.GBM.CyberDetection
{
    public partial class CyberDetectionFacade : ICyberDetectionFacade
    {
        private CyberServiceService _cyberServiceService;

        private CyberServiceService CyberServiceService => _cyberService ?? (_cyberServiceService = new CyberServiceService());

        public PagedCollection<CyberService> GetCyberServices(string companyContext)
        {
           return new PagedCollection<CyberService>(entities);
        }

        public CyberService GetCyberService(string companyContext, string id) =>CyberServiceService.GetById(id).Convert();
    }
}

