using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _360Generator.Templates;
using _360Generator.Metadata;
using System.IO;
using _360Generator.Domain;
using _360Generator.Templates.Backend.Controller;


namespace _360Generator
{
    public class ApiWebController : LayerBase
    {
        public ApiWebControllerTemplate apiWebControllerTemplate { get; set; }

        public ApiWebController(Module apiWebModule)
        {
            Module = apiWebModule;

            LayerPrefixList = new List<string>();
            LayerSuffixList = new List<string>();

            Extension = ExtensionEnum.cs;           
            FolderPrefix = "360.Api.Web.";
        }

        public void CreateApiWebControllerTemplate()
        {
            string path0 = CreateFolder(rootPath, FolderPrefix + Module.ModuleName);
            string pathLayer = CreateFolder(path0, "Controllers");

            LayerPrefixList.Add("");
            LayerSuffixList.Add("Controller");
            
            foreach (var entity in Module.Entities)
            {
                apiWebControllerTemplate = new ApiWebControllerTemplate();
                InitializeParameters(apiWebControllerTemplate, entity, pathLayer);
            }
        }       
    }
}
