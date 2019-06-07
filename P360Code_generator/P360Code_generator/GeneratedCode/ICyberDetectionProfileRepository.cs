
using _360.Domain.CyberDetection;
using P360Code_generator.Templates;
using _360.Framework.Api.Repositories;
using _360.Framework.Libs;

namespace _360.Api.Repository.CyberDetection
{
    public interface ICyberDetectionProfileRepository : IBaseRepository
    {
        PagedCollection<CyberDetectionProfile> GetCyberDetectionProfiles(string companyContext);
        CyberDetectionProfile GetCyberDetectionProfile(string companyContext, string serviceOrderId);
        CyberDetectionProfile Add(CyberDetectionProfile CyberDetectionProfile);
        void Update(CyberDetectionProfile CyberDetectionProfile);
        void ApproveCyberDetectionProfile(string companyContext, string serviceOrderId);
    }
}

