﻿using System;
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
