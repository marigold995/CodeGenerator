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
    class PortalData: LayerBase
    {
        public PortalDataProviderTemplate portalDataProviderTemplate { get; set; }
        public PortalDataServiceTemplate portalDataServiceTemplate{ get; set; }

        public PortalData(Module portalDataModule) : base()
        {
            Module = portalDataModule;

            Extension = ExtensionEnum.ts;
            FolderPrefix = "P360.Web.";
        }

        public void CreatePortalDataTemplate()
        {
            foreach (var entity in Module.Entities)
            {
                string path0 = CreateFolder(rootPath, FolderPrefix);
                string pathDomain = CreateFolder(path0, "Scripts");
                string pathApp = CreateFolder(pathDomain, "App");
                string pathModule = CreateFolder(pathApp, Module.ModuleName); 
                string pathEntity = CreateFolder(pathModule, entity.EntityName);
                string pathData = CreateFolder(pathEntity, "Data");
              
                portalDataProviderTemplate = new PortalDataProviderTemplate();
                CreateFile(portalDataProviderTemplate, entity, pathData, "DataProvider");
                portalDataServiceTemplate = new PortalDataServiceTemplate();
                CreateFile(portalDataServiceTemplate, entity, pathData, "DataService");
            }
        }
    }
}
