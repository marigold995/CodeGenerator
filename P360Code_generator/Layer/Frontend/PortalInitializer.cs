using _360Generator.Metadata;
using _360Generator.Templates.Frontend.Include;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Generator.Layer.Frontend
{
    class PortalInitializer: FrontendBaseLayer
    {        
        public PortalInitializerTemplate portalInitializerTemplate{ get; set; }

        public PortalInitializer(Module portalInitializerModule) : base()
        {
            Module = portalInitializerModule;
            FolderPrefix = "P360.Web.";
        }

        public void CreatePortalInitializerTemplate()
        {
            foreach (var entity in Module.Entities)
            {
                string path0 = CreateFolder(rootPath, FolderPrefix);
                string pathDomain = CreateFolder(path0, "Scripts");
                string pathApp = CreateFolder(pathDomain, "App");
                string pathModule = CreateFolder(pathApp, Module.ModuleName);
                string pathEntity = CreateFolder(pathModule, entity.EntityName);
                string pathLayer = CreateFolder(pathEntity, "Include");
               
                portalInitializerTemplate = new PortalInitializerTemplate();
                CreateFile(portalInitializerTemplate, entity, pathLayer, "Initializer");
            }
        }
    }
}
