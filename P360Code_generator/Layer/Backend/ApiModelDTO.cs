using _360Generator.Metadata;
using _360Generator.Templates.Backend.ModelDTO;

namespace _360Generator.Layer.Backend
{
    internal class ApiModelDTO : LayerBase
    {
        public ApiModelDTOTemplate apiModelDTOTemplate { get; set; }

        public ApiModelDTO(Module apiModelModule)
        {
            Module = apiModelModule;

            Extension = ExtensionEnum.cs;
            FolderPrefix = "360.Api.Model.";
        }

        public void CreateApiModelTemplate()
        {
            string pathLayer = CreateFolder(RootPath, FolderPrefix + Module.ModuleName);

            foreach (var entity in Module.Entities)
            {
                apiModelDTOTemplate = new ApiModelDTOTemplate();
                CreateFile(apiModelDTOTemplate, entity, pathLayer, "DTO");
            }
        }
    }
}