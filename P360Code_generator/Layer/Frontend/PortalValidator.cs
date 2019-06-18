using _360Generator.Metadata;
using _360Generator.Templates.Frontend.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Generator.Domain
{
    class PortalValidator:LayerBase
    {       
        public PortalValidatorTemplate portalValidatorTemplate { get; set; }

        public PortalValidator(Module portalValidatorModule)
        {
            Module = portalValidatorModule;

            LayerSuffixList = new List<string>();
            LayerPrefixList = new List<string>();

            Extension = ExtensionEnum.ts;
            FolderPrefix = "P360.Web.";

        }

        public void CreatePortalValidatorTemplate()
        {
            foreach (var entity in Module.Entities)
            {
                string path0 = CreateFolder(rootPath, FolderPrefix);
                string pathDomain = CreateFolder(path0, "Scripts");
                string pathApp = CreateFolder(pathDomain, "App");
                string pathModule = CreateFolder(pathApp, Module.ModuleName);
                string pathEntity = CreateFolder(pathModule, entity.EntityName);
                string pathData = CreateFolder(pathEntity, "Validator");

                LayerPrefixList.Add("");
                LayerSuffixList.Add("Validator");
                portalValidatorTemplate = new PortalValidatorTemplate();
                InitializeParameters(portalValidatorTemplate, entity, pathData);
            }
        }
    }
}
