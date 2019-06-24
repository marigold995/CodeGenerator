using _360Generator.Metadata;
using _360Generator.Templates.Backend.Domain;

namespace _360Generator.Layer.Backend
{
    internal class DomainModel : LayerBase
    {
        public DomainModelTemplate domainModelTemplate { get; set; }

        public DomainModel(Module domainModelModule)
        {
            Module = domainModelModule;

            Extension = ExtensionEnum.cs;
            FolderPrefix = "360.Domain.";
        }

        public void CreateDomainModelTemplate()
        {
            string pathLayer = CreateFolder(RootPath, FolderPrefix + Module.ModuleName);

            foreach (var entity in Module.Entities)
            {
                domainModelTemplate = new DomainModelTemplate();
                CreateFile(domainModelTemplate, entity, pathLayer);
            }
        }
    }
}