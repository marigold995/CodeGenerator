using _360Generator.Metadata;
using _360Generator.Templates.Frontend.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Generator.Domain
{
    class PortalView: RootDomain
    {
        private Module Module { get; set; }
        public PortalCreateViewTemplate portalCreateViewTemplate { get; set; }
        public PortalDetailsViewTemplate portalDetailsViewTemplate { get; set; }
        public PortalListViewTemplate portalListViewTemplate { get; set; }
        public PortalUpdateViewTemplate portalUpdateViewTemplate { get; set; }


        public PortalView(Module portalViewModule)
        {
            this.Module = portalViewModule;
        }

        public void CreatePortalViewTemplate()
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
                string pathData = CreateFolder(pathEntity, "View");

                //create
                portalCreateViewTemplate = new PortalCreateViewTemplate();
                portalCreateViewTemplate.Session = new Dictionary<string, object>();
                portalCreateViewTemplate.Session["module"] = module;
                portalCreateViewTemplate.Session["entity"] = entity.EntityName;
                portalCreateViewTemplate.Session["screens"] = screensList;

                portalCreateViewTemplate.Initialize();

                string pathCreate = pathData;
                pathCreate += "/" + entity.EntityName + "CreateView.ts";

                string pageContentCreate = portalCreateViewTemplate.TransformText();
                System.IO.File.WriteAllText(pathCreate.ToString(), pageContentCreate);

                //details
                portalDetailsViewTemplate = new PortalDetailsViewTemplate();
                portalDetailsViewTemplate.Session = new Dictionary<string, object>();
                portalDetailsViewTemplate.Session["module"] = module;
                portalDetailsViewTemplate.Session["entity"] = entity.EntityName;
                portalDetailsViewTemplate.Session["screens"] = screensList;

                portalDetailsViewTemplate.Initialize();

                string pathDetails = pathData;
                pathDetails += "/" + entity.EntityName + "DetailView.ts";

                string pageContentDetails = portalDetailsViewTemplate.TransformText();
                System.IO.File.WriteAllText(pathDetails.ToString(), pageContentDetails);

                //list
                portalListViewTemplate = new PortalListViewTemplate();
                portalListViewTemplate.Session = new Dictionary<string, object>();
                portalListViewTemplate.Session["module"] = module;
                portalListViewTemplate.Session["entity"] = entity.EntityName;
                portalListViewTemplate.Session["screens"] = screensList;

                portalListViewTemplate.Initialize();

                string pathList = pathData;
                pathList += "/" + entity.EntityName + "ListView.ts";

                string pageContentList = portalListViewTemplate.TransformText();
                System.IO.File.WriteAllText(pathList.ToString(), pageContentList);

                //update
                portalUpdateViewTemplate = new PortalUpdateViewTemplate();
                portalUpdateViewTemplate.Session = new Dictionary<string, object>();
                portalUpdateViewTemplate.Session["module"] = module;
                portalUpdateViewTemplate.Session["entity"] = entity.EntityName;
                portalUpdateViewTemplate.Session["screens"] = screensList;

                portalUpdateViewTemplate.Initialize();

                string pathUpdate = pathData;
                pathUpdate += "/" + entity.EntityName + "UpdateView.ts";

                string pageContentUpdate = portalUpdateViewTemplate.TransformText();
                System.IO.File.WriteAllText(pathUpdate.ToString(), pageContentUpdate);

            }
        }
    }
}
