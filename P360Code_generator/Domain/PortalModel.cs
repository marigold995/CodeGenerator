using _360Generator.Metadata;
using _360Generator.Templates.Frontend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Generator.Domain
{
    class PortalModel: LayerBase
    {
        public PortalModelTemplate portalModelTemplate { get; set; }

        public PortalModel(Module portalModelModule)
        {
            this.Module = portalModelModule;
        }

        public void CreatePortalModelTemplate()
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
                string pathData = CreateFolder(pathEntity, "Model");

                //model
                portalModelTemplate = new PortalModelTemplate();
                portalModelTemplate.Session = new Dictionary<string, object>();
                portalModelTemplate.Session["module"] = module;
                portalModelTemplate.Session["entity"] = entity.EntityName;
                portalModelTemplate.Session["screens"] = screensList;

                portalModelTemplate.Initialize();

                string pathModel = pathData;
                pathModel += "/" + entity.EntityName + ".ts";

                string pageContentModel = portalModelTemplate.TransformText();
                System.IO.File.WriteAllText(pathModel.ToString(), pageContentModel);

            }
        }
    }
}
