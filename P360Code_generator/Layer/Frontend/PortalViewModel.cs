using _360Generator.Metadata;
using _360Generator.Templates.Frontend.ViewModel;

namespace _360Generator.Layer.Frontend
{
    internal class PortalViewModel : LayerBase
    {
        public PortalCreateViewModelTemplate portalCreateViewModelTemplate { get; set; }
        public PortalDetailsViewModelTemplate portalDetailsViewModelTemplate { get; set; }
        public PortalListViewModelTemplate portalListViewModelTemplate { get; set; }
        public PortalUpdateViewModelTemplate portalUpdateViewModelTemplate { get; set; }

        public PortalViewModel(Module portalViewModelModule)
        {
            Module = portalViewModelModule;

            Extension = ExtensionEnum.ts;
            FolderPrefix = "P360.Web.";
        }

        public void CreatePortalViewModelTemplate()
        {
            foreach (var entity in Module.Entities)
            {
                string path0 = CreateFolder(RootPath, FolderPrefix);
                string pathDomain = CreateFolder(path0, "Scripts");
                string pathApp = CreateFolder(pathDomain, "App");
                string pathModule = CreateFolder(pathApp, Module.ModuleName);
                string pathEntity = CreateFolder(pathModule, entity.EntityName);
                string pathLayer = CreateFolder(pathEntity, "ViewModel");

                if (entity.Screens.Contains(Entity.screenEnum.Post))
                {
                    portalCreateViewModelTemplate = new PortalCreateViewModelTemplate();
                    CreateFile(portalCreateViewModelTemplate, entity, pathLayer, "CreateViewModel");
                }

                if (entity.Screens.Contains(Entity.screenEnum.Get))
                {
                    portalDetailsViewModelTemplate = new PortalDetailsViewModelTemplate();
                    CreateFile(portalDetailsViewModelTemplate, entity, pathLayer, "DetailViewModel");
                }

                if (entity.Screens.Contains(Entity.screenEnum.GetAll))
                {
                    portalListViewModelTemplate = new PortalListViewModelTemplate();
                    CreateFile(portalListViewModelTemplate, entity, pathLayer, "ListViewModel");
                }

                if (entity.Screens.Contains(Entity.screenEnum.Put))
                {
                    portalUpdateViewModelTemplate = new PortalUpdateViewModelTemplate();
                    CreateFile(portalUpdateViewModelTemplate, entity, pathLayer, "UpdateViewModel");
                }
            }
        }
    }
}