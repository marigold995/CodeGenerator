using _360Generator.Metadata;
using _360Generator.Templates.Frontend.Data;

namespace _360Generator.Layer.Frontend
{
    internal class PortalData : LayerBase
    {
        public PortalDataProviderTemplate portalDataProviderTemplate { get; set; }
        public PortalDataServiceTemplate portalDataServiceTemplate { get; set; }

        public PortalData(Module portalDataModule)
        {
            Module = portalDataModule;

            Extension = ExtensionEnum.ts;
            FolderPrefix = "P360.Web.";
        }

        public void CreatePortalDataTemplate()
        {
            foreach (var entity in Module.Entities)
            {
                string path0 = CreateFolder(RootPath, FolderPrefix);
                string pathDomain = CreateFolder(path0, "Scripts");
                string pathApp = CreateFolder(pathDomain, "App");
                string pathModule = CreateFolder(pathApp, Module.ModuleName);
                string pathEntity = CreateFolder(pathModule, entity.EntityName);
                string pathData = CreateFolder(pathEntity, "Data");

                portalDataProviderTemplate = new PortalDataProviderTemplate();
                CreateFile(portalDataProviderTemplate, entity, pathData, "DataProvider");
                portalDataServiceTemplate = new PortalDataServiceTemplate();
                CreateFile(portalDataServiceTemplate, entity, pathData, "DataService");
            }
        }
    }
}