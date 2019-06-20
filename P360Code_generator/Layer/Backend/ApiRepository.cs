using System.Collections.Generic;
using _360Generator.Metadata;
using _360Generator.Templates.Backend.Repository;

namespace _360Generator.Layer.Backend
{
    class ApiRepository : LayerBase
    {
        public ApiInterfaceRepositoryTemplate apiInterfaceRepositoryTemplate { get; set; }
        public ApiRepositoryTemplate apiRepositoryTemplate { get; set; }

        public ApiRepository(Module repositoryModule): base()
        {
            Module = repositoryModule;

            Extension = ExtensionEnum.cs;
            FolderPrefix = "360.Api.Repository.";                   
        }

        public void CreateApiRepositoryTemplate()
        {
            string path0 = CreateFolder(rootPath, FolderPrefix + Module.ModuleName);
            string pathLayer = path0;       
           
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