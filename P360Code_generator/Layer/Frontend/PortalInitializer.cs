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
            Module = portalInitializerModule;

            LayerSuffixList = new List<string>();
            LayerPrefixList = new List<string>();

            Extension = ExtensionEnum.ts;
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
                string pathData = CreateFolder(pathEntity, "Include");

                LayerPrefixList.Add("");
                LayerSuffixList.Add("Initializer");
                portalInitializerTemplate = new PortalInitializerTemplate();
                InitializeParameters(portalInitializerTemplate, entity, pathData);
            }
        }
    }
}
