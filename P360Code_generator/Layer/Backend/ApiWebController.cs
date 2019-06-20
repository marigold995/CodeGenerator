using System.Collections.Generic;
using _360Generator.Metadata;
using _360Generator.Templates.Backend.Controller;

namespace _360Generator.Layer.Backend
{
    public class ApiWebController : LayerBase
    {
        public ApiWebControllerTemplate apiWebControllerTemplate { get; set; }

        public ApiWebController(Module apiWebModule): base()
        {
            Module = apiWebModule;
            
            Extension = ExtensionEnum.cs;           
            FolderPrefix = "360.Api.Web.";
        }

        public void CreateApiWebControllerTemplate()
        {
            string path0 = CreateFolder(rootPath, FolderPrefix + Module.ModuleName);
            string pathLayer = CreateFolder(path0, "Controllers");

            foreach (var entity in Module.Entities)
            {
                apiWebControllerTemplate = new ApiWebControllerTemplate();
                CreateFile(apiWebControllerTemplate, entity, pathLayer, "Controller");
            }
        }       
    }
}
