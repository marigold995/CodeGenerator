using _360Generator.Metadata;
using _360Generator.Templates.Frontend.Include;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Generator.Domain
{
    class PortalInitializer: LayerBase
    {        
        public PortalInitializerTemplate portalInitializerTemplate{ get; set; }

        public PortalInitializer(Module portalInitializerModule)
        {
            this.Module = portalInitializerModule;
        }

        public void CreatePortalInitializerTemplate()
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
                string pathData = CreateFolder(pathEntity, "Include");

                //initializer
                portalInitializerTemplate = new PortalInitializerTemplate();
                portalInitializerTemplate.Session = new Dictionary<string, object>();
                portalInitializerTemplate.Session["module"] = module;
                portalInitializerTemplate.Session["entity"] = entity.EntityName;
                portalInitializerTemplate.Session["screens"] = screensList;

                portalInitializerTemplate.Initialize();

                string pathInitializer = pathData;
                pathInitializer += "/" + entity.EntityName + "Initializer.ts";

                string pageContentInitializer = portalInitializerTemplate.TransformText();
                System.IO.File.WriteAllText(pathInitializer.ToString(), pageContentInitializer);
               
            }
        }
    }
}
