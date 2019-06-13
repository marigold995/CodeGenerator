using _360Generator.Metadata;
using _360Generator.Templates.Frontend.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Generator.Domain
{
    class PortalValidator:RootDomain
    {
        private Module Module { get; set; }
        public PortalValidatorTemplate portalValidatorTemplate { get; set; }

        public PortalValidator(Module portalValidatorModule)
        {
            this.Module = portalValidatorModule;
        }

        public void CreatePortalValidatorTemplate()
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
                string pathData = CreateFolder(pathEntity, "Validator");

                //validator
                portalValidatorTemplate = new PortalValidatorTemplate();
                portalValidatorTemplate.Session = new Dictionary<string, object>();
                portalValidatorTemplate.Session["module"] = module;
                portalValidatorTemplate.Session["entity"] = entity.EntityName;
                portalValidatorTemplate.Session["screens"] = screensList;

                portalValidatorTemplate.Initialize();

                string pathValidator = pathData;
                pathValidator += "/" + entity.EntityName + "Validator.ts";

                string pageContentValidator = portalValidatorTemplate.TransformText();
                System.IO.File.WriteAllText(pathValidator.ToString(), pageContentValidator);

            }
        }
    }
}
