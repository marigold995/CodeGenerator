using _360Generator.Metadata;
using _360Generator.Templates.Frontend.Model;

namespace _360Generator.Layer.Frontend
{
    internal class PortalModel : LayerBase
    {
        public PortalModelTemplate portalModelTemplate { get; set; }

        public PortalModel(Module portalModelModule)
        {
            Module = portalModelModule;

            Extension = ExtensionEnum.ts;
            FolderPrefix = "P360.Web.";
        }

        public void CreatePortalModelTemplate()
        {
            foreach (var entity in Module.Entities)
            {
                string path0 = CreateFolder(RootPath, FolderPrefix);
                string pathDomain = CreateFolder(path0, "Scripts");
                string pathApp = CreateFolder(pathDomain, "App");
                string pathModule = CreateFolder(pathApp, Module.ModuleName);
                string pathEntity = CreateFolder(pathModule, entity.EntityName);
                string pathLayer = CreateFolder(pathEntity, "Model");

                portalModelTemplate = new PortalModelTemplate();
                CreateFile(portalModelTemplate, entity, pathLayer);
            }
        }
    }
}