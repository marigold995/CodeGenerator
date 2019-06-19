using System.Collections.Generic;
using _360Generator.Metadata;
using _360Generator.Templates.Backend.Domain;

namespace _360Generator.Layer.Backend
{
    class DomainModel : LayerBase
    {     
        public DomainModelTemplate domainModelTemplate { get; set; }

        public DomainModel(Module domainModelModule)
        {
            Module = domainModelModule;

            LayerPrefixList = new List<string>();
            LayerSuffixList = new List<string>();

            Extension = ExtensionEnum.cs;
            FolderPrefix = "360.Domain.";
        }

        public void CreateDomainModelTemplate()
        {
            string path0 = CreateFolder(rootPath, FolderPrefix + Module.ModuleName);
            string pathLayer = path0;

            LayerPrefixList.Add("");
            LayerSuffixList.Add("");

            foreach (var entity in Module.Entities)
            {
                domainModelTemplate = new DomainModelTemplate();
                InitializeParameters(domainModelTemplate, entity, pathLayer);
            }
        }   
    }
}
