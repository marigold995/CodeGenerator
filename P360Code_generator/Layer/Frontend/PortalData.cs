using _360Generator.Metadata;
using _360Generator.Templates;
using _360Generator.Templates.Frontend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Generator.Layer.Frontend
{
    class PortalData: FrontendBaseLayer
    {
        public PortalDataProviderTemplate portalDataProviderTemplate { get; set; }
        public PortalDataServiceTemplate portalDataServiceTemplate{ get; set; }

        public PortalData(Module portalDataModule) : base()
        {
            Module = portalDataModule;            
        }

        public void CreatePortalDataTemplate()
        {
            foreach (var entity in Module.Entities)
            {
                string frontendPath = CreateFrontendFolders(Module.ModuleName, entity.EntityName, "Data");           
              
                portalDataProviderTemplate = new PortalDataProviderTemplate();
                CreateFile(portalDataProviderTemplate, entity, frontendPath, "DataProvider");
                portalDataServiceTemplate = new PortalDataServiceTemplate();
                CreateFile(portalDataServiceTemplate, entity, frontendPath, "DataService");
            }
        }
    }
}
