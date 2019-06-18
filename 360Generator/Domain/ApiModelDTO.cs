using P360Code_generator.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P360Code_generator.Domain
{
    class ApiModelDTO
    {
        private Module Module { get; set; }
        public ApiModelDTOTemplate apiModelDTOTemplate { get; set; }

        public ApiModelDTO(Module apiModelModule)
        {
            this.Module = apiModelModule;
        }

        public void CreateApiModelTemplate()
        {
            apiModelDTOTemplate = new ApiModelDTOTemplate();
            apiModelDTOTemplate.Session = new Dictionary<string, object>();
            string moduleName = this.Module.ModuleName;
            apiModelDTOTemplate.Session["module"] = moduleName;
            apiModelDTOTemplate.Initialize();

            StringBuilder path = new StringBuilder("../../GeneratedCode/");
            path.Append(moduleName + "ProfileDto.cs");                     

            string pageContent = apiModelDTOTemplate.TransformText();
            System.IO.File.WriteAllText(path.ToString(), pageContent);
        }
    }
}
