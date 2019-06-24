using _360Generator.Metadata;
using _360Generator.Templates.Frontend.Validator;

namespace _360Generator.Layer.Frontend
{
    internal class PortalValidator : LayerBase
    {
        public PortalValidatorTemplate portalValidatorTemplate { get; set; }

        public PortalValidator(Module portalValidatorModule)
        {
            Module = portalValidatorModule;

            Extension = ExtensionEnum.ts;
            FolderPrefix = "P360.Web.";
        }

        public void CreatePortalValidatorTemplate()
        {
            foreach (var entity in Module.Entities)
            {
                string path0 = CreateFolder(RootPath, FolderPrefix);
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