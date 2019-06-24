using _360.Api.Facade.GBM.CyberDetection.Service;
using _360.Domain.CyberDetection;
using _360.Framework.Libs;
using System.Linq;

namespace _360.Api.Facade.GBM.CyberDetection
{
    public partial class CyberDetectionFacade : ICyberDetectionFacade
    {       
        public PagedCollection<CyberService> GetCyberServices(string companyContext)
        {
           return new PagedCollection<CyberService>(entities);
        }       
    }
}