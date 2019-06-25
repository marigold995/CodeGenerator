using _360Generator.Metadata;
using _360Generator.Templates.Frontend.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Generator.Layer.Frontend
{
    class PortalValidator:FrontendBaseLayer
    {       
        public PortalValidatorTemplate portalValidatorTemplate { get; set; }

        public PortalValidator(Module portalValidatorModule) : base()
        {
            Module = portalValidatorModule;
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
                string pathLayer = CreateFolder(pathEntity, "Validator");

                portalValidatorTemplate = new PortalValidatorTemplate();
                CreateFile(portalValidatorTemplate, entity, pathLayer, "Validator");
            }
        }
    }
}
