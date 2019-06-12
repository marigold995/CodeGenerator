using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _360Generator.Metadata;
using _360Generator.Templates;

namespace _360Generator.Domain
{
    class ApiModelDTO : RootDomain
    {
        private Module Module { get; set; }
        public ApiModelDTOTemplate apiModelDTOTemplate { get; set; }

        public ApiModelDTO(Module apiModelModule)
        {
            this.Module = apiModelModule;
        }

        public void CreateApiModelTemplate()
        {
            string pathDomain = CreateFolder(rootPath, "Model");

            foreach (var entity in Module.Entities)
            {
                apiModelDTOTemplate = new ApiModelDTOTemplate();
                apiModelDTOTemplate.Session = new Dictionary<string, object>();

                var module = this.Module;
                var screensList = entity.Screens;
                apiModelDTOTemplate.Session["module"] = module;
                apiModelDTOTemplate.Session["entity"] = entity.EntityName;
                apiModelDTOTemplate.Session["screens"] = screensList;

                apiModelDTOTemplate.Initialize();

                string path = pathDomain;
                path += "/" + entity.EntityName + "DTO.cs";

                string pageContent = apiModelDTOTemplate.TransformText();
                System.IO.File.WriteAllText(path.ToString(), pageContent);
            }    
              
        }
    }
}
