using _360Generator.Metadata;
using _360Generator.Templates.Frontend.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Generator.Domain
{
    class PortalViewModel: RootDomain
    {
        private Module Module { get; set; }
        public PortalCreateViewModelTemplate portalCreateViewModelTemplate { get; set; }
        public PortalDetailsViewModelTemplate portalDetailsViewModelTemplate { get; set; }
        public PortalListViewModelTemplate portalListViewModelTemplate { get; set; }
        public PortalUpdateViewModelTemplate portalUpdateViewModelTemplate { get; set; }

        public PortalViewModel(Module portalViewModelModule)
        {
            this.Module = portalViewModelModule;
        }

        public void CreatePortalViewModelTemplate()
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
                string pathData = CreateFolder(pathEntity, "ViewModel");

                //create
                if (entity.Screens.Contains(Entity.screenEnum.Post))
                {
                    portalCreateViewModelTemplate = new PortalCreateViewModelTemplate();
                    portalCreateViewModelTemplate.Session = new Dictionary<string, object>();
                    portalCreateViewModelTemplate.Session["module"] = module;
                    portalCreateViewModelTemplate.Session["entity"] = entity.EntityName;
                    portalCreateViewModelTemplate.Session["screens"] = screensList;

                    portalCreateViewModelTemplate.Initialize();

                    string pathCreate = pathData;
                    pathCreate += "/" + entity.EntityName + "CreateViewModel.ts";

                    string pageContentCreate = portalCreateViewModelTemplate.TransformText();
                    System.IO.File.WriteAllText(pathCreate.ToString(), pageContentCreate);
                }
                //details
                if (entity.Screens.Contains(Entity.screenEnum.Get))
                {
                    portalDetailsViewModelTemplate = new PortalDetailsViewModelTemplate();
                    portalDetailsViewModelTemplate.Session = new Dictionary<string, object>();
                    portalDetailsViewModelTemplate.Session["module"] = module;
                    portalDetailsViewModelTemplate.Session["entity"] = entity.EntityName;
                    portalDetailsViewModelTemplate.Session["screens"] = screensList;

                    portalDetailsViewModelTemplate.Initialize();

                    string pathDetails = pathData;
                    pathDetails += "/" + entity.EntityName + "DetailViewModel.ts";

                    string pageContentDetails = portalDetailsViewModelTemplate.TransformText();
                    System.IO.File.WriteAllText(pathDetails.ToString(), pageContentDetails);
                }
                //list
                if (entity.Screens.Contains(Entity.screenEnum.GetAll))
                {
                    portalListViewModelTemplate = new PortalListViewModelTemplate();
                    portalListViewModelTemplate.Session = new Dictionary<string, object>();
                    portalListViewModelTemplate.Session["module"] = module;
                    portalListViewModelTemplate.Session["entity"] = entity.EntityName;
                    portalListViewModelTemplate.Session["screens"] = screensList;

                    portalListViewModelTemplate.Initialize();

                    string pathList = pathData;
                    pathList += "/" + entity.EntityName + "ListViewModel.ts";

                    string pageContentList = portalListViewModelTemplate.TransformText();
                    System.IO.File.WriteAllText(pathList.ToString(), pageContentList);
                }
                //update
                if (entity.Screens.Contains(Entity.screenEnum.Put))
                {
                    portalUpdateViewModelTemplate = new PortalUpdateViewModelTemplate();
                    portalUpdateViewModelTemplate.Session = new Dictionary<string, object>();
                    portalUpdateViewModelTemplate.Session["module"] = module;
                    portalUpdateViewModelTemplate.Session["entity"] = entity.EntityName;
                    portalUpdateViewModelTemplate.Session["screens"] = screensList;

                    portalUpdateViewModelTemplate.Initialize();

                    string pathUpdate = pathData;
                    pathUpdate += "/" + entity.EntityName + "UpdateViewModel.ts";

                    string pageContentUpdate = portalUpdateViewModelTemplate.TransformText();
                    System.IO.File.WriteAllText(pathUpdate.ToString(), pageContentUpdate);
                }
            }
        }

    }
}
