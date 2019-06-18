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
            Module = portalModelModule;

            LayerSuffixList = new List<string>();
            LayerPrefixList = new List<string>();

            Extension = ExtensionEnum.ts;
            FolderPrefix = "P360.Web.";
        }

        public void CreatePortalModelTemplate()
        {
            foreach (var entity in Module.Entities)
            {
                string path0 = CreateFolder(rootPath, FolderPrefix);
                string pathDomain = CreateFolder(path0, "Scripts");
                string pathApp = CreateFolder(pathDomain, "App");
                string pathModule = CreateFolder(pathApp, Module.ModuleName);
                string pathEntity = CreateFolder(pathModule, entity.EntityName);
                string pathData = CreateFolder(pathEntity, "Model");

                LayerPrefixList.Add("");
                LayerSuffixList.Add("");
                portalModelTemplate = new PortalModelTemplate();
                InitializeParameters(portalModelTemplate, entity, pathData);
                
            }
        }
    }
}
