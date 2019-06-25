using System.Collections.Generic;
using _360Generator.Metadata;
using _360Generator.Templates.Backend.Domain;

namespace _360Generator.Layer.Backend
{
    class DomainModel : BackendLayerBase
    {     
        public DomainModelTemplate domainModelTemplate { get; set; }

        public DomainModel(Module domainModelModule) : base()
        {
            Module = domainModelModule;
            FolderPrefix = "360.Domain.";
        }

        public void CreateDomainModelTemplate()
        {
            string path0 = CreateFolder(rootPath, FolderPrefix + Module.ModuleName);
            string pathLayer = path0;
            
            foreach (var entity in Module.Entities)
            {
                domainModelTemplate = new DomainModelTemplate();
                CreateFile(domainModelTemplate, entity, pathLayer);
            }
        }   
    }
}
