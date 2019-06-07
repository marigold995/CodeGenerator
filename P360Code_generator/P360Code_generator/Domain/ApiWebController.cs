using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P360Code_generator.Templates;

namespace P360Code_generator
{
    class ApiWebController
    {
        private Module Module { get; set; }
        public ApiWebControllerTemplate apiWebControllerTemplate { get; set; }

        public ApiWebController(Module apiWebModule)
        {
            this.Module = apiWebModule;            
        }

        public void CreateApiWebControllerTemplate()
        {
            apiWebControllerTemplate = new ApiWebControllerTemplate();
            apiWebControllerTemplate.Session = new Dictionary<string, object>();
            string moduleName = this.Module.ModuleName;
            apiWebControllerTemplate.Session["module"] = moduleName;
            apiWebControllerTemplate.Initialize();

            StringBuilder path = new StringBuilder("../../GeneratedCode/");
            path.Append(moduleName + "ProfileController.cs");

            //StringBuilder path = new StringBuilder("../../../360.Api.Web.");
            //path.Append(moduleName + "/Controllers/" + moduleName + "ProfileControllerNEW.cs");

            string pageContent = apiWebControllerTemplate.TransformText();
            System.IO.File.WriteAllText(path.ToString(), pageContent);
        }            
    }
}
