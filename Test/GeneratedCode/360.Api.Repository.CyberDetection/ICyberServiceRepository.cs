using _360.Domain.CyberDetection;
using _360Generator.Templates;
using _360.Framework.Api.Repositories;
using _360.Framework.Libs;

namespace _360.Api.Repository.CyberDetection
{
    public interface ICyberServiceRepository : IBaseRepository
    {  
        PagedCollection<CyberService> GetCyberServices(string companyContext);
    }
}

