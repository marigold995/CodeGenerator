using _360Generator.Metadata;
using _360Generator.Templates.Frontend.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Generator.Layer.Frontend
{
    class PortalViewModel: LayerBase
    {       
        public PortalCreateViewModelTemplate portalCreateViewModelTemplate { get; set; }
        public PortalDetailsViewModelTemplate portalDetailsViewModelTemplate { get; set; }
        public PortalListViewModelTemplate portalListViewModelTemplate { get; set; }
        public PortalUpdateViewModelTemplate portalUpdateViewModelTemplate { get; set; }

        public PortalViewModel(Module portalViewModelModule)
        {
            Module = portalViewModelModule;

            LayerSuffixList = new List<string>();
            LayerPrefixList = new List<string>();

            Extension = ExtensionEnum.ts;
            FolderPrefix = "P360.Web.";
        }

        public void CreatePortalViewModelTemplate()
        {
            foreach (var entity in Module.Entities)
            {
                string path0 = CreateFolder(rootPath, FolderPrefix);
                string pathDomain = CreateFolder(path0, "Scripts");
                string pathApp = CreateFolder(pathDomain, "App");
                string pathModule = CreateFolder(pathApp, Module.ModuleName);
                string pathEntity = CreateFolder(pathModule, entity.EntityName);
                string pathLayerViewModel = CreateFolder(pathEntity, "ViewModel");

                //create
                if (entity.Screens.Contains(Entity.screenEnum.Post))
                {
                    portalCreateViewModelTemplate = new PortalCreateViewModelTemplate();
                    LayerPrefixList.Add("");
                    LayerSuffixList.Add("CreateViewModel");
                    InitializeParameters(portalCreateViewModelTemplate, entity, pathLayerViewModel);
                }
                //details
                if (entity.Screens.Contains(Entity.screenEnum.Get))
                {
                    portalDetailsViewModelTemplate = new PortalDetailsViewModelTemplate();
                    LayerPrefixList.Add("");
                    LayerSuffixList.Add("DetailViewModel");
                    InitializeParameters(portalCreateViewModelTemplate, entity, pathLayerViewModel);
                }
                //list
                if (entity.Screens.Contains(Entity.screenEnum.GetAll))
                {
                    portalListViewModelTemplate = new PortalListViewModelTemplate();
                    LayerPrefixList.Add("");
                    LayerSuffixList.Add("ListViewModel");
                    InitializeParameters(portalListViewModelTemplate, entity, pathLayerViewModel);
                }
                //update
                if (entity.Screens.Contains(Entity.screenEnum.Put))
                {
                    portalUpdateViewModelTemplate = new PortalUpdateViewModelTemplate();
                    LayerPrefixList.Add("");
                    LayerSuffixList.Add("UpdateViewModel");
                    InitializeParameters(portalUpdateViewModelTemplate, entity, pathLayerViewModel);
                }
            }
        }

    }
}
