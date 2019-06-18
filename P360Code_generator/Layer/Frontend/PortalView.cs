using _360Generator.Metadata;
using _360Generator.Templates.Frontend.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Generator.Domain
{
    class PortalView: LayerBase
    {
        public PortalCreateViewTemplate portalCreateViewTemplate { get; set; }
        public PortalDetailsViewTemplate portalDetailsViewTemplate { get; set; }
        public PortalListViewTemplate portalListViewTemplate { get; set; }
        public PortalUpdateViewTemplate portalUpdateViewTemplate { get; set; }


        public PortalView(Module portalViewModule)
        {
            Module = portalViewModule;

            LayerSuffixList = new List<string>();
            LayerPrefixList = new List<string>();

            Extension = ExtensionEnum.ts;
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
                string pathView = CreateFolder(pathEntity, "View");

                //create
                if (entity.Screens.Contains(Entity.screenEnum.Post)){ 
                    portalCreateViewTemplate = new PortalCreateViewTemplate();
                    LayerPrefixList.Add("");
                    LayerSuffixList.Add("CreateView");
                    InitializeParameters(portalCreateViewTemplate, entity, pathView);
                }
                //details
                if (entity.Screens.Contains(Entity.screenEnum.Get))
                {
                    portalDetailsViewTemplate = new PortalDetailsViewTemplate();
                    LayerPrefixList.Add("");
                    LayerSuffixList.Add("DetailsView");
                    InitializeParameters(portalCreateViewTemplate, entity, pathView);
                }
                //list
                if (entity.Screens.Contains(Entity.screenEnum.GetAll))
                {
                    portalListViewTemplate = new PortalListViewTemplate();
                    LayerPrefixList.Add("");
                    LayerSuffixList.Add("ListView");
                    InitializeParameters(portalListViewTemplate, entity, pathView);
                }
                //update
                if (entity.Screens.Contains(Entity.screenEnum.Put))
                {
                    portalUpdateViewTemplate = new PortalUpdateViewTemplate();
                    LayerPrefixList.Add("");
                    LayerSuffixList.Add("UpdateView");
                    InitializeParameters(portalUpdateViewTemplate, entity, pathView);
                }
            }
        }
    }
}
