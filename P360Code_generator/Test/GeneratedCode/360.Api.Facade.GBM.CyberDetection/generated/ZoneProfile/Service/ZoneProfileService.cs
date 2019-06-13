

using _360.Framework.Api.CyberDetection;
using BusinessMap.Client.Rest.Models;
using System.Collections.Generic;

namespace _360.Api.Facade.GBM.CyberDetection.Service
{
    internal class ZoneProfileService : BusinessMapBaseClient, ISecurityAndITPolicyService
    {
        public ZoneProfileService() : base()
        {

        }

        public IEnumerable<ZoneProfileDto> GetAll() => Execute(() => BusinessMap.Api.ZoneProfile.GetAll());

        public IEnumerable<ZoneProfileDto> GetZoneProfiles(string companyContext) => Execute(() => BusinessMap.Api.ZoneProfile.GetAllZoneProfilesByBuyer(companyContext, null, null));

        public ZoneProfileDto GetById(string id) => Execute(() => BusinessMap.Api.ZoneProfile.GetById(id));
    }
}

