using _360Generator.Metadata;
using _360Generator.Templates;
using _360Generator.Templates.Frontend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Generator.Domain
{
    class PortalData: RootDomain
    {
        private Module Module { get; set; }
        public PortalDataProviderTemplate portalDataProviderTemplate { get; set; }
        public PortalDataServiceTemplate portalDataServiceTemplate{ get; set; }

        public PortalData(Module portalDataModule)
        {
            this.Module = portalDataModule;
        }

        public void CreatePortalDataTemplate()
        {
            string path0 = CreateFolder(rootPath, "P360.Web");
            string pathDomain = CreateFolder(path0, "Scripts");
            string pathApp = CreateFolder(pathDomain, "App");
            string pathModule = CreateFolder(pathApp, Module.ModuleName);            

            foreach (var entity in Module.Entities)
            {
                var module = this.Module;
                var screensList = entity.Screens;
                string pathEntity = CreateFolder(pathModule, entity.EntityName);
                string pathData = CreateFolder(pathEntity, "Data");

                //data provider
                portalDataProviderTemplate = new PortalDataProviderTemplate();              
                portalDataProviderTemplate.Session = new Dictionary<string, object>();
                portalDataProviderTemplate.Session["module"] = module;
                portalDataProviderTemplate.Session["entity"] = entity.EntityName;
                portalDataProviderTemplate.Session["screens"] = screensList;

                portalDataProviderTemplate.Initialize();

                string pathDataProvider = pathData;
                pathDataProvider += "/" + entity.EntityName + "DataProvider.ts";

                string pageContentDataProvider = portalDataProviderTemplate.TransformText();
                System.IO.File.WriteAllText(pathDataProvider.ToString(), pageContentDataProvider);

                //data service
                portalDataServiceTemplate = new PortalDataServiceTemplate();
                portalDataServiceTemplate.Session = new Dictionary<string, object>();
                portalDataServiceTemplate.Session["module"] = module;
                portalDataServiceTemplate.Session["entity"] = entity.EntityName;
                portalDataServiceTemplate.Session["screens"] = screensList;

                portalDataServiceTemplate.Initialize();

                string pathDataService = pathData;
                pathDataService += "/" + entity.EntityName + "DataService.ts";

                string pageContentDataService = portalDataServiceTemplate.TransformText();
                System.IO.File.WriteAllText(pathDataService.ToString(), pageContentDataService);
            }
        }
    }
}
