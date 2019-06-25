using _360Generator.Metadata;
using _360Generator.Templates.Frontend.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Generator.Layer.Frontend
{
    class PortalView: FrontendBaseLayer
    {
        public PortalCreateViewTemplate portalCreateViewTemplate { get; set; }
        public PortalDetailsViewTemplate portalDetailsViewTemplate { get; set; }
        public PortalListViewTemplate portalListViewTemplate { get; set; }
        public PortalUpdateViewTemplate portalUpdateViewTemplate { get; set; }


        public PortalView(Module portalViewModule)
        {
            Module = portalViewModule;
            FolderPrefix = "P360.Web.";
        }

        public void CreatePortalViewTemplate()
        {          
            foreach (var entity in Module.Entities)
            {
                string path0 = CreateFolder(rootPath, FolderPrefix);
                string pathDomain = CreateFolder(path0, "Scripts");
                string pathApp = CreateFolder(pathDomain, "App");
                string pathModule = CreateFolder(pathApp, Module.ModuleName);
                string pathEntity = CreateFolder(pathModule, entity.EntityName);
                string pathLayer = CreateFolder(pathEntity, "View");
                
                if (entity.Screens.Contains(Entity.screenEnum.Post)){ 
                    portalCreateViewTemplate = new PortalCreateViewTemplate(); 
                    CreateFile(portalCreateViewTemplate, entity, pathLayer, "CreateView");
                }
                
                if (entity.Screens.Contains(Entity.screenEnum.Get))
                {
                    portalDetailsViewTemplate = new PortalDetailsViewTemplate();
                    CreateFile(portalDetailsViewTemplate, entity, pathLayer, "DetailView");
                }
                
                if (entity.Screens.Contains(Entity.screenEnum.GetAll))
                {
                    portalListViewTemplate = new PortalListViewTemplate();
                    CreateFile(portalListViewTemplate, entity, pathLayer, "ListView");
                }
                
                if (entity.Screens.Contains(Entity.screenEnum.Put))
                {
                    portalUpdateViewTemplate = new PortalUpdateViewTemplate();
                    CreateFile(portalUpdateViewTemplate, entity, pathLayer, "UpdateView");
                }
            }
        }
    }
}
