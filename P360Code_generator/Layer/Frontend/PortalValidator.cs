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
        }

        public void CreatePortalValidatorTemplate()
        {
            foreach (var entity in Module.Entities)
            {
                string frontendPath = CreateFrontendFolders(Module.ModuleName, entity.EntityName, "Validator");

                portalValidatorTemplate = new PortalValidatorTemplate();
                CreateFile(portalValidatorTemplate, entity, frontendPath, "Validator");
            }
        }
    }
}
