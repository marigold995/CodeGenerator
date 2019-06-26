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
        }

        public void CreatePortalInitializerTemplate()
        {
            foreach (var entity in Module.Entities)
            {
                string frontendPath = CreateFrontendFolders(Module.ModuleName, entity.EntityName, "Include");

                portalInitializerTemplate = new PortalInitializerTemplate();
                CreateFile(portalInitializerTemplate, entity, frontendPath, "Initializer");
            }
        }
    }
}
