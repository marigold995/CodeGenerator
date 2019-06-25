using _360Generator.Metadata;
using _360Generator.Templates.Frontend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Generator.Layer.Frontend
{
    class PortalModel: FrontendBaseLayer
    {
        public PortalModelTemplate portalModelTemplate { get; set; }

        public PortalModel(Module portalModelModule) : base()
        {
            Module = portalModelModule;
            FolderPrefix = "P360.Web.";
        }

        public void CreatePortalModelTemplate()
        {
            foreach (var entity in Module.Entities)
            {
                string path0 = CreateFolder(rootPath, FolderPrefix);
                string pathDomain = CreateFolder(path0, "Scripts");
                string pathApp = CreateFolder(pathDomain, "App");
                string pathModule = CreateFolder(pathApp, Module.ModuleName);
                string pathEntity = CreateFolder(pathModule, entity.EntityName);
                string pathLayer = CreateFolder(pathEntity, "Model");
               
                portalModelTemplate = new PortalModelTemplate();
                CreateFile(portalModelTemplate, entity, pathLayer);
            }
        }
    }
}
