using System.Collections.Generic;
using _360Generator.Metadata;
using _360Generator.Templates.Backend.Repository;

namespace _360Generator.Layer.Backend
{
    class ApiRepository : LayerBase
    {
        public ApiInterfaceRepositoryTemplate apiInterfaceRepositoryTemplate { get; set; }
        public ApiRepositoryTemplate apiRepositoryTemplate { get; set; }

        public ApiRepository(Module repositoryModule)
        {
            Module = repositoryModule;

            LayerSuffixList = new List<string>();
            LayerPrefixList = new List<string>();

            Extension = ExtensionEnum.cs;
            FolderPrefix = "360.Api.Repository.";                   
        }

        public void CreateApiRepositoryTemplate()
        {
            string path0 = CreateFolder(rootPath, FolderPrefix + Module.ModuleName);
            string pathLayer = path0;

            LayerPrefixList.Add("");
            LayerSuffixList.Add("Repository");          
           
            foreach (var entity in Module.Entities)
            {
                apiRepositoryTemplate = new ApiRepositoryTemplate();
                InitializeParameters(apiRepositoryTemplate, entity, pathLayer);                
            }

            LayerPrefixList.Add("I");
            LayerSuffixList.Add("Repository");
            foreach (var entity in Module.Entities)
            {
                apiInterfaceRepositoryTemplate = new ApiInterfaceRepositoryTemplate();
                InitializeParameters(apiInterfaceRepositoryTemplate, entity, pathLayer);
            }
        }
    }
}