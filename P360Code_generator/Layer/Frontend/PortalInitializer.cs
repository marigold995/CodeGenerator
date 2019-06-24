using _360Generator.Metadata;
using _360Generator.Templates.Frontend.Include;

namespace _360Generator.Layer.Frontend
{
    internal class PortalInitializer : LayerBase
    {
        public PortalInitializerTemplate portalInitializerTemplate { get; set; }

        public PortalInitializer(Module portalInitializerModule)
        {
            Module = portalInitializerModule;

            Extension = ExtensionEnum.ts;
            FolderPrefix = "P360.Web.";
        }

        public void CreatePortalInitializerTemplate()
        {
            foreach (var entity in Module.Entities)
            {
                string path0 = CreateFolder(RootPath, FolderPrefix);
                string pathDomain = CreateFolder(path0, "Scripts");
                string pathApp = CreateFolder(pathDomain, "App");
                string pathModule = CreateFolder(pathApp, Module.ModuleName);
                string pathEntity = CreateFolder(pathModule, entity.EntityName);
                string pathLayer = CreateFolder(pathEntity, "Include");

                portalInitializerTemplate = new PortalInitializerTemplate();
                CreateFile(portalInitializerTemplate, entity, pathLayer, "Initializer");
            }
        }
    }
}