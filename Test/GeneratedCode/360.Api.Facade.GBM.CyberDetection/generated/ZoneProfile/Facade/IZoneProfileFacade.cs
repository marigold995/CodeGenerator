using _360.Domain.CyberDetection;
using _360.Framework.Libs;

namespace _360.Api.Facade.GBM.CyberDetection
{
    public partial interface ICyberDetectionFacade
    {
        PagedCollection<ZoneProfile> GetZoneProfiles(string companyContext);
    }
}
