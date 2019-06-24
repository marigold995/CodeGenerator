using _360.Framework.Api.CyberDetection;
using BusinessMap.Client.Rest.Models;
using System.Collections.Generic;

namespace _360.Api.Facade.GBM.CyberDetection.Service
{
    internal class CyberDetectionProfileService : BusinessMapBaseClient, ISecurityAndITPolicyService
    {
        public CyberDetectionProfileService() : base()
        {

        }

        public IEnumerable<CyberDetectionProfileDto> GetAll() => Execute(() => BusinessMap.Api.CyberDetectionProfile.GetAll());

        public IEnumerable<CyberDetectionProfileDto> GetCyberDetectionProfiles(string companyContext) => Execute(() => BusinessMap.Api.CyberDetectionProfile.GetAllCyberDetectionProfilesByBuyer(companyContext, null, null));

        //public CyberDetectionProfileDto GetById(string id) => Execute(() => BusinessMap.Api.CyberDetectionProfile.GetById(id));
    }
}
