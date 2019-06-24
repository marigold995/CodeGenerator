using _360Generator.Metadata;
using _360Generator.Templates.Backend.Repository;

namespace _360Generator.Layer.Backend
{
    internal class ApiRepository : LayerBase
    {
        public ApiInterfaceRepositoryTemplate apiInterfaceRepositoryTemplate { get; set; }
        public ApiRepositoryTemplate apiRepositoryTemplate { get; set; }

        public ApiRepository(Module repositoryModule)
        {
            Module = repositoryModule;

            Extension = ExtensionEnum.cs;
            FolderPrefix = "360.Api.Repository.";
        }

        public void CreateApiRepositoryTemplate()
        {
            string pathLayer = CreateFolder(RootPath, FolderPrefix + Module.ModuleName);

            foreach (var entity in Module.Entities)
            {
                apiRepositoryTemplate = new ApiRepositoryTemplate();
                CreateFile(apiRepositoryTemplate, entity, pathLayer, "Repository");
            }

            foreach (var entity in Module.Entities)
            {
                apiInterfaceRepositoryTemplate = new ApiInterfaceRepositoryTemplate();
                CreateFile(apiInterfaceRepositoryTemplate, entity, pathLayer, "Repository", "I");
            }
        }
    }
}