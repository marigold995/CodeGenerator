




using _360.Framework.Api.CyberDetection;
using BusinessMap.Client.Rest.Models;
using System.Collections.Generic;

namespace _360.Api.Facade.GBM.CyberDetection.Service
{
    internal class CyberServiceService : BusinessMapBaseClient, ISecurityAndITPolicyService
    {
        public CyberServiceService() : base()
        {

        }

        public IEnumerable<CyberServiceDto> GetAll() => Execute(() => BusinessMap.Api.CyberService.GetAll());

        public IEnumerable<CyberServiceDto> GetCyberServices(string companyContext) => Execute(() => BusinessMap.Api.CyberService.GetAllCyberServicesByBuyer(companyContext, null, null));

        public CyberServiceDto GetById(string id) => Execute(() => BusinessMap.Api.CyberService.GetById(id));
    }
}
